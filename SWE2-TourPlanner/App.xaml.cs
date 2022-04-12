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
            var tourListVM = new TourListVM();
            var tourDetailsVM = new TourDetailsVM();

            var wnd = new MainWindow
            {
                DataContext = new MainVM(tourListVM,searchBarVM,tourDetailsVM),
                SearchBar = { DataContext = searchBarVM },
                TourList = { DataContext = tourListVM },
                TourDetails = { DataContext = tourDetailsVM }
            };

            wnd.Show();
        }
        
    }
}
