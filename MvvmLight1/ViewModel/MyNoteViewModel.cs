using MvvmLight1.Model;
using System;
using GalaSoft.MvvmLight;
using System.ComponentModel;

namespace MvvmLight1.ViewModel
{
    public class MyNoteViewModel : ViewModelBase
    {
        private MyNote _dataItem;
        private string _title;
        private DateTime _dateTime;
        private int _image;
        private string _note;
        public MyNoteViewModel(MyNote dataItem)
        {
            _dataItem = dataItem;
            _title = dataItem.TitleDI;
            _dateTime = dataItem.TimeOfCreateDI;            
            _image = dataItem.ImageDI;
            //_note = dataItem.NoteDI;
        }
        public MyNote DataItem
        {
            get { return _dataItem; }
            set
            {
                Set(ref _dataItem, value);
            }
        }
        public string TitleVM
        {
            get { return _title; }
            set
            {
                _dataItem.TitleDI = value;
                Set(ref _title, value);                               
            }
        }

        public int ImageVM
        {
            get { return _image; }
            set
            {
                _dataItem.ImageDI = value;
                Set(ref _image, value);
            }
        }
        public string NoteVM
        {
           
            get { return _note; }
            set
            {
                _dataItem.NoteDI = value;
                Set(ref _note, value);
            }
        }

        public DateTime TimeOfCreateVM
        {
            get { return _dateTime; }
            
        }
        

        
    }
}

