using PokeRater;
using System;
using System.Windows;

namespace PokeRaterUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new RaterViewModel(new DualEloPlayer());
        }
    }
}
