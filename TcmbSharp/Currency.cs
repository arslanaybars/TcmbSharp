using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace TcmbSharp
{
    [Serializable]
    [XmlTypeAttribute(AnonymousType = true)]
    public class CurrencyList : List<Currency>
    {
        public CurrencyList() { Currencies = new List<Currency>(); }

        [XmlElement("Currency")]
        public List<Currency> Currencies { get; set; }

        public string Date { get; set; }
    }

    public class Currency
    {
        [XmlAttribute("CurrencyCode")]
        public string Code { get; set; }

        [XmlElement(ElementName = "Unit")]
        public string Unit { get; set; }

        [XmlElement(ElementName = "CurrencyName")]
        public string Name { get; set; }

        [XmlElement(ElementName = "BanknoteBuying")]
        public string Buying { get; set; }

        [XmlElement(ElementName = "BanknoteSelling")]
        public string Selling { get; set; }

        // if buying or selling by app config default selling
        public string Rate
        {
            get
            {
                if (!string.IsNullOrWhiteSpace(Selling))
                {
                    return Selling;
                }

                if (IsCrossRate)
                {
                    return CrossRateUsd;
                }

                throw new ArgumentException("Error while returning rate");
            }
        }

        // The selling value is null or whitespace and cross rate isn't null or white space
        // Then it's cross rate operation
        public bool IsCrossRate => string.IsNullOrWhiteSpace(Selling) && !string.IsNullOrWhiteSpace(CrossRateUsd);

        [XmlElement(ElementName = "CrossRateUSD")]
        public string CrossRateUsd { get; set; }

        [XmlElement(ElementName = "CrossRateOther")]
        public string CrossRateOther { get; set; }

    }
}
