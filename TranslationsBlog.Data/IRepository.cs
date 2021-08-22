using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TranslationsBlog.Models;

namespace TranslationsBlog.Data
{
    public interface IRepository
    {
        List<Part> ReturnAllParts();
        List<LightNovel> ReturnAllLightNovels();
    }
}
