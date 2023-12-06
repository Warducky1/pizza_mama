using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Pizza_mama.Models;

namespace Pizza_mama.Pages
{
    public class MenuPizzasModel : PageModel
    {

        private readonly Pizza_mama.Data.DataContext _context;

        public MenuPizzasModel(Pizza_mama.Data.DataContext context)
        {
            _context = context;
        }

        public IList<Pizza> Pizzas { get; set; } = default!;

        public async Task OnGetAsync()
        {
            Pizzas = await _context.Pizzas.ToListAsync();
        }
    }
}
