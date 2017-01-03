using System.Collections.Generic;
using System.Linq;
using System.Collections.ObjectModel;
using System.IO;

namespace Models
{
    public class Notes
    {
        private List<Note> listOfNotes;
        private static string ConnectionString;
        private static NotesContext context;
        public Notes()
        {
            ConnectionString = "Notes.sdf";
            LoadCollection();
        }
        public List<Note> ListOfNotes
        {
            get { return listOfNotes; }
        }
        private void LoadCollection()
        {
            using (context = new NotesContext(ConnectionString))
            {

                if (File.Exists("Notes.sdf"))
                {
                    IQueryable<TextNote> query = from b in context.MyNotes.OfType<TextNote>()
                                                 select b;
                    listOfNotes = new List<Note>(query);
                }
                    
                else
                    listOfNotes = new List<Note>();
            }
        }

        public void GetNotes()
        {

        }
        public void AddNote(Note note)
        {
            listOfNotes.Add(note);
        }
    }
}
