using Models;
using System;

namespace ViewModels
{
    public class ViewModelNote : ViewModelBase 
    {
        private TextNote _note;

        public ViewModelNote(Note note)
        {
            if (note is TextNote)
                _note = note as TextNote;
            else
                throw new InvalidCastException(); 
        }
        public DateTime DateOfCreate
        {
            get { return _note.DateOfCreate; }
        }
        public string TitleVM
        {
            get { return _note.Title; }
            set { _note.Title = value; }
        }
        public int Status
        {
            get { return _note.Status; }
            set { _note.Status = value; }
        }
        public string Note
        {
            get { return _note.Note; }
            set { _note.Note = value; }
        }


    }
}
