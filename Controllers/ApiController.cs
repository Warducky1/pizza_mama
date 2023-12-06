using Microsoft.AspNetCore.Mvc;
using Pizza_mama.Data;
using Pizza_mama.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Pizza_mama.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ApiController : Controller
    {
        public readonly DataContext _context;

        public ApiController(DataContext context)
        {
            _context = context;
        }

        // GET: api/<ValuesController>
        [HttpGet]
        [Route("GetPizzas")]
        public IActionResult GetPizzas()
        {
            //var pizza = new Pizza() { name = "PizzaTest", price = 10.5f, vegetarian= false, ingredients="Tomates, lardon, chedar" };

            var pizzas = _context.Pizzas.ToList();

            return Json(pizzas);
        }
    }
}
