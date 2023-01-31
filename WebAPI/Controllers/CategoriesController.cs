using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;


namespace WebAPI.Controllers
{

        [Route("api/[controller]")]
        [ApiController]

        public class CategoriesController : ControllerBase
        {
            //loosley coupled
            //naming convention
            ICategoryService _categoryService;

            public CategoriesController(ICategoryService categoryService)
            {
                _categoryService = categoryService;
            }


            [HttpGet("getall")]
            public IActionResult Get()
            //https://localhost:44350/api/products/getall
            {
                //return new List<Product>
                //{
                //    new Product{ProductId=1,ProductName="elma"},
                //    new Product{ProductId=2,ProductName="armut"}
                //};

                //dependency chain
                //IProductService productService = new ProductManager(new EfProductDal());

                Thread.Sleep(1000);

                var result = _categoryService.GetAll();
                if (result.Success)
                {
                    return Ok(result);
                }

                return BadRequest(result);
            }

            [HttpGet("getbyid")]

            public IActionResult Get(int Id)
            {
                var result = _categoryService.GetById(Id);
                if (result.Success)
                {
                    return Ok(result);
                }
                return BadRequest(result);
            }

        }
    
}
