using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library_WebAPiServer.Models
{
    public enum Statuses { available, unavailable, reserved };

    public class StatusDTO
    {
        public int Id { get; set; }
        public Statuses Statuses { get; set; }
    }
}
