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
    [Authorize(Roles = "Staff")]
    public class CreateLightNovelModel : PageModel
    {
        private readonly IRepository repository;

        [BindProperty]
        public Models.LightNovel LightNovel { get; set; }
        public int Count { get; set; }
        public CreateLightNovelModel(IRepository repository)
        {
            this.repository = repository;
        }
        public void OnGet()
        {
            Count = repository.ReturnAllLightNovels().Count;
        }
        public IActionResult OnPost()
        {
            LightNovel.Number++;

            if (ModelState.IsValid)
            {
                repository.CreateLightNovel(LightNovel);

                return RedirectToPage("/Menu/Translations");
            }
            
            return Page();
        }
    }
}
