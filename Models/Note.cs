using System;

namespace Models
{
    public abstract class Note
    {
        private Guid _guid;
        private DateTime _dateOfCreate;
        private string _title;        
        private int _status;

        protected Note(string title, int status)
        {
            _guid = Guid.NewGuid();
            _dateOfCreate = DateTime.Now;
            _title = title;
            _status = status;
        }

        public Guid Guid
        {
            get { return _guid; }
        }
        public DateTime DateOfCreate
        {
            get { return _dateOfCreate; }            
        }
        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }
        public int Status
        {
            get { return _status; }            
        }

    }
}
