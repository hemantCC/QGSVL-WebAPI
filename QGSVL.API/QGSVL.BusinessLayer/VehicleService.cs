using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using QGSVL.BusinessLogicLayer.Interfaces;
using QGSVL.DataAccessLayer.Interfaces;
using QGSVL.EntityLayer.Entities.BusinessEntity;
using QGSVL_WebAPI.Models.DataEntities;

namespace QGSVL.BusinessLogicLayer
{
    public class VehicleService : IVehicleService
    {
        private readonly IVehicleRepository _vehicleRepository;
        public VehicleService(IVehicleRepository vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;
        }
        public async Task<IEnumerable<VehicleDetail>> GetVehicles()
        {
            return await _vehicleRepository.GetVehicles();
        }

        public async Task<VehicleDetailVM> GetVehicle(int id)
        {
            return await _vehicleRepository.GetVehicle(id);
        }

        public async Task<Object> GetVehicleFilters()
        {
            return await _vehicleRepository.GetVehicleFilters();
        }
    }
}
