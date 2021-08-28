using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using TranslationsBlog.Models;

namespace TranslationsBlog.Data
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Part> Parts { get; set; }
        public DbSet<Chapter> Chapters { get; set; }
        public DbSet<Volume> Volumes { get; set; }
        public DbSet<LightNovel> LightNovels { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Translator> Translators { get; set; }
        public DbSet<Editor> Editors { get; set; }
    }
}
