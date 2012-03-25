using System;
using System.Text.RegularExpressions;
using System.Net;
using System.Windows;
using Microsoft.Phone.Controls;
using System.Net.NetworkInformation;
using Microsoft.Phone.Tasks;
using Microsoft.Devices;

namespace MyIP
{
    public partial class MainPage : PhoneApplicationPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private string ip = null;

        void client_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            waitBar.Visibility = System.Windows.Visibility.Collapsed;
            waitLabel.Visibility = System.Windows.Visibility.Collapsed; 

            if (e.Error != null)
            {   
                MessageBox.Show("Something went wrong. Please, try again later");
                textBlock.Text = "Can't get your IP";
                return;
            }

            textBlock.Visibility = System.Windows.Visibility.Visible;
            ip = textBlock.Text = e.Result;            
        }

        private new void Loaded(object sender, RoutedEventArgs e)
        {
            GetIP();
        }

        private void ApplicationBarIconButton_Click_About(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/About.xaml", UriKind.Relative));
        }

        private void ApplicationBarIconButton_Click_Refresh(object sender, EventArgs e)
        {
            waitBar.Visibility = System.Windows.Visibility.Visible;
            waitLabel.Visibility = System.Windows.Visibility.Visible;
            textBlock.Visibility = System.Windows.Visibility.Collapsed;
            Vibrate();
            GetIP();
        }

        private void ApplicationBarIconButton_Click_Email(object sender, EventArgs e)
        {
            if (ip == null)
            {
                MessageBox.Show("You do not have an IP address. Check your internet connection and try again!");
                return;
            }

            EmailComposeTask emailTask = new EmailComposeTask();
            emailTask.Subject = "Your IP";
            emailTask.Body = "Hey, the external IP address of your Windows Phone is " + ip;
            emailTask.Show();
        }

        private void GetIP()
        {
            if (NetworkInterface.GetIsNetworkAvailable() == false)
            {
                MessageBox.Show("In order to have an IP address you have to be connected to a network!");
                textBlock.Text = "You do not have one";
                waitBar.Visibility = System.Windows.Visibility.Collapsed;
                waitLabel.Visibility = System.Windows.Visibility.Collapsed;
            }
            else
            {
                WebClient client = new WebClient();
                client.DownloadStringCompleted += new DownloadStringCompletedEventHandler(client_DownloadStringCompleted);
                client.DownloadStringAsync(new Uri("http://cgi.di.uoa.gr/~std07163/myip.php"));
            }        
        }

        private void Vibrate()
        {
            VibrateController vibrate = VibrateController.Default;
            vibrate.Start(TimeSpan.FromMilliseconds(250));
        }
    }
}