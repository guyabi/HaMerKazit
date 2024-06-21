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
using HamerKazit.ServiceReference1;

namespace HamerKazit
{
    /// <summary>
    /// Interaction logic for PassengerDetails.xaml
    /// </summary>
    public partial class PassengerDetails : Page
    {

        PassengerDB db = new PassengerDB();
        Passenger passenger = new Passenger();
        //CityList cityLst;
        private ServiceReference1.CityList cityLst;
        PassengerList passengerList;
        Service1Client srv;
        public PassengerDetails()
        {
            InitializeComponent();
            this.DataContext = passenger;
            //CityDB db = new CityDB();
            //cityLst = db.SelectAll(); ;  // ממלא את רשימת הערים בדף
            srv = new Service1Client();
            ServiceReference1.CityList cityLst = srv.SelectAllCities();
            this.CityCbox.ItemsSource = cityLst;
        }

        public PassengerDetails(Passenger passenger1): this()
        {
            passenger = passenger1;

            if (passenger.City != null) // אם מדובר במשתמש קיים
            {
                // .המתאים, כדי שיוצג כעיר שנבחרה city את המשתנה manager שם במשתנה 
                passenger.City = cityLst.Find(c => c.Id == passenger.City.Id);
            }

            this.DataContext = passenger;
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {

            int x;
            if (passenger.Id == 0)  // new
            {
                db.Insert(passenger);
                x = db.SaveChanges();
                if (x > 0)  // OK
                {
                    //st1.Id = x;
                    // add to list in WIN2

                }
            }

            else
            {
                db.Update(passenger);
                x = db.SaveChanges();
            }

            //if (x <= 0)
            //{
            //    // error msg
            //}


            NavigationService nav = NavigationService.GetNavigationService(this);
            if (nav.CanGoBack)
                nav.GoBack();


        }
    }
}
