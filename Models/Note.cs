using System;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public abstract class Note
    {

        private DateTime _dateOfCreate;
        private string _title;
        private int _status;

        public Note(string title, int status)
        {

            _dateOfCreate = DateTime.Now;
            _title = title;
            _status = status;
        }
        public int NoteId { get; set; }
        public DateTime DateOfCreate
        {
            get { return _dateOfCreate; }
            set { _dateOfCreate = value; }
        }
        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }
        public int Status
        {
            get { return _status; }
            set { _status = value; }
        }



    }
}
