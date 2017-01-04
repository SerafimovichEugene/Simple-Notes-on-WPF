using System;
using System.Windows;

namespace Views
{
    public partial class MainWindow : Window
    {
        private ViewModels.ViewModelNotes vm;
        public MainWindow()
        {
            InitializeComponent();
            DataContext = (Application.Current as App).GetViewModel(GetType().Name);
            vm = (Application.Current as App).GetViewModel(GetType().Name);
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            vm.SaveNotes(sender);
        }
    }
}