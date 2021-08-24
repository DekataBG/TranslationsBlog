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
        //public List<Volume> Volumes { get; set; } = new List<Volume>();
        public List<Chapter> Chapters { get; set; } = new List<Chapter>();
        public List<Part> Parts { get; set; } = new List<Part>();
        public void OnGet(int id)
        {
            LightNovel = repository.ReturnAllLightNovels().FirstOrDefault(e => e.Id == id);
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
        }
    }
}
