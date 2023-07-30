using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Netflox.Data;
using Netflox.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Netflox.Pages
{
    [Authorize]
    public class MovieDescriptionModel : PageModel
    {
       
        private readonly Netflox.Data.DataContext _context;
     

        public Movie Movie { get; set; }
        
        public MovieDescriptionModel(Netflox.Data.DataContext context)
        {
            
            _context = context;
          
        }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            
            Movie = await _context.Movies.FindAsync(id);

           
            if (Movie == null)
            {
                return NotFound();
            }
            
          

            return Page();
        }
   
}
}
