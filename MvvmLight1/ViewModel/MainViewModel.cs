using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using MvvmLight1.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Xml.Serialization;

namespace MvvmLight1.ViewModel
{

   
    public class MainViewModel : ViewModelBase
    {
        
        public string path = "../../Path.bin";               

        private ObservableCollection<MyNoteViewModel> _collection;
       
        private MyNoteViewModel _selectedDataItem;
       
        public ICommand AddCommand { get; private set; }
        public ICommand SaveCommand { get; private set; }

        public ObservableCollection<MyNoteViewModel> Collection
        {
            get { return _collection; }
        }

        public MyNoteViewModel SelectedDataItem
        {
            get
            {
                if (_selectedDataItem != null)
                {
                    return _selectedDataItem;
                }
                else return null;
            }
            set { Set(ref _selectedDataItem, value); }
        }
              
        public MainViewModel()
        {
          
            AddCommand = new RelayCommand(AddNote);
            SaveCommand = new RelayCommand(SaveCollection);            
           
            _collection = new ObservableCollection<MyNoteViewModel>();
            
            _collection.Add(new MyNoteViewModel(new MyNote("Type the header of Note", 0)));

        }
        public void AddNote()
        {
            _collection.Add(new MyNoteViewModel(new MyNote("Type the header of Note",1)));
        }



        public void SaveCollection()
        {
            //XmlSerializer formatter = new XmlSerializer(typeof(ObservableCollection<MyNoteViewModel>));
            //using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            //{
            //    formatter.Serialize(fs, Collection);                
            //}
            //MessageBox.Show("Successful");
            //BinaryFormatter formatter = new BinaryFormatter();
            //using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            //{
            //    formatter.Serialize(fs, _collection);
            //}
            //MessageBox.Show("Serilized");
        }
        public void LoadCollection()
        {
            //XmlSerializer formatter = new XmlSerializer(typeof(ObservableCollection<MyNoteViewModel>));
            //using (FileStream fs = new FileStream(path, FileMode.Open))
            //{
            //    _collection = new ObservableCollection<MyNoteViewModel>((ObservableCollection<MyNoteViewModel>)formatter.Deserialize(fs));
            //}
            //BinaryFormatter formatter = new BinaryFormatter();
            //using (FileStream fs = new FileStream(path, FileMode.Open))
            //{
            //    _collection = new ObservableCollection<MyNoteViewModel>((ObservableCollection<MyNoteViewModel>)formatter.Deserialize(fs));
            //}
        }
        ////public override void Cleanup()
        ////{
        ////    // Clean up if needed

        ////    base.Cleanup();
        ////}
    }
}