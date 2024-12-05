using Sulzer.Domain.Entities;
using Sulzer.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sulzer.Domain.Interfaces
{
    public interface IOrderService
    {
        Task<Price> CalculateOrderTotalPriceAsync(CustomerOrder order);
    }
}
