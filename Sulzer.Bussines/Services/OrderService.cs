using Sulzer.Domain.Entities;
using Sulzer.Domain.Interfaces;
using Sulzer.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sulzer.Domain.Services
{
    public class OrderService : IOrderService
    {
        public Task<Price> CalculateOrderTotalPriceAsync(CustomerOrder order)
        {
            throw new NotImplementedException();
        }
    }
}
