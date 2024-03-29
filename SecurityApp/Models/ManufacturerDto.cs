﻿namespace SecurityApp.Models
{
    public class ManufacturerDto
    {
        public int id { get; set; }
        public int manufacturerId { get; set; }
        public string cveId { get; set; }
        public string baseSeverity { get; set; }
        public string productName { get; set; }
        public string versionNumber { get; set; }
        public DateTime published { get; set; }
    }
}
