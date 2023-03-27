using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FoodApp.Core;
using FoodApp.Data;

namespace FoodApp.Pages.R2
{
    public class IndexModel : PageModel
    {
        private readonly FoodApp.Data.FoodAppContext _context;

        public IndexModel(FoodApp.Data.FoodAppContext context)
        {
            _context = context;
        }

        public IList<Restaurant> Restaurant { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Restaurants != null)
            {
                Restaurant = await _context.Restaurants.ToListAsync();
            }
        }
    }
}
