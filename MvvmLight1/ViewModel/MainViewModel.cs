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
using System.Data.Entity;
using System.Linq;
using System.Windows;
using System.Threading.Tasks;

namespace MvvmLight1.ViewModel
{


    public class MainViewModel : ViewModelBase
    {

        private static MyNotesContext context;

        private ObservableCollection<MyNoteViewModel> _collection;

        private MyNoteViewModel _selectedDataItem;

        public ICommand AddCommand { get; private set; }
        public ICommand SaveCommand { get; private set; }
        public ICommand LoadCommand { get; private set; }
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
            //LoadCommand = new RelayCommand(LoadCollection);

            _collection = new ObservableCollection<MyNoteViewModel>();

            var loadCollection = LoadCollection();

            //_collection.Add(new MyNoteViewModel(new MyNote("Type the header of Note", 0)));

        }
        public void AddNote()
        {
            _collection.Add(new MyNoteViewModel(new MyNote("Type the header of Note", 1)));
        }
        public void SaveCollection()
        {
            using (context = new MyNotesContext())
            {
                foreach (var item in _collection)
                {
                    context.MyNotes.Add(item.DataItem);
                }
                context.SaveChanges();
            }
        }
        private async Task LoadCollection()
        {
            using (context = new MyNotesContext())
            {
                //for (int i = 0; i < context.MyNotes.Count(); i++)
                //{
                //    Collection.Add(new MyNoteViewModel(context.MyNotes.)
                //}
                var tempList = await context.MyNotes.ToListAsync();
                foreach (var item in tempList)
                {
                    Collection.Add(new MyNoteViewModel(item));
                }
            }
        }
        public override void Cleanup()
        {
            // Clean up if needed

            base.Cleanup();
        }
    }
}