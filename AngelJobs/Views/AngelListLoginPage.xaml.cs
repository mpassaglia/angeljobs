using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using AngelJobs.Resources;

namespace AngelJobs
{
    using System.ServiceModel.Channels;

    public partial class AngelListLoginPage : PhoneApplicationPage
    {
        private const string ClientId = "46df257880dfa6959ca388c8389daf3ced0f5e3c65006a4e";
        // Constructor
        public AngelListLoginPage()
        {
            InitializeComponent();

            // Sample code to localize the ApplicationBar
            //BuildLocalizedApplicationBar();
        }

        // Sample code for building a localized ApplicationBar
        //private void BuildLocalizedApplicationBar()
        //{
        //    // Set the page's ApplicationBar to a new instance of ApplicationBar.
        //    ApplicationBar = new ApplicationBar();

        //    // Create a new button and set the text value to the localized string from AppResources.
        //    ApplicationBarIconButton appBarButton = new ApplicationBarIconButton(new Uri("/Assets/AppBar/appbar.add.rest.png", UriKind.Relative));
        //    appBarButton.Text = AppResources.AppBarButtonText;
        //    ApplicationBar.Buttons.Add(appBarButton);

        //    // Create a new menu item with the localized string from AppResources.
        //    ApplicationBarMenuItem appBarMenuItem = new ApplicationBarMenuItem(AppResources.AppBarMenuItemText);
        //    ApplicationBar.MenuItems.Add(appBarMenuItem);
        //}

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            try
            {
                var url = "https://angel.co/api/oauth/authorize?" +
                                   "client_id=" + ClientId +
                                   "&response_type=code";

                webBrowser1.Navigate(new Uri(url));
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Error", MessageBoxButton.OK);
            }
        }

//        private void WebBrowser1_OnNavigated(object sender, NavigationEventArgs e)
//        {
//            if (e.Uri.IsAbsoluteUri)
//            {
//                string code = e.Uri.Query.ToString();
//                string[] split = code.Split(new Char[] { '=' });
//                string codeString = split.GetValue(0).ToString();
//                string codeValue = split.GetValue(1).ToString();
//                if (codeValue.Length > 0)
//                {
//                    var url = "https://graph.facebook.com/oauth/access_token?client_id=<Your Key>
//&redirect_uri=https://www.facebook.com/connect/login_success.html&client_secret=<Your Secret>&code=" + codeValue;
 
//                    //call access token
//                    WebRequest request = WebRequest.Create(url); //FB access token Link
//                    request.BeginGetResponse(new AsyncCallback(this.ResponseCallback_AccessToken), request);
//                }
//            }
//            else
//                return;

//        }
    }
}