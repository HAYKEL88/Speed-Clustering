using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace Vitess__.Pages
{
    public partial class DatabasePage : PhoneApplicationPage
    {
        public DatabasePage()
        {
            InitializeComponent();
            FetchDatabase fetch = new FetchDatabase();
            allDatas.ItemsSource = fetch.getDatas();
        }
    }
}