using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ShowWatch.Models
{
    public class SqlProductRepositoty : IProductRepository
    {
        private readonly AppDbContext context;

        public SqlProductRepositoty(AppDbContext context)
        {
            this.context = context;
        }

        public Product Create(Product product)
        {
            context.products.Add(product);
            context.SaveChanges();
            return product;
        }

        public bool Delete(int id)
        {
            var delPro = context.products.Find(id);
            if (delPro != null)
            {
                context.products.Remove(delPro);
                return context.SaveChanges() > 0;
            }
            return false;
        }

        public Product Edit(Product product)
        {
            var editPro = context.products.Attach(product);
            editPro.State = EntityState.Modified;
            context.SaveChanges();
            return product;
        }

        public Product Get(int id)
        {
            return context.products.Find(id);
        }

        public IEnumerable<Product> Gets()
        {
            return context.products;
        }
    }
}