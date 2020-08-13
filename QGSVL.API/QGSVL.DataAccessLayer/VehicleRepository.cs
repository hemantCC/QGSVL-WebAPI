using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using QGSVL.DataAccessLayer.Interfaces;
using QGSVL.EntityLayer.Data;
using QGSVL.EntityLayer.Entities.BusinessEntity;
using QGSVL_WebAPI.Models.DataEntities;

namespace QGSVL.DataAccessLayer
{
    public class VehicleRepository : IVehicleRepository
    {
        private readonly ApplicationDbContext _context;
        public VehicleRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<VehicleDetail>> GetVehicles()
        {
            IEnumerable<VehicleDetail> vehicles = await _context.VehicleDetail.ToListAsync();
            return vehicles;
        }

        public async Task<VehicleDetailVM> GetVehicle(int id)
        {
            VehicleDetail vehicle = await _context.VehicleDetail.Where(x => x.Id == id).FirstOrDefaultAsync();
            string MainEquipment = await _context.Equipment.Where(x => x.Car == vehicle && x.EquipmentType == "Main")
                .Select(x => x.Features).FirstOrDefaultAsync();
            string StandardEquipment = await _context.Equipment.Where(x => x.Car == vehicle && x.EquipmentType == "Standard")
                .Select(x => x.Features).FirstOrDefaultAsync();
            string[] IncludedServices = await _context.IncludedServices.Select(x => x.Name).ToArrayAsync();

            //convert comma seperated data into array
            string[] MainEquipments = MainEquipment.Split(',').ToArray();
            string[] StandardEquipments = StandardEquipment.Split(',').ToArray();
            VehicleDetailVM Vehicle = new VehicleDetailVM { 
                Vehicle = vehicle,
                MainEquipments = MainEquipments,
                StandardEquipments = StandardEquipments,
                IncludedServices = IncludedServices
            };

            return Vehicle;
        }

        public async Task<Object> GetVehicleFilters()
        {
            var values = await _context.VehicleDetail.Select(x => new { x.Brand, x.Type, x.FuelType, x.Transmission }).ToListAsync();
            return values;
        }
    }
}
