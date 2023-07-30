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
    public class DeleteModel : PageModel
    {
        private readonly Netflox.Data.DataContext _context;

        public DeleteModel(Netflox.Data.DataContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Profiles = await _context.Profiles.FindAsync(id);

            if (Profiles != null)
            {
                _context.Profiles.Remove(Profiles);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
