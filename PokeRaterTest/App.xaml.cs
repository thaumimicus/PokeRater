﻿using PokeRaterUI;
using System.Windows;

namespace PokeRaterTest
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            var window = new MainWindow(new RaterViewModel(new DualEloPlayerTest()));
            window.Show();
        }
    }
}
