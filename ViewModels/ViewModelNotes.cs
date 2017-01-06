using Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace ViewModels
{
    public class ViewModelNotes : ViewModelBase
    {
        private ObservableCollection<ViewModelNote> _collection;
        private Notes _notes;
        private ViewModelNote _selectedDataItem;
        private int _selectedIndex;
        private Queue<ViewModelNote> _queueForVisibility=new Queue<ViewModelNote>(2);
        public ICommand AddCommand { get; private set; }
        public ICommand SaveCommand { get; private set; }     
        public ICommand DeleteNoteCommand { get; private set; }
        public ViewModelNotes()
        {
            _notes = new Notes();

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
                _queueForVisibility.Enqueue(_selectedDataItem);
                SetVisibilityDeleteButton();
            }
        }

        private void InitializeCollection()
        {
            _collection = new ObservableCollection<ViewModelNote>();
            foreach (var item in _notes.ListOfNotes)
            {
                _collection.Add(new ViewModelNote(item));
            }
        }

        private void InitializeCommands()
        {
            AddCommand = new RelayCommand(AddNote);
            SaveCommand = new RelayCommand(SaveNotes);
            DeleteNoteCommand = new RelayCommand(DeleteNote);
        }

        private void AddNote(object obj)
        {
            Note tempNote = new Note("Title here", 1);
            _notes.AddNote(tempNote);
            _collection.Add(new ViewModelNote(tempNote));            
        }
        public void SaveNotes(object obj)
        {
            _notes.SaveNotes();
        }
        private void DeleteNote(object obj)
        {
            _notes.DeleteNote(_collection[SelectedIndex].ModelNote.Id);            
            _collection.Remove(_collection[SelectedIndex]);
            _queueForVisibility.Clear();
        }
        private void SetVisibilityDeleteButton()
        {           
            if (_queueForVisibility.Peek() != null && _queueForVisibility.Count == 2)
                _queueForVisibility.Dequeue().IsAbleToDelete = false;
            if (_selectedDataItem != null)
                _selectedDataItem.IsAbleToDelete = true;
        }
        
    }
}
