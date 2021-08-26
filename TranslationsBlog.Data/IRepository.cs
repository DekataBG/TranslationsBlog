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
        List<Chapter> ReturnAllChapters();
        List<Volume> ReturnAllVolumes();
        List<LightNovel> ReturnAllLightNovels();
        List<Translator> ReturnAllTranslators();
        List<Editor> ReturnAllEditors();
        void CreateLightNovel(LightNovel lightNovel);
        void DeleteLightNovel(int id);
        void CreateVolume(Volume volume, LightNovel lightNovel);
        void DeleteVolume(int id);
        void CreateTranslator(Translator translator);
        void DeleteTranslator(int id);
        void CreateEditor(Editor editor);
        void DeleteEditor(int id);
        void DeletePart(int id);
        void DbContextSaveChanges();
    }
}
