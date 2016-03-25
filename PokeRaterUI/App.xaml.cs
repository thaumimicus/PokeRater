using PokeRater;
using System.Windows;

namespace PokeRaterUI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            var window = new MainWindow (new RaterViewModel(new DualEloPlayer()));
            window.Show();
        }
    }
}
