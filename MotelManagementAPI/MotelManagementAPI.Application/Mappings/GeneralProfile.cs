using MotelManagementAPI.Application.Features.Products.Commands.CreateProduct;
using MotelManagementAPI.Application.Features.Products.Queries.GetAllProducts;
using AutoMapper;
using MotelManagementAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using MotelManagementAPI.Application.Features.RoomDetails.Queries.GetAllRoomDetails;
using MotelManagementAPI.Application.Features.RoomDetails.Commands.CreateRoomDetail;
using MotelManagementAPI.Application.Features.Customers.Queries.GetAllCustomer;
using MotelManagementAPI.Application.Features.Customers.Commands.CreateCustomer;

namespace MotelManagementAPI.Application.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            CreateMap<Product, GetAllProductsViewModel>().ReverseMap();
            CreateMap<RoomDetail, GetAllRoomDetailsViewModel>().ReverseMap();
            CreateMap<CustomerInfo, GetAllCustomersViewModel>().ReverseMap();
            CreateMap<CreateProductCommand, Product>();
            CreateMap<CreateRoomDetailCommand, RoomDetail>();
            CreateMap<CreateCustomerCommand, CustomerInfo>();
            CreateMap<GetAllProductsQuery, GetAllProductsParameter>();
            CreateMap<GetAllRoomDetailsQuery, GetAllRoomDetailsParameter>();
            CreateMap<GetAllCustomersQuery, GetAllCustomersParameter>();

        }
    }
}
