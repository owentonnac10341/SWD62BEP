using Microsoft.Extensions.DependencyInjection;
using ShoppingCart.Application.Interfaces;
using ShoppingCart.Application.Services;
using ShoppingCart.Data.Repositories;
using ShoppingCart.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.IOC
{
    public class DependencyContainer
    {
        public static void RegisterService(IServiceCollection service) 
        {
            service.AddScoped<IProductsRepositroy, ProductRepository>();
            service.AddScoped<IProductsService, ProductsService>();
        }
    }
}
