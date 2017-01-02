using System.Collections.Generic;
using System.Linq;
using System.Collections.ObjectModel;

namespace Models
{
    public class Notes
    {
        private List<TextNote> listOfNotes;
        private static string ConnectionString;
        private static NotesContext context;
        public Notes()
        {
            ConnectionString = "Notes.sdf";
            LoadCollection();
        }
        public List<TextNote> ListOfNotes
        {
            get { return listOfNotes; }
        }
        private void LoadCollection()
        {
            using (context = new NotesContext(ConnectionString))
            {
                listOfNotes = new List<TextNote>(context.MyNotes.ToList());
            }
        }

        public void GetNotes()
        {

        }
        public void AddNote()
        {
            listOfNotes.Add(new TextNote("Title here", 1));
        }
    }
}
