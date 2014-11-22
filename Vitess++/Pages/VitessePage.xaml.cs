using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Windows.Devices.Geolocation;
using System.Device.Location;
using Microsoft.Phone.Maps.Controls;
using System.Windows.Shapes;
using System.Windows.Media;
using System.Globalization;

namespace Vitess__.Pages
{
    public partial class VitessePage : PhoneApplicationPage
    {

        MapOverlay myLocationOverlay = null;
        MapLayer myLocationLayer = null;
        GeoCoordinate MyCoordinate;
        double speed;
        String modeTransportation = "Walker";
        bool firstDisplay = false;

        public VitessePage()
        {
            InitializeComponent();
            walker2.Opacity = 0;
            bike2.Opacity = 0;
            car2.Opacity = 0;
            StartGPS.IsEnabled = false;
            Microsoft.Phone.Maps.MapsSettings.ApplicationContext.ApplicationId = "ApplicationID";
            Microsoft.Phone.Maps.MapsSettings.ApplicationContext.AuthenticationToken = "AuthenticationToken";
        

          //  myLocationOverlay = new MapOverlay();
          //  myLocationLayer = new MapLayer();
        }



        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            if (App.Geolocator == null)
            {
                App.Geolocator = new Geolocator();
                App.Geolocator.DesiredAccuracy = PositionAccuracy.High;
                App.Geolocator.MovementThreshold = 5;
                App.Geolocator.StatusChanged += myGeoLocator_StatusChanged;
                App.Geolocator.PositionChanged += myGeoLocator_PositionChanged;
            }
        }

        protected override void OnRemovedFromJournal(System.Windows.Navigation.JournalEntryRemovedEventArgs e)
        {
            App.Geolocator.StatusChanged -= myGeoLocator_StatusChanged;
            App.Geolocator.PositionChanged -= myGeoLocator_PositionChanged;
            App.Geolocator = null;
        }



        public void StartGPSFunction()
        {
            if (App.Geolocator == null)
            {
                App.Geolocator = new Geolocator();
                App.Geolocator.DesiredAccuracy = PositionAccuracy.High;
                App.Geolocator.MovementThreshold = 5;
                App.Geolocator.StatusChanged += myGeoLocator_StatusChanged;
                App.Geolocator.PositionChanged += myGeoLocator_PositionChanged;
            }
            walker2.Opacity = 0;
            bike2.Opacity = 0;
            car2.Opacity = 0;
        }

        public void StopGPSFunction()
        {
            App.Geolocator.PositionChanged -= myGeoLocator_PositionChanged;
            App.Geolocator.StatusChanged -= myGeoLocator_StatusChanged;
            firstDisplay = false;
            App.Geolocator = null;
            walker2.Opacity = 0;
            bike2.Opacity = 0;
            car2.Opacity = 0;
        }



        void myGeoLocator_StatusChanged(Geolocator sender, StatusChangedEventArgs args)
        {
            PositionStatus ps = args.Status;
            Dispatcher.BeginInvoke(() =>
            {
                textBoxGPSStatus.Text = ps.ToString();
                walker2.Opacity = 0;
                bike2.Opacity = 0;
                car2.Opacity = 0;
            });
          
        }




        void myGeoLocator_PositionChanged(Geolocator sender, PositionChangedEventArgs args)
        {

            if (!App.RunningInBackground )
            {
                Dispatcher.BeginInvoke(() =>
                {
                    
                 //   LatitudeText.Text = args.Position.Coordinate.Latitude.ToString("0.000000");
                   // LongitudeText.Text = args.Position.Coordinate.Longitude.ToString("0.000000");

                    MyCoordinate = ConvertGeocoordinate(args.Position.Coordinate);



                    //  MyCoordinate = new GeoCoordinate(args.Position.Coordinate.Latitude, args.Position.Coordinate.Longitude);
                    speed = MyCoordinate.Speed * 3.6;
                    speed = ( double.IsNaN(speed)) ? 0.0 : speed ;

                    VitesseText.Text = speed.ToString();
                    if(firstDisplay)
                    { 
                        if(speed==0)
                        {
                            walker2.Opacity = 0;
                            bike2.Opacity = 0;
                            car2.Opacity = 0;
                            modeTransportation = "Walker";

                        }
                    else if ((speed > 0) && (speed < 6))
                    {
                        walker2.Opacity = 100;
                        bike2.Opacity = 0;
                        car2.Opacity = 0;
                        modeTransportation = "Walker";
                    }
                    else if (speed < 25)
                    {
                        walker2.Opacity = 0;
                        bike2.Opacity = 100;
                        car2.Opacity = 0;
                        modeTransportation = "Bike";
                    }
                    else
                    {
                        walker2.Opacity = 0;
                        bike2.Opacity = 0;
                        car2.Opacity = 100;
                        modeTransportation = "Car";
                    }
                    }
                    firstDisplay = true;

                    DatabaseAdd add = new DatabaseAdd();

                    CultureInfo ci = CultureInfo.InvariantCulture;

                    Data d = new Data()
                    {
                        Latitude = args.Position.Coordinate.Latitude,
                        Longitude = args.Position.Coordinate.Longitude,
                        Speed = speed,
                        DateOfPassage = new DateTime().Date.ToString("dddd dd MMMM yyyy", ci),
                        HeureOfPassage = new DateTime().Date.ToString("hh:mm:ss.F", ci)
                    };



                    ShowMyLocationOnTheMap(d.Latitude,d.Longitude);


                    add.AddData(d);


                });
                
                Tile(string.Format("Speed : {0:f2} km/h", speed), modeTransportation);

            }

            else
            {
                MyCoordinate = ConvertGeocoordinate(args.Position.Coordinate);
                speed = MyCoordinate.Speed * 3.6;
                speed = (double.IsNaN(speed)) ? 0.0 : speed; 
                if ((speed > 0) && (speed < 6))
                {
                    modeTransportation = "Walker";
                }
                else if (speed < 25)
                {
                    modeTransportation = "Bike";
                }
                else
                {
                    modeTransportation = "Car";
                }

                DatabaseAdd add = new DatabaseAdd();
                CultureInfo ci = CultureInfo.InvariantCulture;
                Data d = new Data()
                {
                    Latitude = args.Position.Coordinate.Latitude,
                    Longitude = args.Position.Coordinate.Longitude,
                    Speed = speed,
                    DateOfPassage = new DateTime().Date.ToString("dddd dd MMMM yyyy",ci),
                    HeureOfPassage = new DateTime().Date.ToString("hh:mm:ss.F", ci)
                };
                add.AddData(d);



                Tile(string.Format("Speed : {0:f2} km/h", speed), modeTransportation);
               
            }

  


        }

        private void StopGPS_Click(object sender, RoutedEventArgs e)
        {
            StopGPSFunction();
            StartGPS.IsEnabled = true;
            StopGPS.IsEnabled = false;
        }

        private void StartGPS_Click(object sender, RoutedEventArgs e)
        {
            StartGPSFunction();
            StopGPS.IsEnabled = true;
            StartGPS.IsEnabled = false;
            
        }








        public static GeoCoordinate ConvertGeocoordinate(Geocoordinate geocoordinate)
        {
            return new GeoCoordinate
                (
                geocoordinate.Latitude,
                geocoordinate.Longitude,
                geocoordinate.Altitude ?? Double.NaN,
                geocoordinate.Accuracy,
                geocoordinate.AltitudeAccuracy ?? Double.NaN,
                geocoordinate.Speed ?? Double.NaN,
                geocoordinate.Heading ?? Double.NaN
                );
        }

        private void Tile(String speed, String modeOftransportation)
        {
            IconicTileData oIcontile = new IconicTileData();
            oIcontile.Title = "Vitesse++";
            oIcontile.Count = 1;

            oIcontile.IconImage = new Uri("Assets/images/"+modeOftransportation+"2.png", UriKind.Relative);
            oIcontile.SmallIconImage = new Uri("Assets/images"+modeOftransportation+"2.png", UriKind.Relative);
            

            oIcontile.WideContent1 = speed;
            oIcontile.WideContent2 ="Mode of transportation :"+ modeOftransportation;

            oIcontile.BackgroundColor = System.Windows.Media.Colors.Orange;
           

            // find the tile object for the application tile that using "Iconic" contains string in it.
            ShellTile TileToFind = ShellTile.ActiveTiles.FirstOrDefault(x => x.NavigationUri.ToString().Contains("Iconic".ToString()));

            if (TileToFind != null && TileToFind.NavigationUri.ToString().Contains("Iconic"))
            {
                TileToFind.Update(oIcontile);
                //ShellTile.Create(new Uri("/Pages/LocationPage.xaml?id=Iconic", UriKind.Relative), oIcontile, true);
            }
            else
            {
                ShellTile.Create(new Uri("/Pages/LocationPage.xaml?id=Iconic", UriKind.Relative), oIcontile, true);
            }
        }













        private async void ShowMyLocationOnTheMap(double longitude, double latitude)
        {

            longitude = (double.IsNaN(longitude)) ? 0.0 : longitude;
            latitude = (double.IsNaN(latitude)) ? 0.0 : latitude;

            GeoCoordinate myGeocoordinate = new GeoCoordinate(longitude, latitude);

            // Make my current location the center of the Map.
            this.mapWithMyLocation.Center = myGeocoordinate;
            this.mapWithMyLocation.ZoomLevel = 13;
            Ellipse myCircle = new Ellipse();
            myCircle.Fill = new SolidColorBrush(Colors.Blue);
            myCircle.Height = 5;
            myCircle.Width = 5;
            myCircle.Opacity = 50;

            // Create a MapOverlay to contain the circle.
            myLocationOverlay = new MapOverlay();
            myLocationOverlay.Content = myCircle;
            myLocationOverlay.PositionOrigin = new Point(0.5, 0.5);
            myLocationOverlay.GeoCoordinate = myGeocoordinate;

            // Create a MapLayer to contain the MapOverlay.
            myLocationLayer = new MapLayer();
            myLocationLayer.Add(myLocationOverlay);

            // Add the MapLayer to the Map.
            mapWithMyLocation.Layers.Add(myLocationLayer);


        }












    }
}