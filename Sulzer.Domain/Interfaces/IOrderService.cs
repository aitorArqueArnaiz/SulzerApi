using Sulzer.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sulzer.Domain.Interfaces
{
    public interface IOrderService
    {
        Task<Price> CalculateOrderTotalPriceAsync(IEnumerable<Order> orders);
    }
}
