using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TranslationsBlog.Data;
using TranslationsBlog.Models;

namespace TranslationsBlog.Web.Pages.Create
{
    [Authorize(Roles = "Admin")]
    public class CreateTranslatorModel : PageModel
    {
        private readonly IRepository repository;

        public CreateTranslatorModel(IRepository repository)
        {
            this.repository = repository;
        }
        [BindProperty]
        public Translator Translator { get; set; }
        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                repository.CreateTranslator(Translator);
                return RedirectToPage("/Menu/AboutUs");
            }

            return Page();
        }
    }
}
