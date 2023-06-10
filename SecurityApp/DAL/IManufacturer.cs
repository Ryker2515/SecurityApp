using SecurityApp.Models;

namespace SecurityApp.DAL
{
    public interface IManufacturer
    {
        Task<List<ManufacturerDto>> getList(int pageNumber, string filter, string search);
    }
}
