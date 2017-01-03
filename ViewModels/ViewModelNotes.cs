using Models;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace ViewModels
{
    public class ViewModelNotes : ViewModelBase
    {
        private ObservableCollection<ViewModelNote> _collection;
        private Notes notes;
        private ViewModelNote _selectedDataItem;
        private int _selectedIndex;

        public ICommand AddCommand { get; private set; }
        public ICommand SaveCommand { get; private set; }
        public ICommand LoadCommand { get; private set; }
        public ICommand InitConnectionString { get; private set; }
        public ICommand DeleteNoteCommand { get; private set; }


        public ViewModelNotes()
        {
            notes = new Notes();
            InitializeCollection();
            InitializeCommands();
        }         
        public int SelectedIndex
        {
            get { return _selectedIndex; }
            set
            {
                Set(ref _selectedIndex, value);
            }
        }
        public ObservableCollection<ViewModelNote> Collection
        {
            get { return _collection; }
        }
        public ViewModelNote SelectedDataItem
        {
            get
            {
                if (_selectedDataItem != null)
                {
                    return _selectedDataItem;
                }
                else return null;
            }
            set
            {
                Set(ref _selectedDataItem, value);
            }
        }

        private void InitializeCollection()
        {
            _collection = new ObservableCollection<ViewModelNote>();
            foreach (var item in notes.ListOfNotes)
            {
                _collection.Add(new ViewModelNote(item));
            }
        }

        private void InitializeCommands()
        {
            AddCommand = new RelayCommand(AddNote);
        }

        private void AddNote(object obj)
        {
            TextNote tempNote = new TextNote("Title here", 1);
            _collection.Add(new ViewModelNote(tempNote));
            notes.AddNote(tempNote);
        }


    }
}
