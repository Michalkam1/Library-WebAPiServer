﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ClientWebApp.Models
{
    public enum Statuses { available, unavailable, reserved };

    public class Status
    {
        public int Id { get; set; }
        public Statuses Statuses { get; set; }
    }
}
