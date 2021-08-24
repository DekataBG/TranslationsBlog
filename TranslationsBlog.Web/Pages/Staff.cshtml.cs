using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TranslationsBlog.Data;
using TranslationsBlog.Models;

namespace TranslationsBlog.Web.Pages
{
    public class StaffModel : PageModel
    {
        private readonly IRepository repository;

        public StaffModel(IRepository repository)
        {
            this.repository = repository;
        }
        public Person Staff { get; set; }
        public IActionResult OnGet(int id)
        {
            Staff = repository.ReturnAllTranslators().FirstOrDefault(e => e.Id == id);
            if (Staff == null)
                Staff = repository.ReturnAllEditors().FirstOrDefault(e => e.Id == id);
            if (Staff == null)
                return RedirectToPage("/NotFound/StaffNotFound");
            return Page();

        }
    }
}
