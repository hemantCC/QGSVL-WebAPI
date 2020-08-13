using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QGSVL.BusinessLogicLayer.Interfaces;
using QGSVL.EntityLayer.Data;
using QGSVL.EntityLayer.Entities.BusinessEntity;
using QGSVL_WebAPI.Models.DataEntities;

namespace QGSVL.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly IVehicleService _vehicleService;
        public VehicleController(IVehicleService vehicleService)
        {
            _vehicleService = vehicleService;
        }

        [HttpGet]
        [Route("GetVehicles")]
        public async Task<IActionResult> GetVehicles()
        {
            IEnumerable<VehicleDetail> vehicles = await _vehicleService.GetVehicles();
            if (vehicles == null)
            {
                return NotFound();
            }
            return Ok(vehicles);
        }

        [HttpGet]
        [Route("GetVehicle")]
        public async Task<IActionResult> GetVehicle(int id)
        {
            VehicleDetailVM vehicleDetail = await _vehicleService.GetVehicle(id);
            if (vehicleDetail.Vehicle == null || vehicleDetail.MainEquipments == null || vehicleDetail.StandardEquipments == null)
            {
                return NotFound("Data not found!");
            }
            return Ok(vehicleDetail);
        }

        [HttpGet]
        [Route("GetVehicleFilters")]
        public async Task<IActionResult> GetVehicleFilters()
        {
            var values = await _vehicleService.GetVehicleFilters();
            if (values == null)
            {
                return NotFound();
            }
            return Ok(values);
        }
    }
}