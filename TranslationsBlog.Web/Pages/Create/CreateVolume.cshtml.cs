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
    public class CreateVolumeModel : PageModel
    {
        private readonly IRepository repository;

        public CreateVolumeModel(IRepository repository)
        {
            this.repository = repository;
        }
        public Models.LightNovel LightNovel { get; set; }
        public IActionResult OnGet(int id)
        {
            LightNovel = repository.ReturnAllLightNovels().FirstOrDefault(e => e.Id == id);
            Volume volume = new Volume();

            repository.CreateVolume(volume, LightNovel);

            return RedirectToPage("/Menu/Translations");
        }
    }
}
