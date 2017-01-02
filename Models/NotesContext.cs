using System.Data.Entity;

namespace Models
{
    class NotesContext : DbContext
    {
        public NotesContext(string NameOrConnectionString) : base(NameOrConnectionString) { }
        public DbSet<TextNote> MyNotes { get; set; }
    }
}
