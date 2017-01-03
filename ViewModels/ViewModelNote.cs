using Models;
using System;

namespace ViewModels
{
    public class ViewModelNote : ViewModelBase
    {
        private TextNote _note;
        private string _title;
        private DateTime _dateOfCreate;
        private int _status;
        private string _noteBody;

        public ViewModelNote(Note note)
        {
            if (note is TextNote)
                _note = note as TextNote;
            else
                throw new InvalidCastException();

            _title = note.Title;
            _dateOfCreate = note.DateOfCreate;
            _status = note.Status;
            _noteBody = _note.Note;
        }
        public DateTime DateOfCreateVM
        {
            get { return _note.DateOfCreate; }
            set { Set(ref _dateOfCreate, value); }
        }
        public string TitleVM
        {
            get { return _title; }
            set { Set(ref _title, value); }
        }
        public int StatusVM
        {
            get { return _status; }
            set { Set(ref _status, value); }
        }
        public string NoteVM
        {
            get { return _noteBody; }
            set { Set(ref _noteBody, value); }
        }


    }
}
