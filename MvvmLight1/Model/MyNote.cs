using System;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MvvmLight1.Model
{
   
    public class MyNote
    {
        private string _title;
        private DateTime _dateTime;
        private int _image;
        private string _note; 
            
        [Key]
        public int MyNoteId { get; set; }  
        public string TitleDI
        {
            get { return _title; }
            set { _title = value; }
        }
        public DateTime TimeOfCreateDI
        {
            get { return _dateTime; }
            set { _dateTime = value; }
        }
        public int ImageDI
        {
            get { return _image; }
            set { _image = value; }
        }
        public string NoteDI
        {
            get { return _note; }
            set { _note = value; }
        }
    
        public MyNote(string title, int imageIndex)
        {
            TitleDI = title;
            TimeOfCreateDI = DateTime.Now;
            ImageDI = imageIndex;

            var stringBuilder = new StringBuilder("<FlowDocument xmlns=\"http://schemas.microsoft.com/winfx/2006/xaml/presentation\"><Paragraph>Hello</Paragraph><Paragraph>start you note here</Paragraph><Paragraph>enjoy ;)</Paragraph><Paragraph>enjoy ;)</Paragraph></FlowDocument>");

            NoteDI = stringBuilder.ToString();            
        }
        public MyNote() { }

    }
}