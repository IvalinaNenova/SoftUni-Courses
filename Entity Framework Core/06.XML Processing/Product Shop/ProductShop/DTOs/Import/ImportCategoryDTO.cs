using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ProductShop.DTOs.Import
{
    [XmlType("Category")]
    public class ImportCategoryDTO
    {
        [XmlElement("name")]
        public string Name { get; set; } = null!;

    }
}
