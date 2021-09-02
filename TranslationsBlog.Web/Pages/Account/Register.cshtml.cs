using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TranslationsBlog.Models;

namespace TranslationsBlog.Web.Pages.Menu
{

    public class RegisterModel : PageModel
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public RegisterModel(UserManager<IdentityUser> userManager, 
            SignInManager<IdentityUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
        }
        [BindProperty]
        public User UnregisteredUser { get; set; }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {                
                var user = new IdentityUser { UserName = UnregisteredUser.Username, Email = UnregisteredUser.Email };

                var result = await userManager.CreateAsync(user, UnregisteredUser.Password);

                if (result.Succeeded)
                {
                    await signInManager.SignInAsync(user, isPersistent: false);
                    //Makes the registered person a user
                    var roleId = await roleManager.GetRoleIdAsync(await roleManager.FindByNameAsync("User"));

                    var role = await roleManager.FindByIdAsync(roleId);

                    await userManager.AddToRoleAsync(user, role.Name);
                    //
                    return RedirectToPage("/Index");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }                
            }
            
            return Page();
        }
    }
}
