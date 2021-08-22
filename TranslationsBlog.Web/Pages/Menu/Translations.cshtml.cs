using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TranslationsBlog.Data;
using TranslationsBlog.Models;

namespace TranslationsPage.Pages
{
    public class TranslationsModel : PageModel
    {
        private readonly IRepository repository;
        public List<LightNovel> LightNovels = new List<LightNovel>();
        public TranslationsModel(IRepository repository)
        {
            this.repository = repository;
        }
        public void OnGet()
        {
            foreach (var ln in repository.ReturnAllLightNovels())
            {
                LightNovels.Add(ln);
            }
        }
    }
}
