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
        public async Task<Price> CalculateOrderTotalPriceAsync(CustomerOrder order)
        {
            Price totalOrderPrice = new Price();
            totalOrderPrice.Gross = order.Items.Sum(x => x.Value.UnitPrice.Net);
            if (order == null)
            {
                throw new ArgumentNullException("Null order");
            }
            if (totalOrderPrice.Gross > 100.0M)
            {
                totalOrderPrice.Net = totalOrderPrice.Gross * 0.05M;
                return totalOrderPrice;
            }

            // Check if the number of items in order is major than three elements.
            int numberOfSameItem = 0;
            var totalprice = new Price() { Gross = totalOrderPrice.Gross };
            decimal price = 0.0M;
            foreach (var item in order.Items)
            {
                numberOfSameItem = order.Items.ToLookup(x => x.Key == item.Key).Count;
                if (numberOfSameItem >= 3) 
                {
                    price += item.Value.UnitPrice.Gross * 0.10M;
                }
                else
                {
                    price = item.Value.UnitPrice.Gross;
                }
            }
            totalprice.Net = price;
            return totalprice;
        }
    }
}
