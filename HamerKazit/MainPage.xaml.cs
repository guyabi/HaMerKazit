﻿using Model;
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

namespace HamerKazit
{
    /// <summary>
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void HomeItem_Selected(object sender, RoutedEventArgs e)
        {
            this.myFrame.Navigate(new HomePage());
        }

        private void HamburgerMenuItem_Selected_3(object sender, RoutedEventArgs e)
        {
            if (myFrame.NavigationService.CanGoBack)
                myFrame.NavigationService.GoBack();
        }

        private void HamburgerMenuItem_Selected_4(object sender, RoutedEventArgs e)
        {
            if (myFrame.NavigationService.CanGoForward)
                myFrame.NavigationService.GoForward();
        }

        private void Item1_Selected(object sender, RoutedEventArgs e)
        {
            this.myFrame.Navigate(new PassengerList1());
        }

        private void Item2_Selected(object sender, RoutedEventArgs e)
        {

        }

        private void drivers(object sender, RoutedEventArgs e)
        {
            this.myFrame.Navigate(new DriverList1());
        }

        private void Next_Bus(object sender, RoutedEventArgs e)
        {
            this.myFrame.Navigate(new NextBus());
        }

        private void shops(object sender, RoutedEventArgs e)
        {
            this.myFrame.Navigate(new Shops());
        }
    }
}
