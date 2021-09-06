using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TranslationsBlog.Models;

namespace TranslationsBlog.Web.Pages.Menu
{
    [Authorize(Roles = "Admin")]
    public class EditRoleModel : PageModel
    {
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<IdentityUser> userManager;

        public EditRoleModel(RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager)
        {
            this.roleManager = roleManager;
            this.userManager = userManager;
        }

        [BindProperty]
        public EditRole Role { get; set; }
        public async Task<IActionResult> OnGet(string id)
        {
            var role = await roleManager.FindByIdAsync(id);

            if (role==null)
            {
                TempData["error"] = $"Role with Id = {id} cannot be found";
                return RedirectToPage("/NotFound/RoleNotFound");
            }

            var model = new EditRole
            {
                Id = role.Id,
                RoleName = role.Name
            };
            foreach (var user in userManager.Users)
            {
                if(await userManager.IsInRoleAsync(user, role.Name))
                {
                    model.Users.Add(user.UserName); 
                }
            }
            Role = model;

            return Page();
        }

        public async Task<IActionResult> OnPost(string id)
        {
            var role = await roleManager.FindByIdAsync(id);

            if (role == null)
            {
                TempData["error"] = $"Role with Id = {Role.Id} cannot be found";
                return RedirectToPage("/NotFound/RoleNotFound");
            }
            else
            {
                role.Name = Role.RoleName;
                var result = await roleManager.UpdateAsync(role);

                if (result.Succeeded)
                    return RedirectToPage("/Menu/Roles");
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return Page();
            }
        }

    }
}
