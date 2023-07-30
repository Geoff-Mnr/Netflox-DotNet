using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Netflox.Models
{
    public class MainUsers : IdentityUser
    {
        public List<Profiles> Profiles { get; set; }
    }
}
