using ECommerce.API.Helper;
using ECommerce.DAL.Model;
using ECommerce.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace ECommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _order;
        private readonly GeneralMessages _message;
        public OrderController(IOrderService order,IOptions<GeneralMessages> options)
        {
            _order = order;
            _message = options.Value;
        }
        [HttpPost]
        [Route("Create")]
        public IActionResult Create()
        {
            GeneralResultAdd<Order> result = new GeneralResultAdd<Order>();
            try
            {

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
