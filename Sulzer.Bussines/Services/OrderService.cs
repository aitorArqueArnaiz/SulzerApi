using Sulzer.Domain.Entities;
using Sulzer.Domain.Interfaces;
using Sulzer.Domain.Models;

namespace Sulzer.Domain.Services
{
    public class OrderService : IOrderService
    {
        private readonly decimal TotalForDiscount = 1000.00M;
        private readonly decimal ItemDiscount = 0.10M;
        private readonly decimal TotalPriceDiscount = 0.05M;

        public async Task<Price> CalculateOrderTotalPriceAsync(CustomerOrder order)
        {
            Price totalOrderPrice = new Price(0.0M, 0.0M);
            totalOrderPrice.Gross = order.Items.Sum(x => x.Value.UnitPrice.Gross * x.Value.Quantity);
            if (order == null || !order.Items.Any())
            {
                throw new ArgumentNullException("Null order");
            }

            // Check if the number of items in order is major than three elements.
            foreach (var item in order.Items)
            {
                if (item.Value.Quantity >= 3)
                {
                    totalOrderPrice.Net += (item.Value.UnitPrice.Gross * item.Value.Quantity) 
                        - (ItemDiscount * (item.Value.UnitPrice.Gross * item.Value.Quantity));
                }
                else
                {
                    totalOrderPrice.Net += (item.Value.UnitPrice.Gross * item.Value.Quantity);
                }
            }

            if (totalOrderPrice.Gross > TotalForDiscount)
            {
                totalOrderPrice.Net = totalOrderPrice.Net - (totalOrderPrice.Net * TotalPriceDiscount);
                return totalOrderPrice;
            }

            return totalOrderPrice;
        }
    }
}
