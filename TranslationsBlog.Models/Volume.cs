using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TranslationsBlog.Models
{
    public class Volume
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public List<Chapter> Chapters { get; set; }
    }
}
