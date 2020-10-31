using AutoMapper;
using JWT.Business.ValidationRules.FluentValidation;
using JWT.Entities.Concrate;
using JWT.Entities.Dtos.ProductDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JWT.UI.Mapping.AutoMapperProfile
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<ProductAddDto, Product>();
            CreateMap<Product, ProductAddDto>();

            CreateMap<AppUserAddDto, AppUser>();
            CreateMap<AppUser, AppUserAddDto>();
        }
    }
}
