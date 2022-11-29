using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products;

        public InMemoryProductDal()
        {
            _products = new List<Product>() {
                new Product{ProductId=5,CategoryId=5,ProductName="bardak",UnitPrice=15,UnitsInStock=1},
                new Product{ProductId=15,CategoryId=15,ProductName="masa",UnitPrice=15,UnitsInStock=12},
                new Product{ProductId=25,CategoryId=25,ProductName="sandalye",UnitPrice=15,UnitsInStock=15},
                new Product{ProductId=35,CategoryId=35,ProductName="kagit",UnitPrice=15,UnitsInStock=19},
                new Product{ProductId=45,CategoryId=45,ProductName="kalem",UnitPrice=15,UnitsInStock=21}


            };
        }

        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
            //Product productToDelete=null;

            //foreach (var p  in _products) linq  olmasaydı
            //{
            //    if (product.ProductId==p.ProductId)
            //    {
            //        productToDelete = p;
            //    }
            //}
            Product productToDelete = _products.SingleOrDefault(p=>p.ProductId==product.ProductId);
            _products.Remove(productToDelete);

        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public List<Product> GetAllByCategory(int categoryId)
        {
            return _products.Where(p => p.CategoryId == categoryId).ToList();
        }

        public void Update(Product product)
        {
            Product productToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            productToUpdate.ProductId = product.ProductId;
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.CategoryId = product.CategoryId;
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.UnitsInStock = product.UnitsInStock;
        }
    }
}
