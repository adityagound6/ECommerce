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
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _order;
        private readonly IProductService _product;
        private readonly GeneralMessages _message;
        public OrderController(IOrderService order,IOptions<GeneralMessages> options, IProductService product)
        {
            _order = order;
            _message = options.Value;
            _product = product;
        }
        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create(CreateOrder model)
        {
            GeneralResultAdd<Order> result = new GeneralResultAdd<Order>();
            try
            {
                if (ModelState.IsValid)
                {
                    var orderNumber = DateTime.Now.ToString("MMddyyyyHHmmss");
                    orderNumber = orderNumber + model.CustomerId.ToString() + model.ProductId.ToString();
                    var productPrice = await _product.GetById(model.ProductId);
                    Order order = new Order()
                    {
                        Address = model.Address,
                        Status = model.Status,
                        CustomerId = model.CustomerId,
                        CreateDateTime = DateTime.Now,
                        LastUpdateDatetime = DateTime.Now,
                        date = DateTime.Now,
                        TotalPrice = productPrice.ActualPrice * model.Quantity,
                        Price = productPrice.ActualPrice,
                        ProductId = model.ProductId,
                        Quantity = model.Quantity,
                        MobileNumber = model.MobileNumber,
                        Pincode = model.Pincode,
                        OrderNumber = orderNumber
                    };
                    await _order.Add(order);
                    result.Message = _message.ApiName.Order + _message.Create.Success;
                    result.isSucces = true;
                }
                else
                {
                    result.isSucces = false;
                    result.Message = _message.ApiName.Order + _message.Create.NotSuccess;
                    foreach(var ModelState in ModelState.Values)
                    {
                        foreach(var validate in ModelState.Errors)
                        {
                            result.ValidationError.Add(validate.ErrorMessage);
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
        [HttpPost]
        [Route("Delete")]
        public async Task<IActionResult> Delete(DeleteOrder model)
        {
            GeneralResultAdd<Order> result = new GeneralResultAdd<Order>();
            try
            {
                if (ModelState.IsValid)
                {
                    var order = await _order.GetById(model.OrderId);
                    if(order != null)
                    {
                        order.isActive = false;
                        await _order.Update(order);
                        result.isSucces = true;
                        result.Message = _message.ApiName.Order + _message.Delete.Deleted;
                    }
                    else
                    {
                        result.isSucces = false;
                        result.Message = _message.ApiName.Order + _message.Delete.NotDeleted;
                    }
                }
                else
                {
                    result.isSucces = false;
                    result.Message = _message.ApiName.Order + _message.Delete.NotDeleted;
                    foreach(var ModelState in ModelState.Values)
                    {
                        foreach( var validate in ModelState.Errors)
                        {
                            result.ValidationError.Add(validate.ErrorMessage);
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
            GeneralResultList<List<Order>> result = new GeneralResultList<List<Order>>();
            try
            {
                var oders = await _order.GetAll();
                result.isSuccess = true;
                result.Result = oders;
                result.Message = _message.ListData.SuccessList;
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
        public async Task<IActionResult> GetById(int orderId)
        {
            GeneralResultList<Order> result = new GeneralResultList<Order>();
            try
            {
                var order = (await _order.GetAll()).Where(x=>x.OrderId == orderId && x.isActive == true).FirstOrDefault();
                result.isSuccess = true;
                result.Message = _message.ListData.SuccessList;
                result.Result = order;
            }
            catch(Exception ex)
            {
                result.isSuccess = false;
                result.Message = _message.ServerError.Error + ex.Message;
            }
            return Ok(result);
        }
        [HttpGet]
        [Route("GetByOrderNumber")]
        public async Task<IActionResult> GetByOrderNumber(string orderNumber)
        {
            GeneralResultList<List<Order>> result = new GeneralResultList<List<Order>>();
            try
            {
                var order = (await _order.GetAll()).Where(x => x.OrderNumber == orderNumber && x.isActive == true).ToList();
                result.isSuccess = true;
                result.Message = _message.ListData.SuccessList;
                result.Result = order;
            }
            catch(Exception ex)
            {
                result.isSuccess = false;
                result.Message = _message.ServerError.Error + ex.Message;
            }
            return Ok(result);
        }
        [HttpGet]
        [Route("GetByCustomerId")]
        public async Task<IActionResult> GetByCustomerId(int CustomerId)
        {
            GeneralResultList<List<Order>> result = new GeneralResultList<List<Order>>();
            try
            {
                var order = (await _order.GetAll()).Where(x => x.CustomerId == CustomerId && x.isActive == true).ToList();
                result.isSuccess = true;
                result.Result = order;
                result.Message = _message.ListData.SuccessList;
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
