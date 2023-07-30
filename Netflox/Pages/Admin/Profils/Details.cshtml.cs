using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Netflox.Data;
using Netflox.Models;

namespace Netflox.Pages.Admin.Profils
{
    [Authorize(Roles = "Admin")]
    public class DetailsModel : PageModel
    {
        private readonly Netflox.Data.DataContext _context;

        public DetailsModel(Netflox.Data.DataContext context)
        {
            _context = context;
        }

        public Profiles Profiles { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Profiles = await _context.Profiles
                .Include(p => p.MainUsers).FirstOrDefaultAsync(m => m.ProfilID == id);

            if (Profiles == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
