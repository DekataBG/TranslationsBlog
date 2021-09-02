using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TranslationsBlog.Web.Pages.Delete
{
    [Authorize(Roles = "Admin")]
    public class DeleteRoleModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
