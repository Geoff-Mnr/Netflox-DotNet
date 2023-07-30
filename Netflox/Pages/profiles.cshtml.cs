using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Netflox.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace Netflox.Pages
{
    [Authorize]
    public class ProfilesModel : PageModel
    {
        private readonly Netflox.Data.DataContext _context;
        private readonly UserManager<MainUsers> _userManager;

        public ProfilesModel(Netflox.Data.DataContext context, UserManager<MainUsers> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IList<Profiles> Profiles { get; set; }

        public async Task OnGetAsync()
        {
            var mainUser = await _userManager.GetUserAsync(User);

            Profiles = await _context.Profiles
                .Where(x => x.MainUsersId == mainUser.Id)
                .Include(p => p.MainUsers).ToListAsync();
        }
    }
}
