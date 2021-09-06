using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TranslationsBlog.Models;

namespace TranslationsBlog.Web.Pages.Create
{
    [Authorize(Roles = "Admin")]
    public class CreateUserInRoleModel : PageModel
    {
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<IdentityUser> userManager;

        public CreateUserInRoleModel(RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager)
        {
            this.roleManager = roleManager;
            this.userManager = userManager;
        }

        public  async Task<IActionResult> OnGet()
        {
            var userId = TempData["userId"].ToString();
            var roleId = TempData["roleId"].ToString();           

            var user = await userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return RedirectToPage("/NotFound/InvalidOptionDropdown");
            }
            var role = await roleManager.FindByIdAsync(roleId);

            await userManager.AddToRoleAsync(user, role.Name);

            return RedirectToPage("/Menu/Roles");
        }
    }
}
