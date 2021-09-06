using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TranslationsBlog.Web.Pages.Menu
{
    [Authorize(Roles = "Admin")]
    public class AllUsersModel : PageModel
    {
        private readonly UserManager<IdentityUser> userManager;

        public AllUsersModel(UserManager<IdentityUser> userManager)
        {
            this.userManager = userManager;
        }
        public List<IdentityUser> Users { get; set; }
        public void OnGet()
        {
            Users = userManager.Users.ToList();
        }
    }
}
