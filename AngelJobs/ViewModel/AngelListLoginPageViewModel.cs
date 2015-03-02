using GalaSoft.MvvmLight;

namespace AngelJobs.ViewModel
{
    using System;
    using System.Net;
    using System.Windows.Navigation;
    using AngelJobs.Model;
    using GalaSoft.MvvmLight.Command;
    using GalaSoft.MvvmLight.Views;
    using NavigationService = GalaSoft.MvvmLight.Views.NavigationService;

    public class AngelListLoginPageViewModel : ViewModelBase
    {
        private readonly IDataService _dataService;
        private readonly INavigationService _navigationService;
        private readonly NavigationService navigationService = new NavigationService();

        private RelayCommand _browseToLoginCommand;

        public AngelListLoginPageViewModel()
        {
            _navigationService = navigationService;
        }

        
        //public RelayCommand BrowseToLoginCommand
        //{
        //    get
        //    {
        //        return _browseToLoginCommand
        //               ?? (_browseToLoginCommand = new RelayCommand(() =>
        //               {
        //                   const string clientID = "46df257880dfa6959ca388c8389daf3ced0f5e3c65006a4e";
        //                   var url = "https://angel.co/api/oauth/authorize?" +
        //                             "client_id=" + clientID +
        //                             "&response_type=code";


        //               }));
        //    }
        //}
    }
}