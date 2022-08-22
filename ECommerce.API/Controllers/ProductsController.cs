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
                        var product = _product.Any(x => x.ProductName.ToLower() == model.ProductName.ToLower() && x.Category.CategoryId == model.CategoryId);
                        if (product)
                        {
                            result.isSucces = false;
                            result.Message = _message.ApiName.Product + _message.Create.NotSuccess;
                        }
                        else
                        {
                            await _product.Add(model.ToCreateDbModel());
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
    }
}
