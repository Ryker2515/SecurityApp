namespace SecurityApp.Models
{
    public class ManufacturerListView
    {
        public List<ManufacturerDto>? manufacturerData { get; set; }
        public List<FilterList>? filterLists { get; set; }
        public int countList { get; set; }
        public int nextPageNumber { get; set; }
        public int filterId { get; set; }
        public bool isNextPage {  get; set; }  
    }

    public class FilterList
    {
        public int id { get; set; }
        public string? name { get; set; }
    }
}
