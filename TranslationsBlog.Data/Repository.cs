using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TranslationsBlog.Models;

namespace TranslationsBlog.Data
{
    public class Repository : IRepository
    {
        private readonly AppDbContext dbContext;

        public Repository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public List<Part> ReturnAllParts()
        {
            return dbContext.Parts.ToList();
        }

        public List<LightNovel> ReturnAllLightNovels()
        {
            return dbContext.LightNovels.ToList();
        }

        public Repository()
        {
            dbContext.Parts.Add(new Part());
        }
    }
}
