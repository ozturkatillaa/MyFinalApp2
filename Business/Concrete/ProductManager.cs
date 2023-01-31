using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.CCS;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class ProductManager:IProductService
    {
        IProductDal _productDal;
        ICategoryService _categoryService;
        //ILogger _logger;
        public ProductManager(IProductDal productDal, ICategoryService categoryService) //,ILogger logger)
        {
            _productDal = productDal;
            _categoryService = categoryService;
            //_logger = logger;
        }

        [SecuredOperation("admin,product.add")]
        [ValidationAspect(typeof(ProductValidator))]// validation yerine(3) 3.aşama
        [CacheRemoveAspect("IProductService.Get")]
        public IResult Add(Product product)
        {

            //bunun yerine validationrules koyduk aşağıda
            //if (product.ProductName.Length<2)
            //{
            //    //magic strings
            //    return new ErrorResult(Messages.ProductNameValid);
            //} iften başlayarak buraya kadar ilk(1)


            //ValidationTool.Validate(new ProductValidator(),product); // BUNUN YERİNE ATTRİBUTE ASPECTS EKLEDİK METHODUN BAŞINDA
            // validation (2)

            //////////////////////////////////4.aşama üstteki alanı aspectleri aktif ettik atribute olrak burayı yoruma aldık
            //_logger.Log();
            //try
            //{
            //    _productDal.Add(product);

            //    //return new Result(true,"Eklendi");
            //    return new SuccessResult(Messages.ProductAdded);
            //}
            //catch (Exception exception) 
            //{

            //    _logger.Log();
            //}
            //return new ErrorResult();
            //-----------------------------------------------------------------------//
            // aşağıya genel başka işlemler için de geçerli olsun diye private olarak normalde orada bulunan işlemler buradaydı
            //temiz iş kuralları nasıl yazılır buna biir örnek

            //if (CheckIfProductCountOfCategoryCorrect(product.CategoryId).Success)
            //{
            //    if (CheckIfProductNameExists(product.ProductName).Success)
            //    {
            //        _productDal.Add(product);

            //        return new SuccessResult(Messages.ProductAdded);
            //    }
            //}
            //return new ErrorResult();

            //--------------------------------------------------------------------------------
            //business rules olarak IRESULT şeklinde gönderim yapıldığı zaman bu şekilde 6.durum
            //---------------------------------------------------------------------------------
            //bunun avantajı yarın yeni kural geldi eklemek kolay olur  

            IResult result = BusinessRules.Run(CheckIfProductCountOfCategoryCorrect(product.CategoryId), CheckIfProductNameExists(product.ProductName)
                ,CheckIfCategoryLimitExceded());

            if (result != null)
            {
                return result;
            }

            _productDal.Add(product);

            return new SuccessResult(Messages.ProductAdded);


        }

        [CacheAspect]
        public IDataResult<List<Product>> GetAll()
        {

            if (DateTime.Now.Hour==20)
            {
                return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);

            }

            return new SuccessDataResult<List<Product>>(_productDal.GetAll(),Messages.ProductListed);
        }

        public IDataResult<List<Product>> GetAllByCategoryId(int id)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.CategoryId == id));
        }

        [CacheAspect]
        //[PerformanceAspect(5)]
        public IDataResult<Product> GetById(int ProductId)
        {
            return new SuccessDataResult<Product>(_productDal.Get(p=>p.ProductId==ProductId));
        }

        public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p=>p.UnitPrice>=min && p.UnitPrice<=max ));
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetails()
        {
            if (DateTime.Now.Hour == 20)
            {
                return new ErrorDataResult<List<ProductDetailDto>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetProductDetails());
        }

        [ValidationAspect(typeof(ProductValidator))]
        [CacheRemoveAspect("IProductService.Get")]
        public IResult Update(Product product)
        {
            IResult result = BusinessRules.Run(CheckIfProductCountOfCategoryCorrect(product.CategoryId));

            if (result!=null)
            {
                return result;
            }

            _productDal.Add(product);

            return new SuccessResult(Messages.ProductAdded);
        }

        private IResult CheckIfProductCountOfCategoryCorrect(int categoryId)
        {
            //id olarak algılıyor "categoryId", 10 dan fazla olmayınca oluyor ("categoryId": 5,) //bir kategoride maksimum 10 ürün olabilir
            var result = _productDal.GetAll(p => p.CategoryId == categoryId).Count;
            if (result >= 10)
            {
                return new ErrorResult(Messages.ProductCountofCategoryError);
            }

            return new SuccessResult();
        } 
        private IResult CheckIfProductNameExists(string productName)
        {
            var result = _productDal.GetAll(p => p.ProductName == productName).Any();
            if (result)
            {
                return new ErrorResult(Messages.ProductNameAlreadyExists);
            }

            return new SuccessResult();
        }

        private IResult CheckIfCategoryLimitExceded()
        {
            var result = _categoryService.GetAll();
            if (result.Data.Count>15)
            {
                return new ErrorResult(Messages.CategoryLimitExceded);
            }
            return new SuccessResult();
        }

        //[TransactionScopeAspect]
        public IResult AddTransactionalTest(Product product)
        {
            Add(product);
            if (product.UnitPrice < 10)
            {
                throw new Exception("");
            }
            Add(product);
            return null;
        }
    }
}
