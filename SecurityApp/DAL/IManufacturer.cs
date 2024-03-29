﻿using SecurityApp.Models;

namespace SecurityApp.DAL
{
    public interface IManufacturer
    {
        Task<ManufacturerListView> getList(int pageNumber, int id, string search);
        Task<ManufacturerDetailsView> getManufacturersDetails(int CdbId, int ManufacturerId);
    }
}
