using System;
using System.Collections.Generic;

namespace ShowWatch.Models
{
    public interface IProductRepository
    {
        IEnumerable<Product> Gets();
        Product Get(int id);
        Product Create(Product product);
        Product Edit(Product product);
        bool Delete(int id);
    }
}
