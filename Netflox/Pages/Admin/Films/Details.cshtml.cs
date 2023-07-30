using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Netflox.Data;
using Netflox.Models;

namespace Netflox.Pages.Admin.Admin_Gestion.Films
{
    [Authorize(Roles = "Admin")]
    public class DetailsModel : PageModel
    {
        private readonly Netflox.Data.DataContext _context;

        public DetailsModel(Netflox.Data.DataContext context)
        {
            _context = context;
        }

        public Movie Movie { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Movie = await _context.Movies.FirstOrDefaultAsync(m => m.MovieID == id);

            if (Movie == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
