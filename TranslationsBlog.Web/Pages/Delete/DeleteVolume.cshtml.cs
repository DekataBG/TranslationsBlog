using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TranslationsBlog.Data;
using TranslationsBlog.Models;

namespace TranslationsBlog.Web.Pages.Delete
{
    public class DeleteVolumeModel : PageModel
    {
        private readonly IRepository repository;

        public DeleteVolumeModel(IRepository repository)
        {
            this.repository = repository;
        }
        public List<Volume> Volumes { get; set; }

        [BindProperty]
        public Volume Volume { get; set; }
        public void OnGet()
        {
            Volumes = repository.ReturnAllVolumes();
        }
        public IActionResult OnPost()
        {
            repository.DeleteVolume(Volume.Id);

            return RedirectToPage("/Menu/Translations");
        }
    }
}
