using CardioVaskular.ViewModels;
using CardioVaskular.Views;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CardioVaskular
{

    public partial class MainWindow : Window
    {

        // Liste mit den Views, die durchlaufen werden sollen
        private readonly List<UserControl> _views = new List<UserControl>();
        private int _currentViewIndex = 0; // Der aktuelle Index in der Liste der Views

        public MainWindow()
        {
            InitializeComponent(); 

         
            // ViewModels
            ProfileViewModel context1 = new(); // Daten aus dem 'ProfileViewModel' werden somit Global zugänglich gemacht
            DataContext = context1;

            OutlookViewModel context2 = new(); // Daten aus dem 'ProfileViewModel' werden somit Global zugänglich gemacht
            DataContext = context2;

        }

        

        private void StudentViewControl_Loaded(object sender, RoutedEventArgs e)
        {
            CardioVaskular.ViewModels.ProfileViewModel ProfileViewModelObject =
               new CardioVaskular.ViewModels.ProfileViewModel();
            

            DataContext = ProfileViewModelObject;
        }

        // Event-Handler für ProfileView
        private void ShowProfileView(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new Views.ProfileView();
        }

        // Event-Handler für HeartAgeView
        private void ShowHeartAgeView(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new Views.HeartAgeView();
        }

        // Event-Handler für HealthyYearsView
        private void ShowHealthyYearsView(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new Views.HealthyYearsView();
        }

        // Event-Handler für OutlookView
        private void ShowOutlookView(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new Views.OutlookView();
        }

        
    }
}