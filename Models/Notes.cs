using System.Collections.ObjectModel;

namespace Models
{
    public class Notes
    {
        private ObservableCollection<Note> listOfNotes;
        private string ConnectionString;
        public Notes()
        {
            listOfNotes = new ObservableCollection<Note>();
        }
        public ObservableCollection<Note> ListOfNotes
        {
            get { return listOfNotes; }            
        }

        public void GetNotes()
        {
            
        }

    }
}
