﻿#pragma checksum "C:\Users\OUHICHI\Desktop\PLIM\Projet_PLIM\Vitess++\Vitess++\Pages\VitessePage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "BB9F8A4482EAC98D7EED2261CAA7CBFC"
//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.34014
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

using Microsoft.Phone.Controls;
using Microsoft.Phone.Maps.Controls;
using System;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Resources;
using System.Windows.Shapes;
using System.Windows.Threading;


namespace Vitess__.Pages {
    
    
    public partial class VitessePage : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.Image bike1;
        
        internal System.Windows.Controls.Image bike2;
        
        internal System.Windows.Controls.Image walker1;
        
        internal System.Windows.Controls.Image walker2;
        
        internal System.Windows.Controls.Image car1;
        
        internal System.Windows.Controls.Image car2;
        
        internal System.Windows.Controls.TextBlock VitesseLabel;
        
        internal System.Windows.Controls.TextBox VitesseText;
        
        internal System.Windows.Controls.TextBox textBoxGPSStatus;
        
        internal System.Windows.Controls.TextBlock GPSStatus;
        
        internal System.Windows.Controls.Button StartGPS;
        
        internal System.Windows.Controls.Button StopGPS;
        
        internal Microsoft.Phone.Maps.Controls.Map mapWithMyLocation;
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Windows.Application.LoadComponent(this, new System.Uri("/Vitess++;component/Pages/VitessePage.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.bike1 = ((System.Windows.Controls.Image)(this.FindName("bike1")));
            this.bike2 = ((System.Windows.Controls.Image)(this.FindName("bike2")));
            this.walker1 = ((System.Windows.Controls.Image)(this.FindName("walker1")));
            this.walker2 = ((System.Windows.Controls.Image)(this.FindName("walker2")));
            this.car1 = ((System.Windows.Controls.Image)(this.FindName("car1")));
            this.car2 = ((System.Windows.Controls.Image)(this.FindName("car2")));
            this.VitesseLabel = ((System.Windows.Controls.TextBlock)(this.FindName("VitesseLabel")));
            this.VitesseText = ((System.Windows.Controls.TextBox)(this.FindName("VitesseText")));
            this.textBoxGPSStatus = ((System.Windows.Controls.TextBox)(this.FindName("textBoxGPSStatus")));
            this.GPSStatus = ((System.Windows.Controls.TextBlock)(this.FindName("GPSStatus")));
            this.StartGPS = ((System.Windows.Controls.Button)(this.FindName("StartGPS")));
            this.StopGPS = ((System.Windows.Controls.Button)(this.FindName("StopGPS")));
            this.mapWithMyLocation = ((Microsoft.Phone.Maps.Controls.Map)(this.FindName("mapWithMyLocation")));
        }
    }
}

