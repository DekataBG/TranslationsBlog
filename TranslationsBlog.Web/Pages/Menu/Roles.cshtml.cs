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
    public class RolesModel : PageModel
    {
        private readonly RoleManager<IdentityRole> roleManager;

        public RolesModel(RoleManager<IdentityRole> roleManager)
        {
            this.roleManager = roleManager;
        }

        public List<IdentityRole> Roles { get; private set; }

        public void OnGet()
        {
            Roles = roleManager.Roles.ToList();
        }
    }
}
