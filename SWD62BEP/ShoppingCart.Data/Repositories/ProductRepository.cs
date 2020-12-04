using Microsoft.EntityFrameworkCore;
using ShoppingCart.Data.Context;
using ShoppingCart.Domain.Interfaces;
using ShoppingCart.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoppingCart.Data.Repositories
{
    public class ProductRepository : IProductsRepositroy
    {

        ShoppingCartDPContext _context;

        public ProductRepository(ShoppingCartDPContext context)
        {
            _context = context;
        }
        public Guid AddProduct(Product p)
        {
            _context.products.Add(p);
            _context.SaveChanges();
            return p.Id;
        }

        public void DeleteProduct(Product p)
        {
            _context.products.Remove(p);
            _context.SaveChanges();
        }

       /* public void DisableProduct(Guid id) 
        {

            var p = GetProduct(id);
            p.Disable = true;
            _context.SaveChanges();

        }*/

        public Product GetProduct(Guid id)
        {
            //Single or default will return ONE product or null
            return _context.products.SingleOrDefault(x => x.Id == id);
        }
      
        public IQueryable<Product> GetProducts()
        {
            return _context.products;
        }
    }
}
