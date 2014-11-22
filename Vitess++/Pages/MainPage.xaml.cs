using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using Vitess__;

namespace Vitesse__
{
    public partial class AboutPage : PhoneApplicationPage
    {
        public AboutPage()
        {
            InitializeComponent();
            using (DataDataContext context = new DataDataContext(DataDataContext.DBConnectionString))
            {
                if (!context.DatabaseExists())
                    context.CreateDatabase();
            }
        }

        private void Transportation_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Pages/LocationPage.xaml", UriKind.Relative));
        }

        private void Location_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Pages/VitessePage.xaml", UriKind.Relative));
        }

        private void Historic_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Pages/DatabasePage.xaml", UriKind.Relative));
        }

        private void ClustoringSimulation_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Pages/ClustoringSimulationPage.xaml", UriKind.Relative));
        }

        private void Help_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Pages/HelpPage.xaml", UriKind.Relative));
        }

        private void About_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Pages/AboutPage.xaml", UriKind.Relative));
        }

        private void Clustoring_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Pages/ClustoringPage.xaml", UriKind.Relative));

        }

        




        
    }
}