using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using SmartHouse;

namespace SmartHouseMVC.Models.DeviceManager
{
    public class DeviceTableRow
    {
        public DeviceTableRow() { }


        public int Id { get; set; }
        [Required]
        public int DeviceTypeId { get; set; }

        public int? ClockId { get; set; }
        public virtual Clock Clock { get; set; }

        public int? MicrowaveId { get; set; }
        public virtual Microwave Microwave { get; set; }

        public int? OvenId { get; set; }
        public virtual Oven Oven { get; set; }

        public int? FridgeId { get; set; }
        public virtual Fridge Fridge { get; set; }
    }
}