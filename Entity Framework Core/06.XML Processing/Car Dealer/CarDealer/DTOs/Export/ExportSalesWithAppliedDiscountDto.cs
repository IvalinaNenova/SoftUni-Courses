
using System.Xml.Serialization;

namespace CarDealer.DTOs.Export
{
    [XmlType("sale")]
    public class ExportSalesWithAppliedDiscountDto
    {
        [XmlElement("car")]
        public ExportInnerDto Car { get; set; }


        [XmlElement("discount")]
        public string Discount { get; set; }


        [XmlElement("customer-name")]
        public string CustomerName { get; set; }


        [XmlElement("price")]
        public decimal Price { get; set; }


        [XmlElement("price-with-discount")]
        public decimal PriceWithDiscount { get; set; }
    }
}
