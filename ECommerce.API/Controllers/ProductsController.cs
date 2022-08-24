using ECommerce.API.Helper;
using ECommerce.API.Model;
using ECommerce.DAL.Model;
using ECommerce.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace ECommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly GeneralMessages _message;
        private readonly IProductService _product;
        private readonly ICategoryService _categoy;
        public ProductsController(IOptions<GeneralMessages> message,IProductService product, ICategoryService categoy)
        {
            _message = message.Value;
            _product = product;
            _categoy = categoy;
        }
        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> AddProduct(CreateProduct model)
        {
            GeneralResultAdd<Product> result = new GeneralResultAdd<Product>();
            try
            {
                if (ModelState.IsValid)
                {
                    var category = _categoy.Any(x => x.CategoryId == model.CategoryId);
                    if (category)
                    {
                        var product = _product.Any(x => x.ProductName.ToLower() == model.ProductName.ToLower() && x.CategoryId == model.CategoryId);
                        if (product)
                        {
                            result.isSucces = false;
                            result.Message = _message.ApiName.Product + _message.Create.NotSuccess;
                        }
                        else
                        {
                            Product productToAdd = new Product()
                            {
                                MainPrice = model.Price,
                                Description = model.Description,
                                Image = model.Image,
                                ProductName = model.ProductName,
                                CategoryId = model.CategoryId,
                                ActualPrice = model.Price,
                                DiscountPrice = 0,
                                CreateDateTime = DateTime.Now,
                                LastUpdateDatetime = DateTime.Now,
                            };
                            var check = await _product.Add(productToAdd);
                            result.isSucces = true;
                            result.Message = _message.ApiName.Product + _message.Create.Success;
                        }
                    }
                    else
                    {
                        result.isSucces = false;
                        result.Message = _message.Update.NotExit;
                    }
                }
                else
                {
                    result.isSucces = false;
                    result.Message = _message.ApiName.Product + _message.Create.NotSuccess;
                }
            }
            catch(Exception ex)
            {
                result.isSucces = false;
                result.Message = _message.ServerError.Error + ex.Message;
            }
            return Ok(result);
        }
        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            GeneralResultList<List<Product>> result = new GeneralResultList<List<Product>>(); 
            try
            {
                var product = await _product.GetAll();
                result.isSuccess = true;
                result.Message = _message.ListData.SuccessList;
                result.Result = product;
            }
            catch(Exception ex)
            {
                result.isSuccess = false;
                result.Message = _message.ServerError.Error + ex.Message;
            }
            return Ok(result);
        }
        [HttpGet]
        [Route("GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            GeneralResultList<Product> result = new GeneralResultList<Product>();
            try
            {
                var product = await _product.GetById(id);
                if(product != null)
                {
                    result.isSuccess = true;
                    result.Result = product;
                    result.Message = _message.ListData.SuccessList;
                }
                else
                {
                    result.isSuccess = false;
                    result.Message = _message.ListData.UnSuccessList;
                }
            }
            catch(Exception ex)
            {
                result.Message = _message.ServerError.Error + ex.Message; 
                result.isSuccess = false;
            }
            return Ok(result);
        }
        [HttpPost]
        [Route("Update")]
        public async Task<IActionResult> Update(UpdateProduct model)
        {
            GeneralResultAdd<Product> result = new GeneralResultAdd<Product>();
            try
            {
                if (ModelState.IsValid)
                {
                    var product = await _product.GetById(model.ProductId);
                    var category = _categoy.Any(x => x.CategoryId == model.CategoryId);
                    if (category)
                    {
                        if (product != null)
                        {
                            var discount = (model.DiscountPricePercentage / 100) * model.Price;
                            if (discount > 0)
                            {
                                product.ActualPrice = discount;
                            }
                            product.DiscountPrice = model.DiscountPricePercentage;
                            product.CategoryId = model.CategoryId;
                            product.Description = model.Description;
                            product.Image = model.Image;
                            product.ProductName = model.ProductName;
                            product.LastUpdateDatetime = DateTime.Now;
                            await _product.Update(product);
                            result.Message = _message.ApiName.Product + _message.Update.Updated;
                            result.isSucces = true;
                        }
                        else
                        {
                            result.isSucces = false;
                            result.Message = _message.ApiName.Product + _message.Update.NotExit;
                        }
                    }
                    else
                    {
                        result.isSucces = false;
                        result.Message = _message.ApiName.Category + _message.Update.NotExit;
                    }
                }
                else
                {
                    result.isSucces = false;
                    result.Message = _message.ApiName.Product + _message.Update.NotUpdated;
                    foreach (var modelState in ModelState.Values)
                    {
                        foreach (var validation in modelState.Errors)
                        {
                            result.ValidationError.Add(validation.ErrorMessage);
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                result.Message = _message.ServerError.Error + ex.Message;
                result.isSucces = false;
            }
            return Ok(result);
        }
        [Route("GetByCategoryId")]
        [HttpGet]
        public async Task<IActionResult> GetByCategoryId(int Categoryid)
        {
            GeneralResultList<List<Product>> result = new GeneralResultList<List<Product>>();
            try
            {
                var isCategory = _categoy.Any(x => x.CategoryId == Categoryid);
                if (isCategory)
                {
                    var product = (await _product.GetAll()).Where(x => x.CategoryId == Categoryid).ToList();
                    result.isSuccess = true;
                    result.Message = _message.ListData.SuccessList;
                    result.Result = product;
                }
                else
                {
                    result.isSuccess=false;
                    result.Message = _message.ApiName.Category + _message.Update.NotExit;
                }
            }
            catch(Exception ex)
            {
                result.isSuccess = false;
                result.Message=_message.ServerError.Error + ex.Message; 
            }
            return Ok(result);
        }
        [HttpPost]
        [Route("Delete")]
        public async Task<IActionResult> Delete(DeleteProduct model)
        {
            GeneralResultAdd<Product> result = new GeneralResultAdd<Product>();
            try
            {
                var product = await _product.GetById(model.ProductId);
                if(product != null)
                {
                    await _product.Delete(product);
                    result.isSucces = true;
                    result.Message = _message.ApiName.Product + _message.Delete.Deleted;
                }
                else
                {
                    result.isSucces = false;
                    result.Message = _message.ApiName.Product + _message.Delete.NotDeleted;
                }
            }
            catch(Exception ex)
            {
                result.isSucces = false;
                result.Message = _message.ServerError.Error + ex.Message;
            }
            return Ok(result);
        }
    }
}
