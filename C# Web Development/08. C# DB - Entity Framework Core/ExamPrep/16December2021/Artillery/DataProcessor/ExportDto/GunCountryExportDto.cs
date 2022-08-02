﻿using System.Xml.Serialization;

namespace Artillery.DataProcessor.ExportDto
{
    [XmlType("Country")]
    public class GunCountryExportDto
    {
        [XmlAttribute("Country")]
        public string CountryName { get; set; }

        [XmlAttribute("ArmySize")]
        public int ArmySize { get; set; }
    }
}