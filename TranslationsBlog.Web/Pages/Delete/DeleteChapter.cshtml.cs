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
    public class DeleteChapterModel : PageModel
    {
        private readonly IRepository repository;

        public DeleteChapterModel(IRepository repository)
        {
            this.repository = repository;
        }

        [BindProperty]
        public Chapter Chapter { get; set; }
        public List<Chapter> Chapters { get; set; }
        public List<Volume> Volumes { get; set; }
        public void OnGet()
        {
            Chapters = repository.ReturnAllChapters();
            Volumes = repository.ReturnAllVolumes();
        }

        public IActionResult OnPost()
        {
            if(Chapter.Id != 0)
            {
                repository.DeleteChapter(Chapter.Id);

                return RedirectToPage("/Menu/Translations");
            }

            return RedirectToPage("/NotFound/InvalidOptionDropdown");
        }
    }
}
