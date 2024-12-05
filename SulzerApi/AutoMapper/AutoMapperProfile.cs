using AutoMapper;
using Sulzer.Domain.Models;
using SulzerApi.DTOs.Request;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<CustomerOrderRequest, CustomerOrder>();
    }
}