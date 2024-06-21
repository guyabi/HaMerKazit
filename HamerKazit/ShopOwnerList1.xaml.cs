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
    /// Interaction logic for ShopOwnerList1.xaml
    /// </summary>
    public partial class ShopOwnerList1 : Page
    {
        private ShopOwner shopOwner; // "עצם "בטיפול
        private ShopOwnerList list;
        ShopOwnerDB db;

        private Mode mode;

        public ShopOwnerList1()
        {
            InitializeComponent();
            db = new ShopOwnerDB();
            list = db.SelectAll();
            this.lstView.ItemsSource = list;
            mode = Mode.None;
        }
        private void lstView_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            shopOwner = this.lstView.SelectedItem as ShopOwner;   // קבלה של העצם שנבחר מהרשימה

        }



        private void MenuItem_Upd(object sender, RoutedEventArgs e)
        {
            mode = Mode.Update;

            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new ShopOwnerDetails(shopOwner));   // נשלח את המשתמש שנבחר כפרמטר לבנאי של הדף
        }

        private void MenuItem_Del(object sender, RoutedEventArgs e)
        {
            db.Delete(shopOwner);
            int x = db.SaveChanges();
            if (x > 0)  // OK
            {
                this.list.Remove(shopOwner);
                RefreshShopOwnerList();
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
                    this.list.Add(shopOwner);
                }
                if (mode == Mode.Update)
                {
                    // .....   לא צריך לעשות כלום, כרגע, כי זה אותו העצם
                }


                //this.lstView.ItemsSource = null;  // force refresh
                //this.lstView.ItemsSource = list;
                RefreshShopOwnerList();

                mode = Mode.None;
            }


        }

        private void RefreshShopOwnerList()
        {
            //this.lstView.Items.Refresh();
            this.lstView.ItemsSource = null;  // force refresh
            this.lstView.ItemsSource = list;
        }

        private void btnAddUser_Click(object sender, RoutedEventArgs e)
        {
            shopOwner = new ShopOwner();
            mode = Mode.Insert;
            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new ShopOwnerDetails(shopOwner));  //נשלח את פעולת ההמשך כפרמטר לבנאי
        }
    }
}
