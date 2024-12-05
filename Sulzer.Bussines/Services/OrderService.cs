using Sulzer.Domain.Entities;
using Sulzer.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sulzer.Domain.Services
{
    public class OrderService : IOrderService
    {
        public async Task<Price> CalculateOrderTotalPriceAsync(IEnumerable<Order> orders)
        {
            throw new NotImplementedException();
        }
    }
}
