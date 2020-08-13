using System;
using System.Collections.Generic;
using System.Text;
using QGSVL_WebAPI.Models.DataEntities;

namespace QGSVL.EntityLayer.Entities.BusinessEntity
{
    public class VehicleDetailVM
    {
        public VehicleDetail Vehicle { get; set; }
        public string[] MainEquipments { get; set; }
        public string[] StandardEquipments { get; set; }
        public string[] IncludedServices { get; set; }
    }
}
