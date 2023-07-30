using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Netflox.Data;
using Netflox.Models;

namespace Netflox.Pages
{
    [Authorize]
    public class CreateModel : PageModel
    {
        private readonly DataContext _context;
        private readonly UserManager<MainUsers> _userManager;

        public CreateModel(DataContext context, UserManager<MainUsers> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IActionResult OnGet()
        {
            ViewData["MainUsersId"] = new SelectList(_context.MainUsers, "Id", "Id");
            return Page();
        }

        [BindProperty]
        public CreateView Profile { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var mainUser = await _userManager.GetUserAsync(User);
            var rand = new Random();
            var number = rand.Next(0, Profiles.ImageProfiles.Count - 1);

            _context.Profiles.Add(new Profiles
            {
                FirstName = Profile.FirstName,
                MainUsers = mainUser,
                ProfileImage = Profiles.ImageProfiles[number]
            });
            await _context.SaveChangesAsync();

            return RedirectToPage("/Profiles");
        }

        public class CreateView
        {
            public string FirstName { get; set; }
        }
    }
}
