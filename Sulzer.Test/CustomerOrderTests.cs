using FluentAssertions;
using Moq;
using Sulzer.Domain.Entities;
using Sulzer.Domain.Interfaces;
using Sulzer.Domain.Services;

namespace Sulzer.Test
{
    public class CustomerOrderTests
    {
        private readonly IOrderService _orderService;

        public CustomerOrderTests()
        {
            _orderService = new OrderService();
        }

        [Fact]
        public async void Test_When_Discount_Is_Applyed_To_Mouse_Item_And_Total_Is_greater_Than_100()
        {
            // arrange
            var order = new Domain.Models.CustomerOrder() { Items = new Dictionary<string, OrderItem>
            {
                {"Laptop", new OrderItem(1, new Price(1000.00M, 1000.00M)) },
                {"Mouse", new OrderItem(3, new Price(25.00M, 25.00M)) },
                {"Keyboard", new OrderItem(2, new Price(50.00M, 50.00M)) }
            }
        };

            // act
            var response = await _orderService.CalculateOrderTotalPriceAsync(order);

            // assert
            response.Should().NotBeNull();
            response.Net.Should().Be(1109.125000M);
            response.Gross.Should().Be(1175.00M);

        }

        [Fact]
        public async void Test_When_Discount_Is_Applyed_To_All_Items_And_Total_Is_greater_Than_100()
        {
            // arrange
            var order = new Domain.Models.CustomerOrder()
            {
                Items = new Dictionary<string, OrderItem>
            {
                {"Laptop", new OrderItem(3, new Price(1000.00M, 1000.00M)) },
                {"Mouse", new OrderItem(3, new Price(25.00M, 25.00M)) },
                {"Keyboard", new OrderItem(3, new Price(50.00M, 50.00M)) }
            }
            };

            // act
            var response = await _orderService.CalculateOrderTotalPriceAsync(order);

            // assert
            response.Should().NotBeNull();
            response.Net.Should().Be(2757.375000M);
            response.Gross.Should().Be(3225.00M);

        }

        [Fact]
        public async void Test_When_TotalPrice_Is_Exactly_100()
        {
            // arrange
            var order = new Domain.Models.CustomerOrder()
            {
                Items = new Dictionary<string, OrderItem>
            {
                {"Laptop", new OrderItem(1, new Price(1000.00M, 1000.00M)) },
            }
            };

            // act
            var response = await _orderService.CalculateOrderTotalPriceAsync(order);

            // assert
            response.Should().NotBeNull();
            response.Net.Should().Be(1000.00M);
            response.Gross.Should().Be(1000.00M);

        }
    }
}