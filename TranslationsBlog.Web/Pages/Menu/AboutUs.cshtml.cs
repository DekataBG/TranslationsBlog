using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TranslationsBlog.Data;
using TranslationsBlog.Models;

namespace TranslationsPage.Pages.Menu
{
    public class AboutUsModel : PageModel
    {
        private readonly IRepository repository;

        public AboutUsModel(IRepository repository)
        {
            this.repository = repository;
        }
        public List<Translator> Translators { get; set; }
        public List<Editor> Editors { get; set; }
        public void OnGet()
        {
            Translators = repository.ReturnAllTranslators();
            Editors = repository.ReturnAllEditors();
        }
    }
}
