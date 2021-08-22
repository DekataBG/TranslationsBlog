using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TranslationsBlog.Models
{
    public class LightNovel
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public List<Volume> Volumes { get; set; }

        [Required(ErrorMessage = "Title is required!")]
        public string Title { get; set; }
    }
}
