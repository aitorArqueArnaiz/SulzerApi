using Sulzer.Domain.Entities;

namespace SulzerApi.DTOs.Request
{
    public class CustomerOrderRequest
    {
        public IDictionary<string, OrderItem> Items { get; set; }
    }
}
