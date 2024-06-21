using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ViewModel;

namespace HamerKazit
{
    /// <summary>
    /// Interaction logic for SignUp.xaml
    /// </summary>
    public partial class SignUp : Page
    {
        PassengerDB db = new PassengerDB();
        Passenger passenger = new Passenger();
        CityList cityLst;
        PassengerList passengerList;
        public SignUp()
        {
            InitializeComponent();
            this.DataContext = passenger;
            CityDB db = new CityDB();
            cityLst = db.SelectAll(); ;  // ממלא את רשימת הערים בדף
            this.CityCbox.ItemsSource = cityLst;
        }


        private void login_Click(object sender, RoutedEventArgs e)
        {
            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new Login());
        }

        private void signUpBtn_Click(object sender, RoutedEventArgs e)
        {
            db.Insert(passenger);
            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new Login());
        }
    }
}
