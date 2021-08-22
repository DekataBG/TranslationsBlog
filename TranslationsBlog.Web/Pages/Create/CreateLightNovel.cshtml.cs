using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TranslationsBlog.Models;

namespace TranslationsBlog.Web.Pages.Create
{
    public class CreateLightNovelModel : PageModel
    {
        public LightNovel LightNovel { get; set; }
        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {

        }
    }
}
