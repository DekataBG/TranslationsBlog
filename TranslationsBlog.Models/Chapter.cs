using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TranslationsBlog.Models
{
    public class Chapter
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public List<Part> Parts { get; set; }
        public int VolumeId { get; set; }
        public Volume Volume { get; set; }
    }
}
