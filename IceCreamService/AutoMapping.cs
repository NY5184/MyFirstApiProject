using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using DTO;

namespace IceCreamStoreService
{
   public  class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<User, UserDTO>();
            CreateMap<UserDTO, User>();
            CreateMap<UserLogin, UserLoginDTO>().ReverseMap();
            CreateMap<Category, CategoryDTO>().ReverseMap();
            CreateMap<Order, OrderDTO>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.UserName))
                .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.TheOrderItems));
            CreateMap<OrderDTO, Order>()
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))
                .ForMember(dest => dest.TheOrderItems, opt => opt.MapFrom(src => src.Items))
                .ForMember(dest => dest.User, opt => opt.Ignore()); // עדיין נחוץ

            CreateMap<TheOrderItem, OrderItemDTO>().ReverseMap();
                
            CreateMap<Product, ProductDTO>()
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.CategoryName)).ReverseMap();


        }
      
        
    }

    
}
