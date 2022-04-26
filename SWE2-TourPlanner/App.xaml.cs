using SWE2_TourPlanner.ViewModels;
using System.Windows;

namespace SWE2_TourPlanner
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        
        private void App_OnStartup(object sender, StartupEventArgs e)
        {
            var searchBarVM = new SearchBarVM();
            var tourVM = new TourVM();

            var wnd = new MainWindow
            {
                DataContext = new MainVM(tourVM, searchBarVM),
                SearchBar = { DataContext = searchBarVM },
                Tour = { DataContext = tourVM }
            };

            wnd.Show();
        }
        
    }
}
