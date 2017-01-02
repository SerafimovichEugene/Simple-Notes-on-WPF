using Models;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace ViewModels
{
    class ViewModelNotes : ViewModelBase
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
            //_collection = new ObservableCollection<ViewModelNote>(notes.ListOfNotes);            
        }
        private void InitializeCollection()
        {

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

        


    }
}
