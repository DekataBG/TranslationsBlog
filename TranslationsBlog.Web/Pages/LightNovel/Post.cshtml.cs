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
    public class PostModel : PageModel
    {
        private readonly IRepository repository;

        public PostModel(IRepository repository)
        {
            this.repository = repository;
        }
        public Models.LightNovel LightNovel { get; set; }
        public Volume Volume { get; set; }
        public Chapter Chapter { get; set; }
        public Part Part { get; set; }
        public IActionResult OnGet(int lnId, int volId, int chId, int pId)
        {
            LightNovel = repository.ReturnAllLightNovels().FirstOrDefault(e => e.Id == lnId);

            LightNovel.Volumes = repository.ReturnAllVolumes().Where(volume => volume.LightNovelId == LightNovel.Id).ToList();

            foreach (var volume in LightNovel.Volumes)
            {
                volume.Chapters = repository.ReturnAllChapters().Where(chapter => chapter.VolumeId == volume.Id).ToList();
            }

            foreach (var volume in LightNovel.Volumes)
            {
                foreach (var chapter in volume.Chapters)
                {
                    chapter.Parts = repository.ReturnAllParts().Where(part => part.ChapterId == chapter.Id).ToList();
                }
            }

            if (LightNovel == null)
                return RedirectToPage("/NotFound/TranslationNotFound");
            Volume = LightNovel.Volumes.FirstOrDefault(e => e.Id == volId);
            if (Volume == null)
                return RedirectToPage("/NotFound/TranslationNotFound");
            Chapter = Volume.Chapters.FirstOrDefault(e => e.Id == chId);
            if (Chapter == null)
                return RedirectToPage("/NotFound/TranslationNotFound");
            Part = Chapter.Parts.FirstOrDefault(e => e.Id == pId);
            if (Part == null)
                return RedirectToPage("/NotFound/TranslationNotFound");

            return Page();
        }
    }
}
