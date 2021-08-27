using System;
using System.ComponentModel.DataAnnotations;

namespace TranslationsBlog.Models
{
    public class Part
    {
        public int Id { get; set; }
        public int Number { get; set; }

        [Required(ErrorMessage = "Text is required!")]
        public string Text { get; set; }
    }
}
