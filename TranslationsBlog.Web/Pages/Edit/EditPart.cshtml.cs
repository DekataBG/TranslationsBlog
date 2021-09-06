using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TranslationsBlog.Data;
using TranslationsBlog.Models;

namespace TranslationsBlog.Web.Pages.LightNovel
{
    [Authorize]
    public class EditPartModel : PageModel
    {
        private readonly IRepository repository;

        public EditPartModel(IRepository repository)
        {
            this.repository = repository;
        }
        public Part Part { get; set; }
        public IActionResult OnGet(int id)
        {
            Part = repository.ReturnAllParts().FirstOrDefault(e => e.Id == id);

            if (Part == null)
            {
                return RedirectToPage("/NotFound/TranslationNotFound");
            }

            return Page();
        }
        public IActionResult OnPost(int id, Part part)
        {
            Part = repository.ReturnAllParts().FirstOrDefault(e => e.Id == id);

            if (Part == null)
            {
                return RedirectToPage("/NotFound/TranslationNotFound");
            }

            if (ModelState.IsValid)
            {
                Part.Text = part.Text;
                repository.DbContextSaveChanges();

                return RedirectToPage("/Menu/Translations");
            }

            return Page();
        }
    }
}
