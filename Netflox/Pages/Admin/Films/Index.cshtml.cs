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
    public class IndexModel : PageModel
    {
        private readonly Netflox.Data.DataContext _context;

        public IndexModel(Netflox.Data.DataContext context)
        {
            _context = context;
        }

        public IList<Movie> Movie { get;set; }

        public async Task OnGetAsync()
        {
            Movie = await _context.Movies.ToListAsync();
        }
    }
}
