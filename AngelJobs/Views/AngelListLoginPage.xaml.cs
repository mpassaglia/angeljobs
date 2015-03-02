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
    using System.Threading.Tasks;
    using Windows.Web.Http;

    public partial class AngelListLoginPage : PhoneApplicationPage
    {
        private const string ClientId = "46df257880dfa6959ca388c8389daf3ced0f5e3c65006a4e";
        private const string ClientSecret = "fbec8e3a42c396212c4b0b27cfac3692efb2ca0236afb79d";
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
                          "&scope=talent%20message%20email" +
                          "&response_type=code";

                webBrowser1.Navigate(new Uri(url));
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Error", MessageBoxButton.OK);
            }
        }

        private async void LoginActivated(object sender, NavigationEventArgs e)
        {
            if (!e.Uri.IsAbsoluteUri) return;
            var code = e.Uri.Query.Split('=');
            var codeString = code.GetValue(0).ToString();
            var codeValue = code.GetValue(1).ToString();

            if (!codeString.Equals("?code")) return;
            var url = "https://angel.co/api/oauth/token?" +
                      "client_id=" + ClientId +
                      "&client_secret=" + ClientSecret +
                      "&code=" + codeValue +
                      "&grant_type=authorization_code";

            var response = await GetAccessToken(url);

            //TODO: Pass response (access token) to Jobs page 
        }

        public async Task<string> GetAccessToken(string url)
        {
            using (var client = new HttpClient())
            {
                var response = await client.PostAsync(new Uri(url), null);

                return await response.Content.ReadAsStringAsync();
            }
        }
    }
}