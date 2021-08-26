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
        public List<Translator> ReturnAllTranslators()
        {
            return dbContext.Translators.ToList();
        }

        public void CreateLightNovel(LightNovel lightNovel)
        {
            var part = new Part();
            part.Number = 1;
            part.Text = "first part";
            var chapter = new Chapter();
            chapter.Number = 1;
            chapter.Parts = new List<Part>();
            chapter.Parts.Add(part);
            var volume = new Volume();
            volume.Number = 1;
            volume.Chapters = new List<Chapter>();
            volume.Chapters.Add(chapter);
            lightNovel.Volumes = new List<Volume>();
            lightNovel.Volumes.Add(volume);

            dbContext.LightNovels.Add(lightNovel);
            dbContext.SaveChanges();
        }

        public void DeleteLightNovel(int id)
        {
            dbContext.LightNovels.Remove(dbContext.LightNovels.FirstOrDefault(e => e.Id == id));
            dbContext.SaveChanges();
        }

        public void CreateTranslator(Translator translator)
        {
            dbContext.Translators.Add(translator);
            dbContext.SaveChanges();
        }

        public void DeleteTranslator(int id)
        {
            dbContext.Translators.Remove(dbContext.Translators.FirstOrDefault(e => e.Id == id));
            dbContext.SaveChanges();
        }

        public void CreateEditor(Editor editor)
        {
            dbContext.Editors.Add(editor);
            dbContext.SaveChanges();
        }

        public void DeleteEditor(int id)
        {
            dbContext.Editors.Remove(dbContext.Editors.FirstOrDefault(e => e.Id == id));
            dbContext.SaveChanges();
        }

        public void DeletePart(int id)
        {
            dbContext.Parts.Remove(dbContext.Parts.FirstOrDefault(e => e.Id == id));
            dbContext.SaveChanges();
        }

        public List<Editor> ReturnAllEditors()
        {
            return dbContext.Editors.ToList();
        }

        public List<Chapter> ReturnAllChapters()
        {
            return dbContext.Chapters.ToList();
        }

        public List<Volume> ReturnAllVolumes()
        {
            return dbContext.Volumes.ToList();
        }

        public void DbContextSaveChanges()
        {
            dbContext.SaveChanges();
        }

        public Repository()
        {
            dbContext.Parts.Add(new Part());
        }
    }
}
