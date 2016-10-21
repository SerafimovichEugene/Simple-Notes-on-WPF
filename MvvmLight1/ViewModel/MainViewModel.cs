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
        private static string ConnectionString;

        private ObservableCollection<MyNoteViewModel> _collection;

        private MyNoteViewModel _selectedDataItem;
        public ICommand AddCommand { get; private set; }
        public ICommand SaveCommand { get; private set; }
        public ICommand LoadCommand { get; private set; }
        public ICommand InitConnectionString { get; set; }
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
            try
            {
                ConnectionString = File.ReadAllText("../../ConnectionString.txt");
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
            }
            AddCommand = new RelayCommand(AddNote);
            SaveCommand = new RelayCommand(SaveCollection);
            LoadCommand = new RelayCommand(LoadCollection);
            InitConnectionString = new RelayCommand(InitConnetionString);
            _collection = new ObservableCollection<MyNoteViewModel>();
            if (ConnectionString != null)
            {
                context = new MyNotesContext(ConnectionString);
                LoadCollection();
            }
        }

        private void SaveConnectionString()
        {
            File.WriteAllText("../../ConnectionString.txt", ConnectionString);
        }

        private void LoadConnectionString()
        {
            ConnectionString = File.ReadAllText("../../ConnectionString.txt");
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


        public void SaveCollection()
        {
            context = new MyNotesContext(ConnectionString);
            try
            {
                foreach (var item in _collection)
                {
                    context.MyNotes.Attach(item.DataItem);
                    context.Entry(item.DataItem).State = EntityState.Modified;
                }
                SaveForContext(context);
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
                    System.Windows.MessageBox.Show(ConnectionString);

                    SaveConnectionString();
                }

            }
        }
        //public string SourceDb()
        //{
        //    using (OpenFileDialog opd = new OpenFileDialog())
        //    {
        //        opd.ShowDialog();
        //        string path = Path.GetDirectoryName(opd.FileName) + opd.FileName;
        //        return path;
        //    }
        //}

        public async void SaveForContext(MyNotesContext obj)
        {
            await obj.SaveChangesAsync();
            obj.Dispose();
        }

        public override void Cleanup()
        {
            // Clean up if needed

            base.Cleanup();
        }

    }
}