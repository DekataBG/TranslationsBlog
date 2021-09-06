using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TranslationsBlog.Web.Pages.Delete
{
    [Authorize(Roles = "Admin")]
    public class DeleteRoleModel : PageModel
    {
        private readonly RoleManager<IdentityRole> roleManager;

        public DeleteRoleModel(RoleManager<IdentityRole> roleManager)
        {
            this.roleManager = roleManager;
        }
        public void OnGet()
        {          
        }
        public async Task<IActionResult> OnPost(string id)
        {
            var role = await roleManager.FindByIdAsync(id);

            if (role == null)
            {
                TempData["error"] = $"Role with Id = {id} cannot be found";
                return RedirectToPage("/NotFound/RoleNotFound");
            }
            else
            {
                var result = await roleManager.DeleteAsync(role);

                if (result.Succeeded)
                {
                    return RedirectToPage("/Menu/Roles");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return RedirectToPage("/Menu/AllUsers");
            }
           

            
        }
    }
}
