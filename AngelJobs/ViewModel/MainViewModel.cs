using GalaSoft.MvvmLight;
using AngelJobs.Model;
using GalaSoft.MvvmLight.Views;
using GalaSoft.MvvmLight.Command;

namespace AngelJobs.ViewModel
{
    using System;

    public class MainViewModel : ViewModelBase
    {
        public const string LoginPageKey = "Page2";
        private readonly IDataService _dataService;
        private readonly INavigationService _navigationService;
        private readonly NavigationService navigationService = new NavigationService();

        private RelayCommand _goToAngelListLoginPage;

        public MainViewModel(IDataService dataService)
        {
            navigationService.Configure(LoginPageKey, new Uri("/Views/AngelListLoginPage.xaml", UriKind.Relative));
            _navigationService = navigationService;
        }
        
        public RelayCommand GoToAngelListLoginPageCommand
        {
            get
            {
                return _goToAngelListLoginPage
                       ??
                       (_goToAngelListLoginPage = new RelayCommand(() => _navigationService.NavigateTo("Page2")));
            }
        }

    }
}