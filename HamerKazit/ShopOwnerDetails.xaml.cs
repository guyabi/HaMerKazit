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
    /// Interaction logic for ShopOwnerDetails.xaml
    /// </summary>
    public partial class ShopOwnerDetails : Page
    {
        ShopOwnerDB db = new ShopOwnerDB();
        ShopOwner shopOwner = new ShopOwner();
        CityList cityLst;
        ShopOwnerList shopOwnerList;
        public ShopOwnerDetails()
        {
            InitializeComponent();
            this.DataContext = shopOwner;
            CityDB db = new CityDB();
            cityLst = db.SelectAll(); ;  // ממלא את רשימת הערים בדף
            this.CityCbox.ItemsSource = cityLst;
        }

        public ShopOwnerDetails(ShopOwner shopOwner1) : this()
        {
            shopOwner = shopOwner1;

            if (shopOwner.City != null) // אם מדובר במשתמש קיים
            {
                // .המתאים, כדי שיוצג כעיר שנבחרה city את המשתנה manager שם במשתנה 
                shopOwner.City = cityLst.Find(c => c.Id == shopOwner.City.Id);
            }

            this.DataContext = shopOwner;
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {

            int x;
            if (shopOwner.Id == 0)  // new
            {
                db.Insert(shopOwner);
                x = db.SaveChanges();
                if (x > 0)  // OK
                {
                    //st1.Id = x;
                    // add to list in WIN2

                }
            }

            else
            {
                db.Update(shopOwner);
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
