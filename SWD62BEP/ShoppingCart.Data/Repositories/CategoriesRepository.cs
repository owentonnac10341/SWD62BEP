using ShoppingCart.Domain.Interfaces;
using ShoppingCart.Data.Context;
using ShoppingCart.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoppingCart.Data.Repositories
{
    public class CategoriesRepository : ICategoriesRepository
    {
        ShoppingCartDPContext _context;

        public CategoriesRepository(ShoppingCartDPContext context) 
        {
            _context = context;
        }

        public IQueryable<Category> GetCategories()
        {
           return _context.categories;
        }
    }
}
