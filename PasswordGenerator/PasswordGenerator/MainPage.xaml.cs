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
using Microsoft.Devices;
using System.Diagnostics;

namespace PasswordGenerator
{
    public partial class MainPage : PhoneApplicationPage
    {
        const int MIN_PASSWORD_LENGHT = 8;
        
        Random random;

        enum DigitType { latin, caps, number, symbol };

        char[] latinLetters = new char[26] {   'a', 'b', 'c', 'd',
                                               'e', 'f', 'g', 'h',
                                               'i', 'j', 'k', 'l',
                                               'm', 'n', 'o', 'p',
                                               'q', 'r', 's', 't',
                                               'u', 'v', 'w', 'x',
                                               'y', 'z'
        };


        char[] caps = new char[26] {  'A', 'B', 'C', 'D',
                                      'E', 'F', 'G', 'H',
                                      'I', 'J', 'K', 'L',
                                      'M', 'N', 'O', 'P',
                                      'Q', 'R', 'S', 'T',
                                      'U', 'V', 'W', 'X',
                                      'Y', 'Z'
        };


        char[] numbers = new char[10] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };

        char[] symbols = new char[12] { '!', '@', '#', '$', '%', '^', '&', '*', '(', ')', '-', '+' };

        public MainPage()
        {
            InitializeComponent();
            random = new Random(DateTime.Now.Millisecond);
        }

        private void generateButton_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(passwordTextBox.Text) == false)
            {
                MessageBoxResult messageBoxResult = MessageBox.Show("There is already a " +
                					"generated password, are you sure" +
                					"that you want to generate a new?" +
                					"If you haven't emailed youself the" +
                					"previous one, it will be lost!", "Attention!", MessageBoxButton.OKCancel);

                if (messageBoxResult == MessageBoxResult.Cancel)
                {
                    return;
                }
            }

            VibrateController vibrate = VibrateController.Default;
            vibrate.Start(TimeSpan.FromMilliseconds(150));

            passwordTextBox.Text = "";

            int lenght = random.Next(10, 15);
            char[] password = new char[lenght];

            for (int i = 0; i < lenght; ++i)
            {
                DigitType digitType = GetRandomDigitType();

                switch (digitType)
                {
                    case DigitType.latin:
                        password[i] = latinLetters[random.Next(0, 26)];
                        break;
                    case DigitType.caps:
                        password[i] = caps[random.Next(0, 26)];
                        break;
                    case DigitType.number:
                        password[i] = numbers[random.Next(0, 10)];
                        break;
                    case DigitType.symbol:
                        password[i] = symbols[random.Next(0, 12)];
                        break;
                }
            }

            passwordTextBox.Text = new string(password);
        }

        private DigitType GetRandomDigitType()
        {
            int choice = random.Next(0, 4);

            switch (choice)
            {
                case 0:
                    return DigitType.latin;
                case 1:
                    return DigitType.caps;
                case 2:
                    return DigitType.number;
                default:
                    return DigitType.symbol;
            }
        }

        private void ApplicationBarIconButton_Click_About(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/About.xaml", UriKind.Relative));
        }

        private void ApplicationBarIconButton_Click_Email(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(passwordTextBox.Text))
            {
                MessageBox.Show("You haven't any generated password!");
                return;
            }

            if (passwordTextBox.Text.Length < MIN_PASSWORD_LENGHT)
            {
                MessageBox.Show("Any password less than " + Convert.ToString(MIN_PASSWORD_LENGHT) + 
                		"characters is considered as weak! Generate a new or add more characters");
                return;
            }

            EmailComposeTask emailTask = new EmailComposeTask();
            
            emailTask.Subject = "New password generated by PasswordGenerator";
            emailTask.Body = "PasswordGenerator Windows Phone App generated the following password:\n\n" + passwordTextBox.Text;
            emailTask.Show();
        }

        private void ApplicationBarMenuItem_Click(object sender, EventArgs e)
        {
            passwordTextBox.Text = "";
        }

        private void PhoneApplicationPage_OrientationChanged(object sender, OrientationChangedEventArgs e)
        {
            if (Orientation == PageOrientation.LandscapeLeft || Orientation == PageOrientation.LandscapeRight)
            {
                quoteTextBlock.Visibility = System.Windows.Visibility.Collapsed;
            }
            else
            {
            	quoteTextBlock.Visibility = System.Windows.Visibility.Visible;
	    }
        }

    }
}