using System;
using System.Collections.Generic;
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
        public string Title { get; set; }
    }
}
