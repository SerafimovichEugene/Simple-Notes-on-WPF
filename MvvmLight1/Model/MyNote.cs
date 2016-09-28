using System;

namespace MvvmLight1.Model
{
   
    public class MyNote
    {
        private string _title;
        private DateTime _dateTime;
        private int _image;
        private string _note;       
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
            NoteDI = string.Empty;            
        }

    }
}