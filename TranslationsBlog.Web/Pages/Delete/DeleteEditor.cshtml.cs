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
    public class DeleteEditorModel : PageModel
    {
        private readonly IRepository repository;

        public DeleteEditorModel(IRepository repository)
        {
            this.repository = repository;
        }
        [BindProperty]
        public Editor Editor { get; set; }
        public List<Editor> Editors { get; set; }
        public void OnGet()
        {
            Editors = repository.ReturnAllEditors();
        }
        public IActionResult OnPost()
        {
            if (Editor.Id != 0)
            {
                repository.DeleteEditor(Editor.Id);

                return RedirectToPage("/Menu/AboutUs");
            }

            return RedirectToPage("/NotFound/InvalidOptionDropdown");
        }
    }
}
