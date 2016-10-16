using System.Data.Entity;

namespace MvvmLight1.Model
{
    public class MyNotesContext : DbContext
    {
        public MyNotesContext(string NameOrConnectionString) : base(NameOrConnectionString) { }
        public DbSet<MyNote> MyNotes { get; set; }
    }
    //public class MyNotesBase
    //{    
    //    public int MyNotesBaseId { get; set; }
    //    public string Title { get; set; }
    //    public DateTime DateTime { get; set; }
    //    public int ImageIndex { get; set; }
    //    public string Note { get; set; }

    //}
}
