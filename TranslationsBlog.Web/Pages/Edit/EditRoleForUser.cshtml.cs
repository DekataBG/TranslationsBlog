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
    public class EditRoleForUserModel : PageModel
    {
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<IdentityUser> userManager;

        public EditRoleForUserModel(RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager)
        {
            this.roleManager = roleManager;
            this.userManager = userManager;
        }

        [BindProperty]
        public UserRole SelectedRole { get; set; }

        [BindProperty]
        public string Command { get; set; }
        public string UserId { get; set; }
        public List<UserRole> RoleHasNoUser { get; set; } = new List<UserRole>();
        public List<UserRole> RoleHasUser { get; set; } = new List<UserRole>();
        public async Task<IActionResult> OnGet(string userId)
        {
            UserId = userId;

            var user = await userManager.FindByIdAsync(userId);

            if (user == null)
            {
                TempData["error"] = $"User with Id = {userId} cannot be found";
                return RedirectToPage("/NotFound/IdNotFound");
            }
            var model = new List<UserRole>();

            foreach (var role in roleManager.Roles)
            {
                var userRole = new UserRole
                {
                    UserId = user.Id,
                    RoleName = role.Name,
                    RoleId = role.Id
                };

                userRole.HasUser = await userManager.IsInRoleAsync(user, role.Name);

                model.Add(userRole);
            }

            foreach (var role in model)
            {
                if (role.HasUser)
                    RoleHasUser.Add(role);
                else
                    RoleHasNoUser.Add(role);
            }

            return Page();
        }

        public IActionResult OnPost()
        {
            TempData["userId"] = SelectedRole.UserId;
            TempData["roleId"] = SelectedRole.RoleId;

            if (Command == "add")
            {
                return RedirectToPage("/Create/CreateRoleForUser");
            }

            return RedirectToPage("/Delete/DeleteRoleForUser");
        }
    }
}
