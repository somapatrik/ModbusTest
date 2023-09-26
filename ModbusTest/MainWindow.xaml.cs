using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using EasyModbus;

namespace ModbusTest
{
    public partial class MainWindow : Window
    {
       MainViewModel viewModel;
        public MainWindow()
        {
            InitializeComponent();
            DataContext = viewModel = new MainViewModel();
           
        }


    }
}
