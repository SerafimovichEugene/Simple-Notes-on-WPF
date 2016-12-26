using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using MvvmLight1.Model;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Data.Entity;
using System;
using System.IO;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;


namespace MvvmLight1.ViewModel
{


    public class MainViewModel : ViewModelBase
    {
        private static MyNotesContext context;

        private static string connectionString;


        private ObservableCollection<MyNoteViewModel> _collection;

        private MyNoteViewModel _selectedDataItem;
        private int _selectedIndex;

        public ICommand AddCommand { get; private set; }
        public ICommand SaveCommand { get; private set; }
        public ICommand LoadCommand { get; private set; }
        public ICommand InitConnectionString { get; private set; }
        public ICommand DeleteNoteCommand { get; private set; }

        public int SelectedIndex
        {
            get { return _selectedIndex; }
            set
            {
                Set(ref _selectedIndex, value);
            }
        }
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
            set
            {
                Set(ref _selectedDataItem, value);
                _selectedDataItem.IsVisible = true;
            }
        }
        public string ConnectionString
        {
            get { return connectionString; }
            set
            {
                Set(ref connectionString, value);
            }
        }

        public MainViewModel()
        {
            //string foo = global::MvvmLight1.Properties.Resources.ConnectionString;  //as example

            ConnectionString = File.ReadAllText(@"ConnectionStringFile.txt");
            MessageBox.Show(ConnectionString);
            AddCommand = new RelayCommand(AddNote);
            SaveCommand = new RelayCommand(SaveCollection);
            LoadCommand = new RelayCommand(LoadCollection);
            InitConnectionString = new RelayCommand(SourceDb);
            DeleteNoteCommand = new RelayCommand(DeleteNote);


            _collection = new ObservableCollection<MyNoteViewModel>();

            if (ConnectionString == null || ConnectionString == "")
            {
                ConnectionString = "MyNoteDB.sdf";
                File.WriteAllText(@"ConnectionStringFile.txt", ConnectionString);
                //LoadCollection();
            }
            if (ConnectionString != null && ConnectionString != "")
            {
                LoadCollection();
            }
        }

        public async void AddNote()
        {
            MyNote myNote = new MyNote("Type the header of Note", 1);
            try
            {
                _collection.Add(new MyNoteViewModel(myNote));
                using (context = new MyNotesContext(ConnectionString))
                {
                    context.MyNotes.Add(myNote);
                    int x = await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public async void SaveCollection()
        {
            context = new MyNotesContext(ConnectionString);
            try
            {
                foreach (var item in _collection)
                {
                    context.MyNotes.Attach(item.DataItem);
                    context.Entry(item.DataItem).State = EntityState.Modified;
                }
                int x = await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private async void LoadCollection()
        {
            if (ConnectionString != null)
            {
                using (context = new MyNotesContext(ConnectionString))
                {
                    try
                    {
                        var tempList = await context.MyNotes.ToListAsync();
                        foreach (var item in tempList)
                        {
                            Collection.Add(new MyNoteViewModel(item));
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            else if (ConnectionString == null || ConnectionString == "")
            {
                System.Windows.MessageBox.Show("MyNote DataBase is not initialized");
            }

        }
        public void InitConnetionString()
        {
            using (FolderBrowserDialog fbd = new FolderBrowserDialog())
            {
                DialogResult res = fbd.ShowDialog();
                if (res == DialogResult.OK)
                {
                    ConnectionString = fbd.SelectedPath + "MyNoteDB.sdf";
                    File.WriteAllText(@"ConnectionStringFile.txt", ConnectionString);
                    MessageBox.Show(connectionString);
                }

            }
        }
        public void SourceDb()
        {
            using (OpenFileDialog opd = new OpenFileDialog())
            {
                DialogResult res = opd.ShowDialog();
                if (res == DialogResult.OK)
                {
                    string path = opd.FileName;
                    MessageBox.Show(path);
                }

            }
        }

        public void DeleteNote()
        {
            try
            {
                Collection.RemoveAt(SelectedIndex);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }



        public override void Cleanup()
        {
            base.Cleanup();
        }

    }
}