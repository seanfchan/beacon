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

namespace Beacon
{
    public partial class Page1 : PhoneApplicationPage
    {
        List<Friend> FriendList;

        // Constructor
        public Page1()
        {
            InitializeComponent();
            FriendList = new List<Friend>();
        }

        private void FindFriendsBtn_Click(object sender, RoutedEventArgs e)
        {
            GetLocation();
        }

        public List<Friend> GetLocation()
        {
            string uri = "http://seanfchan.com/beacon/getLocations.php";
            WebClient wc = new WebClient();
            wc.UploadStringCompleted += new UploadStringCompletedEventHandler(wc_UploadStringCompleted);
            wc.UploadStringAsync(new Uri(uri), "");

            return FriendList;
        }

        public void wc_UploadStringCompleted(object sender, UploadStringCompletedEventArgs e)
        {
            try
            {
                string temp = (string)e.Result;
                MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(e.Result));
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(List<Friend>));
                //Beacon beaconList;
                //DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(Beacon));
                FriendList = serializer.ReadObject(ms) as List<Friend>;


                FriendList_UI.ItemsSource = FriendList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }

    [DataContractAttribute]
    public class Friend
    {
        [DataMember]
        public String Name { get; set; }
        [DataMember]
        public double Latitude { get; set; }
        [DataMember]
        public double Longitude { get; set; }

        public Friend(String name, double latitude, double longitude)
        {
            this.Name = name;
            this.Latitude = latitude;
            this.Longitude = longitude;
        }
    }
}