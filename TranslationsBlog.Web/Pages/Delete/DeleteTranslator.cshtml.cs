using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TranslationsBlog.Data;
using TranslationsBlog.Models;

namespace TranslationsBlog.Web.Pages.Delete
{
    public class DeleteTranslatorModel : PageModel
    {
        private readonly IRepository repository;

        public DeleteTranslatorModel(IRepository repository)
        {
            this.repository = repository;
        }
        [BindProperty]
        public Translator Translator { get; set; }
        public List<Translator> Translators { get; set; }
        public void OnGet()
        {
            Translators = repository.ReturnAllTranslators();
        }
        public IActionResult OnPost()
        {
            if (Translator.Id != 0)
            {
                repository.DeleteTranslator(Translator.Id);

                return RedirectToPage("/Menu/AboutUs");
            }

            return RedirectToPage("/Delete/InvalidOptionDropdown");
        }
    }
}
