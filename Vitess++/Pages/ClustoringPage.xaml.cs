using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Vitesse__;
using Microsoft.Phone.Maps.Controls;
using System.Device.Location;
using System.Windows.Shapes;
using System.Windows.Media;

namespace Vitess__.Pages
{
    public partial class ClustoringPage : PhoneApplicationPage
    {
     //   MapOverlay myLocationOverlay = null;
     //   MapLayer myLocationLayer = null;
        List<Data> myList = null;
        List<Cluster> allClusters = null;
        int numberClustersInt = 2;
        double[][] rawData = null;
        int[] clustering = null;

        bool Walker = true;
        bool Bike = true;
        bool Car = true;

        Color[] tabColor = new Color[13]; 


        public ClustoringPage()
        {
            InitializeComponent();
        
            Microsoft.Phone.Maps.MapsSettings.ApplicationContext.ApplicationId = "ApplicationID";
            Microsoft.Phone.Maps.MapsSettings.ApplicationContext.AuthenticationToken = "AuthenticationToken";
        
           init_clustoring();

        }




        public void init_clustoring()
        {
            //  Dispatcher.BeginInvoke(() =>
              //  {
            tabColor[0]= Colors.Black;
            tabColor[1]= Colors.Blue;
            tabColor[2] = Colors.Yellow;       
            tabColor[3]= Colors.Green;
            tabColor[4]= Colors.Magenta;
            tabColor[5]= Colors.Orange;
            tabColor[6]= Colors.Purple;
            tabColor[7] = Colors.Red;
            tabColor[8] = Colors.Cyan;
            tabColor[9] = Colors.DarkGray;
            tabColor[10] = Colors.Gray;
            tabColor[11] = Colors.LightGray;
            tabColor[12] = Colors.Brown;
            FetchDatabase fetch=new FetchDatabase();
            myList = fetch.GetAllDatas().ToList<Data>();
            KMeans kmeans = new KMeans();
            allClusters = new List<Cluster>(numberClustersInt);
           // myLocationOverlay = new MapOverlay();
           // myLocationLayer = new MapLayer();


            double[][] rawDataOriginal = new double[myList.Count][];
            int coco = 0;
            for (int j = 0; j < myList.Count; j++)
            {
                if (((Walker == true) && (myList[j].Speed < 6)) || ((Bike == true) && (myList[j].Speed < 25) && (myList[j].Speed >= 6)) || ((Car == true) && (myList[j].Speed > 25)))
                {
                    rawDataOriginal[coco] = new double[] { myList[j].Latitude, myList[j].Longitude };
                    coco++;
                }

            }
            rawData = new double[coco][];
            for (int j = 0; j < coco; j++)
            {
                rawData[j] = rawDataOriginal[j];

            }


            if (coco > numberClustersInt)
            {
                clustering = kmeans.Cluster(rawData, numberClustersInt);

                updateListClusters();
                int i, k;

                for (i = 0; i < numberClustersInt; i++)
                {
                    for (k = 0; k < allClusters[i].Datas.Count; k++)
                    {

                        ShowMyLocationOnTheMap(allClusters[i].Datas[k].Latitude, allClusters[i].Datas[k].Longitude, tabColor[i]);


                    }
                }

                incrementNumberClusters.IsEnabled = true;
                decrementNumberClusters.IsEnabled = true;

                //    });

            }
        }




        private void decrementNumberClusters_Click(object sender, RoutedEventArgs e)
        {

            
            try
            {
                if (numberClustersInt > 2)
                {
                    numberClustersInt--;
                }
                numberClusters.Text = numberClustersInt.ToString();
                
               
            }
            catch(Exception ex)
            {
                incrementNumberClusters.IsEnabled = true;
                decrementNumberClusters.IsEnabled = true;
            }
        }




        private void incrementNumberClusters_Click(object sender, RoutedEventArgs e)
        {
            
             
            if ((numberClustersInt < 13)&&(numberClustersInt <= myList.Count))
            {
                numberClustersInt++;
            }
            numberClusters.Text = numberClustersInt.ToString();
            
          
        }





        public void updateListClusters()
        {

            Cluster clus = null;


            for (int i = 0; i < numberClustersInt; i++)
            {
                 clus=new Cluster();
                clus.IdCluster=i;
                clus.Datas = new List<Data>();
                for (int j = 0; j < rawData.Length; j++)
                {
                    
                    if(i==clustering[j])
                    {
                        clus.Datas.Add(myList[j]);
                    }

                }

                allClusters.Add(clus);
            }

           


        }



        private  void ShowMyLocationOnTheMap(double latitude, double longitude, Color color)
        {

            longitude = (double.IsNaN(longitude)) ? 0.0 : longitude;
            latitude = (double.IsNaN(latitude)) ? 0.0 : latitude;

            GeoCoordinate myGeocoordinate = new GeoCoordinate(latitude, longitude);

            // Make my current location the center of the Map.
            this.mapWithMyLocation.Center = myGeocoordinate;
            this.mapWithMyLocation.ZoomLevel = 13;
            Ellipse myCircle = new Ellipse();
            myCircle.Fill = new SolidColorBrush(color);
            myCircle.Height = 5;
            myCircle.Width = 5;
            myCircle.Opacity = 50;

            // Create a MapOverlay to contain the circle.
            var  myLocationOverlay = new MapOverlay();
            myLocationOverlay.Content = myCircle;
            myLocationOverlay.PositionOrigin = new Point(0.5, 0.5);
            myLocationOverlay.GeoCoordinate = myGeocoordinate;

            // Create a MapLayer to contain the MapOverlay.
            var myLocationLayer = new MapLayer();
            myLocationLayer.Add(myLocationOverlay);

            // Add the MapLayer to the Map.
            mapWithMyLocation.Layers.Add(myLocationLayer);


        }

        




        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Walker = false;
            Bike = false;
            Car = false;
            if (WalkerRadio.IsChecked == true)
                Walker = true;
            if (BikeRadio.IsChecked == true)
                Bike = true;
            if (CarRadio.IsChecked == true)
                Car = true;


            mapWithMyLocation.Layers.Clear();
            init_clustoring();
        }




    }
}