using Microsoft.AspNetCore.Mvc;
using SportsStore.Interfaces;
using SportsStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsStore.Controllers
{
    [Route("[controller]/[action]")]
    public class ApiController : Controller
    {
        private IRepository _repositroy;

        public ApiController(IRepository repository)
        {
            _repositroy = repository;
        }

        [HttpGet]
        public IEnumerable<Product> Get()
            => _repositroy.Products;

        [HttpPost]
        public async Task<IActionResult> AddProduct(
            [FromQuery] Product product)
        {
           await _repositroy.AddProduct(product);
            return RedirectToAction(nameof(Get));
        }
    }
}
