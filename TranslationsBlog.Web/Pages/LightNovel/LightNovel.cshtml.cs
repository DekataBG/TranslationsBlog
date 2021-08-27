using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TranslationsBlog.Data;
using TranslationsBlog.Models;

namespace TranslationsBlog.Web.Pages.LightNovel
{
    public class LightNovelModel : PageModel
    {
        private readonly IRepository repository;

        public LightNovelModel(IRepository repository)
        {
            this.repository = repository;
        }
        public Models.LightNovel LightNovel { get; private set; }
        public IActionResult OnGet(int id)
        {
            LightNovel = repository.ReturnAllLightNovels().FirstOrDefault(e => e.Id == id);
            if (LightNovel == null)
                return RedirectToPage("/NotFound/TranslationNotFound");

            return Page();
        }
    }
}
