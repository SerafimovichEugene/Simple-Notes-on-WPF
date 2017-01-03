using System.Data.Entity;

namespace Models
{
    public class NotesContext : DbContext
    {
        public NotesContext() { }
        public NotesContext(string NameOrConnectionString) : base(NameOrConnectionString) { }
        public DbSet<Note> MyNotes { get; set; }
        public DbSet<TextNote> MyTextNotes { get; set; }
    }
}
