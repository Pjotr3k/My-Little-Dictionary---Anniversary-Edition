
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using My_Little_Dictionary___Anniversary_Edition.Model;

namespace My_Little_Dictionary___Anniversary_Edition.Data
{
    public class ApplicationDBContext : IdentityDbContext
    {
        public ApplicationDBContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {

        }

        public DbSet<Definition> Definition { get; set; }
        public DbSet<Lexicon> Dictionary { get; set; }
        public DbSet<Lexeme> Lexeme { get; set; }
        public DbSet<Form> Form { get; set; }
        public DbSet<Project> Project { get; set; }
        public DbSet<Language> Language { get; set; }
        public DbSet<PartOfSpeech> PartOfSpeech { get; set; }
        public DbSet<Word> Word { get; set; }
        public DbSet<RefreshToken> RefreshToken { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Project>()
                .HasIndex(project => project.Code)
                .IsUnique();

            modelBuilder.Entity<Lexeme>()
                .HasOne(lexeme => lexeme.Dictionary)
                .WithMany(dictionary => dictionary.Lexemes)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Lexicon>()
                .HasOne(dictionary => dictionary.Project)
                .WithMany(project => project.Dictionaries)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}