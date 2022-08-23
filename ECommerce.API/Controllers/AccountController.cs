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
    public class AccountController : ControllerBase
    {
        private readonly ICustomerService _customer;
        private readonly GeneralMessages _message;
        public AccountController(ICustomerService customer, IOptions<GeneralMessages> options)
        {
            _customer = customer;
            _message = options.Value;
        }
        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create(CreateCustomer model)
        {
            GeneralResultAdd<Customer> result = new GeneralResultAdd<Customer>();
            try
            {
                if (ModelState.IsValid)
                {
                    var isEmailExit = _customer.Any(x=>x.Email == model.Email);
                    if (!isEmailExit)
                    {
                        HashPassword hashPassword = new HashPassword();
                        var password = hashPassword.hashpassword(model.Password);
                        model.Password = password;
                        Customer customer = new Customer()
                        {
                            DisplayName = model.CustomerFirstName + " " + model.CustomerlastName,
                            CustomerFirstName = model.CustomerFirstName,
                            CustomerlastName = model.CustomerlastName,
                            Email = model.Email,
                            Password = password,
                            Role = 0
                        };
                        await _customer.Add(customer);
                        result.Message = _message.ApiName.Customer + _message.Create.Success;
                        result.isSucces = true;
                    }
                    else
                    {
                        result.isSucces = false;
                        result.Message = _message.ApiName.Customer + _message.Already.AlreadyExit;
                        result.ValidationError.Add(result.Message);
                    }
                }
                else
                {
                    result.isSucces = false;
                    result.Message = _message.ApiName.Customer + _message.Create.NotSuccess;
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
        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            GeneralResultList<List<Customer>> result = new GeneralResultList<List<Customer>>();
            try
            {
                var customer = await _customer.GetAll();
                result.Result = customer;
                result.isSuccess = true;
                result.Message = _message.ApiName.Customer + _message.ListData.SuccessList;
            }
            catch(Exception ex)
            {
                result.isSuccess = false;
                result.Message = _message.ServerError.Error + ex.Message;
            }
            return Ok(result);
        }
    }
}
