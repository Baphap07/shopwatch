using System;
using System.Collections.Generic;
using System.Linq;

namespace ShowWatch.Models
{
    public class ProductRepository : IProductRepository
    {
        private List<Product> products;
        public ProductRepository()
        {
            products = new List<Product>()
            {
                new Product()
                {
                    Id=1,
                    Name="Cityzen E5",
                    Brand="CITYZEN",
                    Radius= "36mm",
                    Thickness= "5mm",
                    Cord = "leather",
                    Glasses = "Sapphire",
                    water_proof= "3 ATM",
                    Guarantee= "2 Year",
                    Avatar="img/anh1.jpg",
                    Price=5000000

                },
                  new Product()
                {
                    Id=2,
                    Name="Casio M2",
                    Brand="CITYZEN",
                    Radius= "36mm",
                    Thickness= "5mm",
                    Cord = "leather",
                    Glasses = "Sapphire",
                    water_proof= "3 ATM",
                    Guarantee= "2 Year",
                    Avatar="img/anh2.jpg",
                    Price = 6000000
                }


            };
        }

        public Product Create(Product product)
        {
            product.Id = products.Max(e => e.Id) + 1;
            product.Avatar = "img/anh2.jpg";
            products.Add(product);
            return product;
        }

        public bool Delete(int id)
        {
            var delPro = Get(id);
            if (delPro != null)
            {
                products.Remove(delPro);
                return true;
            }
            return false;
        }

        public Product Edit(Product product)
        {
            var ediPro = Get(product.Id);
            ediPro.Name = product.Name;
            ediPro.Brand = product.Brand;
            ediPro.Radius = product.Radius;
            ediPro.Thickness = product.Thickness;
            ediPro.Glasses = product.Glasses;
            ediPro.Cord = product.Cord;
            ediPro.Guarantee = product.Guarantee;
            ediPro.Price = product.Price;
            return ediPro;
        }

        public Product Get(int id)
        {
            return products.FirstOrDefault(e => e.Id == id);
        }

        public IEnumerable<Product> Gets()
        {
            return products;
        }
    }
}
