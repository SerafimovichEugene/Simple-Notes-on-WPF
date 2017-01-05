using Models;
using System;

namespace ViewModels
{
    public class ViewModelNote : ViewModelBase
    {
        private Note _note;
        private string _title;
        private DateTime _dateOfCreate;
        private int _status;
        private string _noteBody;
        public ViewModelNote(Note note)
        {
            _note = note;
            _title = note.Title;
            _dateOfCreate = note.DateOfCreate;
            _status = note.Status;
            _noteBody = _note.NoteBody;
        }
        public Note ModelNote
        {
            get { return _note; }
            private set { _note = value; }
        }
        public DateTime DateOfCreateVM
        {
            get { return _note.DateOfCreate; }
            set
            {
                _note.DateOfCreate = value;
                Set(ref _dateOfCreate, value);
            }
        }
        public string TitleVM
        {
            get { return _title; }
            set
            {
                _note.Title = value;
                Set(ref _title, value);
            }
        }
        public int StatusVM
        {
            get { return _status; }
            set
            {
                _note.Status = value;
                Set(ref _status, value);
            }
        }
        public string NoteVM
        {
            get { return _noteBody; }
            set
            {
                _note.NoteBody = value;
                Set(ref _noteBody, value);
            }
        }


    }
}
