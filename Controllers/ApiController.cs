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
        public IQueryable<Product> Get() 
        {
            //System.Console.Clear();
            return _repositroy.Products as IQueryable<Product>;
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct([FromQuery] Product product)
        {
           await _repositroy.AddProduct(product);
            return RedirectToAction(nameof(Get));
        }

        [HttpGet]
        public async Task<IActionResult> GetProduct([FromQuery] long key)
        {
            var data = await _repositroy.GetProduct(key);
            if (data == null)
            {
                return NotFound();
            }
            return Ok(data);
        }

        [HttpPost()]
        public async Task<IActionResult> UpdateProduct([FromQuery] Product product)
        {
   
            await _repositroy.UpdateProduct(product);
            return RedirectToAction(nameof(Get));
        }
    }
}
