﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using My_Little_Dictionary___Anniversary_Edition.Data;

#nullable disable

namespace My_Little_Dictionary___Anniversary_Edition.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    [Migration("20240602115950_Init")]
    partial class Init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("My_Little_Dictionary___Anniversary_Edition.Model.Definition", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("EntryID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Expression")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("EntryID");

                    b.ToTable("Definition");
                });

            modelBuilder.Entity("My_Little_Dictionary___Anniversary_Edition.Model.Dictionary", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Dictionary");
                });

            modelBuilder.Entity("My_Little_Dictionary___Anniversary_Edition.Model.Entry", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("DictionaryID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ID");

                    b.HasIndex("DictionaryID");

                    b.ToTable("Entry");
                });

            modelBuilder.Entity("My_Little_Dictionary___Anniversary_Edition.Model.Form", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("PartOfSpeechID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ID");

                    b.HasIndex("PartOfSpeechID");

                    b.ToTable("Form");
                });

            modelBuilder.Entity("My_Little_Dictionary___Anniversary_Edition.Model.Language", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Language");
                });

            modelBuilder.Entity("My_Little_Dictionary___Anniversary_Edition.Model.PartOfSpeech", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Forms")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("LanguageID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("LanguageID");

                    b.ToTable("PartOfSpeech");
                });

            modelBuilder.Entity("My_Little_Dictionary___Anniversary_Edition.Model.Word", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("EntryID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Expression")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("FormID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ID");

                    b.HasIndex("EntryID");

                    b.HasIndex("FormID");

                    b.ToTable("Word");
                });

            modelBuilder.Entity("My_Little_Dictionary___Anniversary_Edition.Model.Definition", b =>
                {
                    b.HasOne("My_Little_Dictionary___Anniversary_Edition.Model.Entry", null)
                        .WithMany("Definitions")
                        .HasForeignKey("EntryID");
                });

            modelBuilder.Entity("My_Little_Dictionary___Anniversary_Edition.Model.Entry", b =>
                {
                    b.HasOne("My_Little_Dictionary___Anniversary_Edition.Model.Dictionary", null)
                        .WithMany("Entries")
                        .HasForeignKey("DictionaryID");
                });

            modelBuilder.Entity("My_Little_Dictionary___Anniversary_Edition.Model.Form", b =>
                {
                    b.HasOne("My_Little_Dictionary___Anniversary_Edition.Model.PartOfSpeech", "PartOfSpeech")
                        .WithMany()
                        .HasForeignKey("PartOfSpeechID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PartOfSpeech");
                });

            modelBuilder.Entity("My_Little_Dictionary___Anniversary_Edition.Model.PartOfSpeech", b =>
                {
                    b.HasOne("My_Little_Dictionary___Anniversary_Edition.Model.Language", "Language")
                        .WithMany()
                        .HasForeignKey("LanguageID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Language");
                });

            modelBuilder.Entity("My_Little_Dictionary___Anniversary_Edition.Model.Word", b =>
                {
                    b.HasOne("My_Little_Dictionary___Anniversary_Edition.Model.Entry", "Entry")
                        .WithMany("Words")
                        .HasForeignKey("EntryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("My_Little_Dictionary___Anniversary_Edition.Model.Form", "Form")
                        .WithMany()
                        .HasForeignKey("FormID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Entry");

                    b.Navigation("Form");
                });

            modelBuilder.Entity("My_Little_Dictionary___Anniversary_Edition.Model.Dictionary", b =>
                {
                    b.Navigation("Entries");
                });

            modelBuilder.Entity("My_Little_Dictionary___Anniversary_Edition.Model.Entry", b =>
                {
                    b.Navigation("Definitions");

                    b.Navigation("Words");
                });
#pragma warning restore 612, 618
        }
    }
}
