﻿using Sulzer.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sulzer.Domain.Models
{
    public class CustomerOrder
    {
        public IDictionary<string, OrderItem> Items { get; set; }

    }
}
