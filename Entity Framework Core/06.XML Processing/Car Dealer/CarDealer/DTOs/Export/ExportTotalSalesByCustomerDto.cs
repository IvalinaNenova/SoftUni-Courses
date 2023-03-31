using System.Xml.Serialization;

namespace CarDealer.DTOs.Export
{
    [XmlType("customer")]
    public class ExportTotalSalesByCustomerDto
    {
        [XmlAttribute("full-name")]
        public string Name { get; set; } = null!;


        [XmlAttribute("bought-cars")]
        public int BoughtCars { get; set; }


        [XmlAttribute("spent-money")]
        public decimal SpentMoney { get; set; }

    }
}
