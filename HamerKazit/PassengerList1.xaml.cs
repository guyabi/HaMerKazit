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
using Model;
using ViewModel;
namespace HamerKazit
{
    /// <summary>
    /// Interaction logic for PassengerList1.xaml
    /// </summary>
    /// 
    public partial class PassengerList1 : Page
    {

        private Passenger passenger; // "עצם "בטיפול
        private PassengerList list;
        PassengerDB db;

        private Mode mode;

        public PassengerList1()
        {
            InitializeComponent();
            db = new PassengerDB();
            list = db.SelectAll();
            this.lstView.ItemsSource = list;
            mode = Mode.None;
        }
        private void lstView_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            passenger = this.lstView.SelectedItem as Passenger;   // קבלה של העצם שנבחר מהרשימה

        }



        private void MenuItem_Upd(object sender, RoutedEventArgs e)
        {
            mode = Mode.Update;

            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new PassengerDetails(passenger));   // נשלח את המשתמש שנבחר כפרמטר לבנאי של הדף
        }

        private void MenuItem_Del(object sender, RoutedEventArgs e)
        {
            db.Delete(passenger);
            int x = db.SaveChanges();
            if (x > 0)  // OK
            {
                this.list.Remove(passenger);
                RefreshPassengerList();
            }

            else
            {


            }
            //this.lstView.ItemsSource = null;  // force refresh
            //this.lstView.ItemsSource = lst;


        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigating += NavigationService_Navigating;

        }

        private void NavigationService_Navigating(object sender, NavigatingCancelEventArgs e)
        {
            if (e.NavigationMode == NavigationMode.Back)
            {
                if (mode == Mode.Insert)  //insert Mode
                {
                    this.list.Add(passenger);
                }
                if (mode == Mode.Update)
                {
                    // .....   לא צריך לעשות כלום, כרגע, כי זה אותו העצם
                }


                //this.lstView.ItemsSource = null;  // force refresh
                //this.lstView.ItemsSource = list;
                RefreshPassengerList();

                mode = Mode.None;
            }


        }

        private void RefreshPassengerList()
        {
            //this.lstView.Items.Refresh();
            this.lstView.ItemsSource = null;  // force refresh
            this.lstView.ItemsSource = list;
        }

        private void btnAddUser_Click(object sender, RoutedEventArgs e)
        {
            passenger = new Passenger();
            mode = Mode.Insert;
            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new PassengerDetails(passenger));  //נשלח את פעולת ההמשך כפרמטר לבנאי
        }
    }
 
}
