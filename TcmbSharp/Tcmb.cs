using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Xml;
using System.Xml.Serialization;
using System.Runtime.Caching;

namespace TcmbSharp
{
    // from tr to usd/eur/gbp
    public class Tcmb
    {
        private const string BaseUri = @"http://www.tcmb.gov.tr/kurlar/today.xml";

        private static readonly XmlDocument Doc = new XmlDocument();
        private static string _xmlStr;

        private static readonly CurrencyList CurrencyList = Currencies();

        private static readonly ObjectCache Cache = MemoryCache.Default;
        private const string CacheKey = "currencyList";

        public static decimal Rate(string currencyCode)
        {
            // Loading from a file, you can also load from a stream
            var currency = CurrencyList.FirstOrDefault(x => x.Code == currencyCode);

            if (currency == null)
            {
                throw new ArgumentException("Currency code not found for provided currency");
            }

            // If It's not cross rate operation. we return currency rate
            if (!currency.IsCrossRate)
            {
                return decimal.Parse(currency.Rate, CultureInfo.InvariantCulture);
            }

            var usdCurrency = decimal.Parse(CurrencyList.First(x => x.Code == "USD").Rate, CultureInfo.InvariantCulture);
            var currencyUsdWeight = 1 / Convert.ToDecimal(currency.CrossRateUsd);
            return currencyUsdWeight * usdCurrency;
        }

        private static CurrencyList Currencies()
        {
            var currencyList = GetFromCache<CurrencyList>(CacheKey);

            if (currencyList != null) { return currencyList; }

            using (var wc = new WebClient())
            {
                _xmlStr = wc.DownloadString(BaseUri);
            }

            Doc.LoadXml(_xmlStr);

            var xmlContent = Doc.InnerXml;

            var serializer = new XmlSerializer(typeof(CurrencyList), new XmlRootAttribute("Tarih_Date"));
            using (var stringReader = new StringReader(xmlContent))
            using (var reader = XmlReader.Create(stringReader))
            {
                var result = (CurrencyList)serializer.Deserialize(reader);
                AddToCache(result, CacheKey);
                return result;
            }
        }

        #region [ Cache ]

        private static void AddToCache(object objectToCache, string key)
        {
            // Create a dateoffset until next 3.30pm
            // Tcmb updates the rates every day at 3.30pm 
            var now = DateTime.Now;
            var today = now.Date;
            var nextPublishTime = today.AddHours(15).AddMinutes(31).AddDays(now.Hour >= 15 && now.Minute >= 31 ? 1 : 0);

            ObjectCache cache = MemoryCache.Default;
            cache.Add(key, objectToCache, nextPublishTime);
        }

        private static T GetFromCache<T>(string key) where T : class
        {
            try
            {
                return (T)Cache[key];
            }
            catch
            {
                return null;
            }
        }

        #endregion

    }
}
