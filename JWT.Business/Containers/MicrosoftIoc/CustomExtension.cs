using FluentValidation;
using Jwt.DataAccess.Concrete.EntityFrameworkCore.Repositories;
using Jwt.DataAccess.Interfaces;
using JWT.Business.Concrete;
using JWT.Business.Interfaces;
using JWT.Business.ValidationRules.FluentValidation;
using JWT.Entities.Dtos.AppUserDtos;
using JWT.Entities.Dtos.ProductDtos;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace JWT.Business.Containers.MicrosoftIoc
{
    public static class CustomExtension
    {
        public static void AddDependencies(this IServiceCollection services)
        {
            services.AddScoped<IProductDal, EfProductRepository>();
            services.AddScoped<IProductService, ProductManager>();

            services.AddScoped<IAppUserDal, EfAppUserRepository>();
            services.AddScoped<IAppUserService, AppUserManager>();

            services.AddScoped<IAppRoleDal, EfAppRoleRepository>();
            services.AddScoped<IAppRoleService, AppRoleManager>();

            services.AddScoped<IAppUserRoleDal, EfAppUserRoleRepository>();
            services.AddScoped<IAppUserRoleService, AppUserRoleManager>();

            services.AddScoped<IJwtService, JwtManager>();

            services.AddTransient<IValidator<AppUserLoginDto>, AppUserLoginDtoValidator>();
            services.AddTransient<IValidator<AppUserAddDto>, AppUserAddDtoValidator>();
            services.AddTransient<IValidator<ProductAddDto>, ProductAddDtoValidator>();
        

        }
    }
}
