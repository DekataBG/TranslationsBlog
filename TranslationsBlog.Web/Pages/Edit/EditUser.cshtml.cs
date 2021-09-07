using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TranslationsBlog.Models;

namespace TranslationsBlog.Web.Pages.Edit
{
    [Authorize(Roles = "Admin")]
    public class EditUserModel : PageModel
    {
        private readonly UserManager<IdentityUser> userManager;

        public EditUserModel(UserManager<IdentityUser> userManager)
        {
            this.userManager = userManager;
        }

        [BindProperty]
        public EditUser EditUser { get; set; }
        public async Task<IActionResult> OnGet(string userId)
        {
            var user = await userManager.FindByIdAsync(userId);

            if (user == null)
            {
                TempData["error"] = $"User with Id = {userId} cannot be found";
                return RedirectToPage("/NotFound/IdNotFound");
            }

            var userClaims = await userManager.GetClaimsAsync(user);
            var userRoles = await userManager.GetRolesAsync(user);

            EditUser = new EditUser
            {
                Id = user.Id,
                Email = user.Email,
                Username = user.UserName,
                Claims = userClaims.Select(e => e.Value).ToList(),
                Roles = userRoles.ToList()
            };

            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            var user = await userManager.FindByIdAsync(EditUser.Id);

            if (user == null)
            {
                TempData["error"] = $"User with Id = {user.Id} cannot be found";
                return RedirectToPage("/NotFound/IdNotFound");
            }
            else
            {
                user.UserName = EditUser.Username;
                user.Email = EditUser.Email;

                var result = await userManager.UpdateAsync(user);

                if (result.Succeeded)
                {
                    return RedirectToPage("/Menu/AllUsers");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

                return Page();
            }
        }
    }
}
