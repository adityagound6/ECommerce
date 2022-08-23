using ECommerce.API.Helper;
using ECommerce.Service.Interfaces;
using ECommerce.Service.ModelVM;
using Microsoft.AspNetCore.Mvc;
using ECommerce.DAL.Model;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Options;
using ECommerce.API.Model;

namespace ECommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _category;
        private readonly GeneralMessages _message;
        public CategoryController(ICategoryService category, IOptions<GeneralMessages> message)
        {
            _category = category;
            _message = message.Value;
        }
        [HttpPost]
        [Route("AddCategory")]
        public async Task<IActionResult> AddCategory(CreateCategory model)
        {
            GeneralResultAdd<CategoryVm> result = new GeneralResultAdd<CategoryVm>();
            try
            {
                if (!ModelState.IsValid)
                {
                    var list = await _category.GetAll();
                    foreach(var categoryL in list)
                    {
                        if(categoryL.CategoryName.ToLower() == model.CategoryName.ToLower())
                        {
                            result.isSucces = false;
                            result.Message = _message.ApiName.Category + _message.Already.AlreadyExit;
                            return Ok(result);
                        }
                    }
                    Category category = new Category()
                    {
                        CategoryName =model.CategoryName,
                        CreateDateTime = DateTime.Now,
                        LastUpdateDatetime =DateTime.Now
                    };
                    await _category.Add(category);
                    result.isSucces = true;
                    result.Message = _message.ApiName.Category + _message.Create.Success;
                }
                else
                {
                    result.Message = _message.ApiName.Category + _message.Create.NotSuccess;
                    result.isSucces = false;
                    var message = string.Join(" | ", ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage)).ToList();
                    var error = ModelState.Values.SelectMany(v => v.Errors).ToList();
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
                result.isSucces = false;
                result.Message = _message.ServerError.Error;
            }
            return Ok(result);
        }
        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> AllCategory()
        {
            GeneralResultList<List<Category>> result = new GeneralResultList<List<Category>>();
            try
            {
                var CategoryList = await _category.GetAll();
                result.isSuccess = true;
                result.Result = CategoryList;
                result.Message = _message.ListData.SuccessList;
            }
            catch(Exception ex)
            {
                result.isSuccess = false;
                result.Message = _message.ServerError.Error + ex.Message;
            }
            return Ok(result);
        }
        [HttpPost]
        [Route("Update")]
        public async Task<IActionResult> UpdateCategory(UpdateCategory model)
        {
            GeneralResultAdd<Category> result = new GeneralResultAdd<Category>();
            try
            {
                if (!ModelState.IsValid)
                {
                    var category = await _category.GetById(model.CategoryId);
                    if(category == null)
                    {
                        result.isSucces = false;
                        result.Message = _message.ApiName.Category + _message.Update.NotExit;
                    }
                    else
                    {
                        category.CategoryName = model.CategoryName;
                        await _category.Update(category);
                        result.isSucces = true;
                        result.Message = _message.ApiName.Category + _message.Update.Updated;
                    }
                }
                else
                {
                    result.isSucces = false;
                    result.Message = _message.ApiName.Category + _message.Update.NotUpdated;
                    var error = ModelState.Values.SelectMany(v => v.Errors).ToList();
                    foreach(var modelState in ModelState.Values)
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
                result.isSucces = false;
                result.Message = _message.ServerError.Error + ex.Message;
            }
            return Ok(result);
        }
        [Route("Delete")]
        [HttpPost]
        public async Task<IActionResult> Delete(DeleteCategory model)
        {
            GeneralResultAdd<Category> result = new GeneralResultAdd<Category>();
            try
            {
                if (!ModelState.IsValid)
                {
                    var data = await _category.GetById(model.CategoryId);
                    if(data == null)
                    {
                        result.isSucces = false;
                        result.Message = _message.ApiName.Category + _message.Update.NotExit;
                    }
                    else
                    {
                        await _category.Delete(data);
                    }
                }
                else
                {
                    result.isSucces = false;
                    result.Message = _message.ApiName.Category + _message.Delete.NotDeleted;
                    var error = ModelState.Values.SelectMany(v => v.Errors).ToList();
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
                result.isSucces = false;
                result.Message = _message.ServerError.Error + ex.Message;
            }
            return Ok(result);
        }
        [Route("GetById")]
        [HttpGet]
        public async Task<IActionResult> GetById(int id)
        {
            GeneralResultList<Category> result = new GeneralResultList<Category>();
            try
            {
                var category = await _category.GetById(id);
                if (category != null)
                {
                    result.isSuccess = true;
                    result.Result = category;
                    result.Message = _message.ListData.SuccessList;
                }
                else
                {
                    result.isSuccess = false;
                    result.Message = _message.Update.NotExit;
                }
            }
            catch(Exception ex)
            {
                result.isSuccess = false;
                result.Message = _message.ServerError + ex.Message;
            }
            return Ok(result);
        }
    }
}
