using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TranslationsBlog.Data;
using TranslationsBlog.Models;

namespace TranslationsBlog.Web.Pages.Delete
{
    [Authorize(Roles = "Staff")]
    public class DeleteLightNovelModel : PageModel
    {
        private readonly IRepository repository;

        public DeleteLightNovelModel(IRepository repository)
        {
            this.repository = repository;
        }

        [BindProperty]
        public Models.LightNovel LightNovel { get; set; }
        public List<Models.LightNovel> LightNovels { get; set; }
        public void OnGet()
        {
            LightNovels = repository.ReturnAllLightNovels();
        }

        public IActionResult OnPost()
        {
            if (LightNovel.Id != 0)
            {
                repository.DeleteLightNovel(LightNovel.Id);

                return RedirectToPage("/Menu/Translations");
            }

            return RedirectToPage("/NotFound/InvalidOptionDropdown");
        }
    }
}
