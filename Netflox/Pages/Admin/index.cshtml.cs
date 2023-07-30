using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Netflox.Pages.Admin
{
    [Authorize(Roles = "Admin")]
    public class Admin_GestionModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
