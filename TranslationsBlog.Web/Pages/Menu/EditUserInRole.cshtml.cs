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
    public class EditUserInRoleModel : PageModel
    {
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<IdentityUser> userManager;

        public EditUserInRoleModel(RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager)
        {
            this.roleManager = roleManager;
            this.userManager = userManager;
        }

        [BindProperty]
        public UserRole SelectedUser { get; set; }

        [BindProperty]
        public string Command { get; set; }

        public string RoleId { get; set; }
        public List<UserRole> UserNotInRole { get; set; } = new List<UserRole>();
        public List<UserRole> UserInRole { get; set; } = new List<UserRole>();
        public async Task<IActionResult> OnGet(string roleId)
        {
            RoleId = roleId;

            var role = await roleManager.FindByIdAsync(roleId);

            if (role == null)
            {
                TempData["error"] = $"Role with Id = {roleId} cannot be found";
                return RedirectToPage("/NotFound/RoleNotFound");
            }
            var model = new List<UserRole>();

            foreach (var user in userManager.Users)
            {
                var userRole = new UserRole
                {
                    UserId = user.Id,
                    Username = user.UserName,
                    RoleId = role.Id
                };

                userRole.IsInRole = await userManager.IsInRoleAsync(user, role.Name);

                model.Add(userRole);
            }

            foreach (var user in model)
            {
                if (user.IsInRole)
                    UserInRole.Add(user);
                else
                    UserNotInRole.Add(user);
            }

            return Page();
        }

        public IActionResult OnPost()
        {
            TempData["userId"] = SelectedUser.UserId;
            TempData["roleId"] = SelectedUser.RoleId;

            if (Command== "add")
            {
                return RedirectToPage("/Create/CreateUserInRole");
            }

            return RedirectToPage("/Delete/DeleteUserInRole");
        }
    }
}
