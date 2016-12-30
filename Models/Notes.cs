using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Models
{
    public class Notes
    {
        private ObservableCollection<Note> listOfNotes;

        public Notes()
        {
            listOfNotes = new ObservableCollection<Note>();
        }
        public ObservableCollection<Note> ListOfNotes
        {
            get { return listOfNotes; }            
        }

    }
}
