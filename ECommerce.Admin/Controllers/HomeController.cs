using ECommerce.Admin.Models;
using ECommerce.Core.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ECommerce.Admin.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductReppository _product;
        public HomeController(IProductReppository product)
        {
            _product = product;
        }

        public async Task<IActionResult> Index()
        {
            await _product.GetAllProduct();
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}