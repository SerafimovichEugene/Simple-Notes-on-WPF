using System;
using System.Windows;

namespace Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = (Application.Current as App).GetViewModel(GetType().Name);
        }
       
    }
}