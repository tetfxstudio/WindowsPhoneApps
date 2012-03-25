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
using Microsoft.Phone.Tasks;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Cryptography
{
    public partial class MainPage : PhoneApplicationPage
    {
        public MainPage()
        {
            InitializeComponent();

            DataContext = App.ViewModel;
            this.Loaded += new RoutedEventHandler(MainPage_Loaded);
        }

        private void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            if (!App.ViewModel.IsDataLoaded)
            {
                App.ViewModel.LoadData();
            }
        }

        private void encryptButton_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(cleanInputTextBox.Text))
            {
                MessageBox.Show("Type a clean text to encrypt!");
                return;
            }

            cipherOutputTextBox.Text = Encrypt(cleanInputTextBox.Text);
        }

        private void decryptButton_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(cipherInputTextBox.Text))
            {
                MessageBox.Show("Copy and paste an encrypted text from Cryptography App in order to decrypt it!");
                return;
            }

            cleanOuputTextBox.Text = Decrypt(cipherInputTextBox.Text);
        }

        private void twitterLink_Click(object sender, RoutedEventArgs e)
        {
            WebBrowserTask task = new WebBrowserTask();
            task.URL = "http://mobile.twitter.com/PanosSakkos";
            task.Show();
        }


        private string Encrypt(string clean)
        {
            char[] cipher = new char[clean.Length];

            for (int i = 0; i < clean.Length; +i)
	    {
    		cipher[i] = (char) (clean[i] + 100);
	    }

            return new string(cipher);
        }

        private string Decrypt(string cipher)
        {
            char[] clean = new char[cipher.Length];

            for (int i = 0; i < cipher.Length; ++i)
            {
                clean[i] = (char)(cipher[i] - 100);
            }

            return new string(clean);
        }
    
    }
}