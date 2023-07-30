using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Netflox.Models;
using System.Data;

namespace Netflox.Pages
{
    
    public class IndexModel : PageModel
    {

        public IndexModel(UserManager<MainUsers> userManager)
        {
            /*var user = new MainUsers { UserName = "admin@admin.be", Email = "admin@admin.be" };

            userManager.CreateAsync(user, "Azerty123!")
            .GetAwaiter()
            .GetResult();

            userManager.AddToRoleAsync(user, "Admin")
                .GetAwaiter()
                .GetResult();
            
             User.isInRole(fonction pour rajouter un bouton*/
             

            
        }

        public void OnGet()
        {

        }
    }
}
