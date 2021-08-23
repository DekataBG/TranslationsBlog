﻿using System;
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
        List<Translator> ReturnAllTranslators();
        List<Editor> ReturnAllEditors();
        void CreateLightNovel(LightNovel lightNovel);
        void DeleteLightNovel(int id);
        void CreateTranslator(Translator translator);
        void DeleteTranslator(int id);
        void CreateEditor(Editor editor);
        void DeleteEditor(int id);
    }
}
