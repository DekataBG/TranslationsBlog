using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TranslationsBlog.Data;

namespace TranslationsBlog.Web.Pages.Delete
{
    public class DeletePartModel : PageModel
    {
        private readonly IRepository repository;

        public DeletePartModel(IRepository repository)
        {
            this.repository = repository;
        }
        public IActionResult OnGet(int id)
        {
            repository.DeletePart(id);

            return RedirectToPage("/Menu/Translations");
        }
    }
}
