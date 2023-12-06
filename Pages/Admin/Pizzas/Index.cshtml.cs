using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Pizza_mama.Data;
using Pizza_mama.Models;

namespace Pizza_mama.Pages.Admin.Pizzas
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly Pizza_mama.Data.DataContext _context;

        public IndexModel(Pizza_mama.Data.DataContext context)
        {
            _context = context;
        }

        public IList<Pizza> Pizza { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Pizza = await _context.Pizzas.ToListAsync();
        }
    }
}
