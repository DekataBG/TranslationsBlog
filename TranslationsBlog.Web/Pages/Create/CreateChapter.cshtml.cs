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
    public class CreateChapterModel : PageModel
    {
        private readonly IRepository repository;

        public CreateChapterModel(IRepository repository)
        {
            this.repository = repository;
        }

        public List<Volume> Volumes { get; set; }

        [BindProperty]
        public Volume Volume { get; set; }
        public void OnGet(int id)
        {
            Volumes = repository.ReturnAllLightNovels().FirstOrDefault(e => e.Id == id).Volumes;
        }

        public IActionResult OnPost()
        {
            if (Volume.Id != 0)
            {
                Volume = repository.ReturnAllVolumes().FirstOrDefault(e => e.Id == Volume.Id);

                repository.CreateChapter(new Chapter(), Volume);

                return RedirectToPage("/Menu/Translations");
            }

            return RedirectToPage("/NotFound/InvalidOptionDropdown");
        }

    }
}
