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
    public class DeleteUserModel : PageModel
    {
        private readonly UserManager<IdentityUser> userManager;

        public DeleteUserModel(UserManager<IdentityUser> userManager)
        {
            this.userManager = userManager;
        }
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPost(string userId)
        {
            var user = await userManager.FindByIdAsync(userId);

            if (user == null)
            {
                TempData["error"] = $"User with Id = {userId} cannot be found";
                return RedirectToPage("/NotFound/IdNotFound");
            }
            else
            {
                var result = await userManager.DeleteAsync(user);

                if (result.Succeeded)
                {
                    return RedirectToPage("/Menu/AllUsers");
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
