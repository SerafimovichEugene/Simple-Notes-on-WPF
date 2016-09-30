using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvvmLight1
{
    public class MyNotesContext : DbContext
    {
        public MyNotesContext() : base(@"Data Source=c:\DB_File_1.sdf")
        {

        }
        public DbSet<MyNotesBase> MyNotes { get; set; }
    }
    public class MyNotesBase
    {    
        public int MyNotesBaseId { get; set; }
        public string Title { get; set; }
        public DateTime DateTime { get; set; }
        public int ImageIndex { get; set; }
        public string Note { get; set; }

    }
}
