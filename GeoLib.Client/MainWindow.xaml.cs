﻿using GeoLib.Contracts;
using GeoLib.Proxies;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
//using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GeoLib.Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            this.Title = "UI Running on Thread " + Thread.CurrentThread.ManagedThreadId + " | Process " + Process.GetCurrentProcess().Id.ToString();
        }

        private void btnGetInfo_Click(object sender, RoutedEventArgs e)
        {
            if (txtZipCode.Text != "")
            {
                GeoClient proxy = new GeoClient("tcpEP");

                ZipCodeData data = proxy.GetZipInfo(txtZipCode.Text);
                if (data!= null)
                {
                    lblCity.Content = data.City;
                    lblState.Content = data.State;
                }
                proxy.Close();
            }
        }

        private void btnGetZipCodes_Click(object sender, RoutedEventArgs e)
        {
            if (txtState.Text != "")
            {
                EndpointAddress address = new EndpointAddress("net.tcp://localhost:8009/GeoService");
                Binding binding = new NetTcpBinding();
                GeoClient proxy = new GeoClient(binding, address);

                IEnumerable<ZipCodeData> data = proxy.GetZips(txtState.Text);
                if (data != null)
                {
                    lstZipCodes.ItemsSource = data;
                }
                proxy.Close();
            }
        }

        private void btnMakeCall_Click(object sender, RoutedEventArgs e)
        {

        }

    }
}
