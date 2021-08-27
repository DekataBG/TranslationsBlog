using Microsoft.EntityFrameworkCore;
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
        public List<LightNovel> ReturnAllLightNovels()
        {
            return dbContext.LightNovels.Include(e => e.Volumes)
                                        .ThenInclude(i => i.Chapters)
                                        .ThenInclude(j => j.Parts)
                                        .ToList();
        }
        public List<Volume> ReturnAllVolumes()
        {
            return dbContext.Volumes.Include(e => e.Chapters)
                                    .ThenInclude(i => i.Parts)
                                    .ToList();
        }
        public List<Chapter> ReturnAllChapters()
        {
            return dbContext.Chapters.Include(e => e.Parts).ToList();
        }
        public List<Part> ReturnAllParts()
        {
            return dbContext.Parts.ToList();
        }
        public List<Translator> ReturnAllTranslators()
        {
            return dbContext.Translators.ToList();
        }
        public List<Editor> ReturnAllEditors()
        {
            return dbContext.Editors.ToList();
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
            foreach (var volume in ReturnAllLightNovels().FirstOrDefault(e => e.Id == id).Volumes)
            {
                foreach (var chapter in volume.Chapters)
                {
                    foreach (var part in chapter.Parts)
                    {
                        dbContext.Parts.Remove(part);
                    }
                    dbContext.Chapters.Remove(chapter);
                }
                dbContext.Volumes.Remove(volume);
            }
            dbContext.LightNovels.Remove(dbContext.LightNovels.FirstOrDefault(e => e.Id == id));

            dbContext.SaveChanges();
        }
        public void CreateVolume(Volume volume, LightNovel lightNovel)
        {
            volume.Number = lightNovel.Volumes.Count + 1;
            volume.Chapters = new List<Chapter>();

            lightNovel.Volumes.Add(volume);
            dbContext.SaveChanges();
        }
        public void DeleteVolume(int id)
        {
            dbContext.Volumes.Remove(ReturnAllVolumes().FirstOrDefault(e => e.Id == id));
            dbContext.SaveChanges();
        }
        public void CreateChapter(Chapter chapter, Volume volume)
        {           
            chapter.Number = volume.Chapters.Count + 1;
            chapter.Parts = new List<Part>();

            volume.Chapters.Add(chapter);
            dbContext.SaveChanges();
        }
        public void DeleteChapter(int id)
        {
            dbContext.Chapters.Remove(ReturnAllChapters().FirstOrDefault(e => e.Id == id));
            dbContext.SaveChanges();
        }
        public void CreatePart(Part part, Chapter chapter)
        {            
            part.Text = "text";
            part.Number = chapter.Parts.Count + 1;

            chapter.Parts.Add(part);
            dbContext.SaveChanges();
        }
        public void DeletePart(int id)
        {
            dbContext.Parts.Remove(dbContext.Parts.FirstOrDefault(e => e.Id == id));
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
