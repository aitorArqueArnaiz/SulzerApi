﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sulzer.Domain.Entities
{
    public class OrderItem
    {
        public int Quantity { get; set; }
        public required Price UnitPrice { get; set; }
    }
}
