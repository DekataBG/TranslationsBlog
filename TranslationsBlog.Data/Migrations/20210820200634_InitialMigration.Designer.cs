﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TranslationsBlog.Data;

namespace TranslationsBlog.Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20210820200634_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TranslationsBlog.Models.Chapter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<int?>("VolumeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("VolumeId");

                    b.ToTable("Chapters");
                });

            modelBuilder.Entity("TranslationsBlog.Models.LightNovel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("LightNovels");
                });

            modelBuilder.Entity("TranslationsBlog.Models.Part", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ChapterId")
                        .HasColumnType("int");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ChapterId");

                    b.ToTable("Parts");
                });

            modelBuilder.Entity("TranslationsBlog.Models.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Persons");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Person");
                });

            modelBuilder.Entity("TranslationsBlog.Models.Volume", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("LightNovelId")
                        .HasColumnType("int");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("LightNovelId");

                    b.ToTable("Volumes");
                });

            modelBuilder.Entity("TranslationsBlog.Models.Editor", b =>
                {
                    b.HasBaseType("TranslationsBlog.Models.Person");

                    b.HasDiscriminator().HasValue("Editor");
                });

            modelBuilder.Entity("TranslationsBlog.Models.Translator", b =>
                {
                    b.HasBaseType("TranslationsBlog.Models.Person");

                    b.HasDiscriminator().HasValue("Translator");
                });

            modelBuilder.Entity("TranslationsBlog.Models.Chapter", b =>
                {
                    b.HasOne("TranslationsBlog.Models.Volume", null)
                        .WithMany("Chapters")
                        .HasForeignKey("VolumeId");
                });

            modelBuilder.Entity("TranslationsBlog.Models.Part", b =>
                {
                    b.HasOne("TranslationsBlog.Models.Chapter", null)
                        .WithMany("Parts")
                        .HasForeignKey("ChapterId");
                });

            modelBuilder.Entity("TranslationsBlog.Models.Volume", b =>
                {
                    b.HasOne("TranslationsBlog.Models.LightNovel", null)
                        .WithMany("Volumes")
                        .HasForeignKey("LightNovelId");
                });

            modelBuilder.Entity("TranslationsBlog.Models.Chapter", b =>
                {
                    b.Navigation("Parts");
                });

            modelBuilder.Entity("TranslationsBlog.Models.LightNovel", b =>
                {
                    b.Navigation("Volumes");
                });

            modelBuilder.Entity("TranslationsBlog.Models.Volume", b =>
                {
                    b.Navigation("Chapters");
                });
#pragma warning restore 612, 618
        }
    }
}