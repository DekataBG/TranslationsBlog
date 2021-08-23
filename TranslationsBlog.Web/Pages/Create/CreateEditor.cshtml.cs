using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TranslationsBlog.Data;
using TranslationsBlog.Models;

namespace TranslationsBlog.Web.Pages.Create
{
    public class CreateEditorModel : PageModel
    {
        private readonly IRepository repository;

        public CreateEditorModel(IRepository repository)
        {
            this.repository = repository;
        }
        [BindProperty]
        public Editor Editor { get; set; }
        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                repository.CreateEditor(Editor);
                return RedirectToPage("/Menu/AboutUs");
            }

            return Page();
        }
    }
}
