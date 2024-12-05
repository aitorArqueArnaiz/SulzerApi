using Sulzer.Domain.Entities;

namespace SulzerApi.DTOs.Request
{
    public class CustomerOrderRequest
    {
        public IEnumerable<Order> Orders { get; set; }
    }
}
