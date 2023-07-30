using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Netflox.Data;
using Netflox.Models;

namespace Netflox.Pages.Admin.Profils
{
    [Authorize(Roles = "Admin")]
    public class EditModel : PageModel
    {
        private readonly Netflox.Data.DataContext _context;

        public EditModel(Netflox.Data.DataContext context)
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
           ViewData["MainUsersId"] = new SelectList(_context.MainUsers, "Id", "Id");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Profiles).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProfilesExists(Profiles.ProfilID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ProfilesExists(int id)
        {
            return _context.Profiles.Any(e => e.ProfilID == id);
        }
    }
}
