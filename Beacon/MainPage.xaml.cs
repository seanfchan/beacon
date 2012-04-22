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
using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using Microsoft.Phone.Info;
using System.Diagnostics;

namespace Beacon
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
        }

        private void SignInBtn_Click(object sender, RoutedEventArgs e)
        {
            byte[] uniqueId = (byte[])DeviceExtendedProperties.GetValue("DeviceUniqueId");
            StringBuilder temp = new StringBuilder();

            foreach (byte i in uniqueId)
            {
                temp.Append(i);
            }

            Debug.WriteLine(temp.ToString());
            NavigationService.Navigate(new Uri("/Page1.xaml", UriKind.Relative));
        }
    }
}