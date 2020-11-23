using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ShoppingCart.Application.Interfaces;
using ShoppingCart.Application.Services;
using ShoppingCart.Data.Context;
using ShoppingCart.Data.Repositories;
using ShoppingCart.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace ShoppingCart.IOC
{
    public class DependencyContainer
    {
        public static void RegisterService(IServiceCollection service, string connectionString) 
        {

            service.AddDbContext<ShoppingCartDPContext>(options =>
            options.UseSqlServer(connectionString));

            service.AddScoped<IProductsRepositroy, ProductRepository>();
            service.AddScoped<IProductsService, ProductsService>();
        }
    }
}
