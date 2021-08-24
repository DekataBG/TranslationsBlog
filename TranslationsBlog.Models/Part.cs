using System;
using System.ComponentModel.DataAnnotations;

namespace TranslationsBlog.Models
{
    public class Part
    {
        public int Id { get; set; }
        public int Number { get; set; }

        [Required]
        public string Text { get; set; }
        public int  ChapterId { get; set; }
        public Chapter Chapter { get; set; }
    }
}
