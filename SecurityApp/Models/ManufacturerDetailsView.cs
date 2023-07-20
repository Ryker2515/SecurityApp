namespace SecurityApp.Models
{
    public class ManufacturerDetailsView
    {
        public ManufacturerDetails manufacturerDetails { get; set; }
        public List<ManufacturerReferences> manufacturerReferences { get; set; }
    }

    public class ManufacturerReferences
    {
        public int cdbId { get; set; }
        public string url { get; set; }
        public string source { get; set; }
    }

    public class ManufacturerDetails
    {
        public int cdbId { get; set; }
        public int manufacturerId { get; set; }
        public string cveId { get; set; }
        public string productName { get; set; }
        public string manufacturerName { get; set; }
        public string versionNumber { get; set; }
        public DateTime published { get; set; }
        public string vulnStatus { get; set; }
        public string source { get; set; }
        public string baseSeverity { get; set; }
        public decimal impactScore { get; set; }

        public string value { get; set; }
    }
}
