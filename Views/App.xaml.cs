using System.Windows;
using System;
using ViewModels;

namespace Views
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public ViewModelNotes MainViewModel { get; set; }

        public ViewModelNotes GetViewModel(string modelName)
        {
            return MainViewModel;
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            MainViewModel = new ViewModelNotes();            
        }

        static App()
        {
                      
        }
    }
}
