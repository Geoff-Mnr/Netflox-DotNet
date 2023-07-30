using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Netflox.Data;
using Netflox.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Netflox.Pages
{
    public class PrivacyModel : PageModel
    {
        private readonly ILogger<PrivacyModel> _logger;
        DataContext dataContext;

        public PrivacyModel(ILogger<PrivacyModel> logger, DataContext dataContext)
        {
            _logger = logger;
            this.dataContext = dataContext;

        }

        public void OnGet()
        {
            
                
            
        }



    }
}

