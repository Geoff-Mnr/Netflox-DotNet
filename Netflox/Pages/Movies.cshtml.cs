using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Netflox.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Netflox.Pages
{
    [Authorize]
    public class MoviesModel : PageModel
    {
        private readonly Netflox.Data.DataContext _context;
        private readonly UserManager<MainUsers> _userManager;

        public MoviesModel(Netflox.Data.DataContext context, UserManager<MainUsers> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IList<Movie> Movie { get; set; }
        public string ProfileImg { get; set; }
       

    

        public async Task OnGetAsync(int id)
        {
            Movie = await _context.Movies.ToListAsync();

            var mainUser = await _userManager.GetUserAsync(User);


             ProfileImg = await _context.Profiles.AsNoTracking()
                .Where(x => x.ProfilID == id && x.MainUsersId == mainUser.Id)
                .Select(x => x.ProfileImage)
                .SingleAsync();
        }

    }
}

