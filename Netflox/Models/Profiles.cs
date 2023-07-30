using System;
using System.Collections.Generic;

namespace Netflox.Models
{
    public class Profiles
    {
        public int ProfilID { get; set; }
        public string FirstName { get; set; }
        public string ProfileImage { get; set; }
        
        public MainUsers MainUsers { get; set; }
        public string MainUsersId { get; set; }


        public static List<string> ImageProfiles = new List<string>()
        {
            "/img/icones/profil-1.png",
            "/img/icones/profil-2.png",
            "/img/icones/profil-3.png",
            "/img/icones/profil-4.png",
            "/img/icones/profil-5.png",
            "/img/icones/profil-6.png",
            "/img/icones/profil-7.png"
        };
    }
}
