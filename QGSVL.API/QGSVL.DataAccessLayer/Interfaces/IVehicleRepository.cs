using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using QGSVL.EntityLayer.Entities.BusinessEntity;
using QGSVL_WebAPI.Models.DataEntities;

namespace QGSVL.DataAccessLayer.Interfaces
{
    public interface IVehicleRepository
    {
        Task<IEnumerable<VehicleDetail>> GetVehicles();
        Task<VehicleDetailVM> GetVehicle(int id);
        Task<Object> GetVehicleFilters();

    }
}
