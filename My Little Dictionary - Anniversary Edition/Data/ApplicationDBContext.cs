
using Microsoft.EntityFrameworkCore;
using My_Little_Dictionary___Anniversary_Edition.Model;

namespace My_Little_Dictionary___Anniversary_Edition.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
            
        }

        public DbSet<Definition> Definition { get; set; }
        public DbSet<EntryDefinitionAssociation> EntryDefinitionAssociations { get; set; }
        public DbSet<Dictionary> Dictionary { get; set; }
        public DbSet<Entry> Entry { get; set; }
        public DbSet<Form> Form { get; set; }

        public DbSet<Language> Language { get; set; }
        public DbSet<PartOfSpeech> PartOfSpeech { get; set; }
        public DbSet<Word> Word { get; set; }

    }
}
