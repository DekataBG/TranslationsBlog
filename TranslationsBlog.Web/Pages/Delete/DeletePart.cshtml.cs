using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TranslationsBlog.Data;

namespace TranslationsBlog.Web.Pages.Delete
{
    [Authorize(Roles = "Staff")]
    public class DeletePartModel : PageModel
    {
        private readonly IRepository repository;

        public DeletePartModel(IRepository repository)
        {
            this.repository = repository;
        }
        public void OnGet()
        {
        }
        public IActionResult OnPost(int id)
        {
            repository.DeletePart(id);

            return RedirectToPage("/Menu/Translations");
        }
    }
}
