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

            repository.CreateVolume(new Volume(), LightNovel);

            return RedirectToPage("/Menu/Translations");
        }
    }
}
