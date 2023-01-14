using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entities.Concrete;

using System;
using DataAccess.Concrete.EntityFramework;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //CategoryService categoryService = new CategoryService(new EfCategoryDal());

            //foreach (var cate in categoryService.GetAll())
            //{
            //    Console.WriteLine(cate.CategoryName);
            //}
            
            //ProductManager productManager = new ProductManager(new EfProductDal());
            //foreach (var product in productManager.GetByUnitPrice(50, 100))
            //{
            //    Console.WriteLine(product.ProductName);
            //}

            
            //ProductManager productManager1 = new ProductManager(new EfProductDal());

            //var result = productManager1.GetProductDetails();

            //if (result.Success == true)
            //{
            //    foreach (var product in result.Data)
            //    {
            //        Console.WriteLine(product.ProductName + "/" + product.CategoryName);

            //    }
            //}
            //else
            //{
            //    Console.WriteLine(result.Message);
            //}

            //Console.WriteLine("Hello World!");
            //Console.ReadLine();
        }
    }
}
