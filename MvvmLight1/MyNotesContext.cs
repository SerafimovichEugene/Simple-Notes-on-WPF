using System.Data.Entity;

namespace MvvmLight1.Model
{
    public class MyNotesContext : DbContext
    {     
        public MyNotesContext(string NameOrConnectionString) : base(NameOrConnectionString) { }
        public DbSet<MyNote> MyNotes { get; set; }
    }   
}
