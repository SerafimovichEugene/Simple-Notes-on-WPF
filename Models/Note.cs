using System;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models
{
    public class Note
    {
        private DateTime _dateOfCreate;
        private string _title;
        private int _status;
        private string _note;
        public Note() { }
        public Note(string title, int status)
        {
            _dateOfCreate = DateTime.Now;
            _title = title;
            _status = status;
            var stringBuilder = new StringBuilder("<FlowDocument xmlns=\"http://schemas.microsoft.com/winfx/2006/xaml/presentation\"><Paragraph>Hello</Paragraph><Paragraph>start you note here</Paragraph><Paragraph>enjoy;)</Paragraph></FlowDocument>");
            _note = stringBuilder.ToString();
        }

        [Key]
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
        public string NoteBody
        {
            get { return _note; }
            set { _note = value; }
        }


    }
}
