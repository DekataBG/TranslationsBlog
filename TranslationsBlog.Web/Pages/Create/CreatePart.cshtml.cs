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
    public class CreatePartModel : PageModel
    {
        private readonly IRepository repository;

        public CreatePartModel(IRepository repository)
        {
            this.repository = repository;
        }

        [BindProperty]
        public Chapter Chapter { get; set; }
        public List<Chapter> Chapters { get; set; }
        public List<Volume> Volumes { get; set; }
        public void OnGet(int id)
        {
            Chapters = new List<Chapter>();
            Volumes = repository.ReturnAllLightNovels().FirstOrDefault(e => e.Id == id).Volumes;

            foreach (var volume in Volumes)
            {
                foreach (var chapter in volume.Chapters)
                {
                    Chapters.Add(chapter);
                }
            }
        }
        public IActionResult OnPost()
        {
            if (Chapter.Id != 0)
            {
                Chapter = repository.ReturnAllChapters().FirstOrDefault(e => e.Id == Chapter.Id);
                repository.CreatePart(new Part(), Chapter);

                return RedirectToPage("/Menu/Translations");
            }

            return RedirectToPage("/NotFound/InvalidOptionDropdown");
        }

        public int VolumeNumber(Chapter chapter)
        {
            foreach (var volume in Volumes)
            {
                if (volume.Chapters.Contains(chapter))
                    return volume.Number;
            }
            return 0;
        }
    }
}
