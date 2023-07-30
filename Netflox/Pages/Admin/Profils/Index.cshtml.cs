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
    public class IndexModel : PageModel
    {
        private readonly Netflox.Data.DataContext _context;

        public IndexModel(Netflox.Data.DataContext context)
        {
            _context = context;
        }

        public IList<Profiles> Profiles { get;set; }

        public async Task OnGetAsync()
        {
            Profiles = await _context.Profiles
                .Include(p => p.MainUsers).ToListAsync();
        }
    }
}
