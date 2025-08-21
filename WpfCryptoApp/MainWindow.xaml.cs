using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using WpfCryptoApp.ViewModels;

namespace WpfCryptoApp
{
    public partial class MainWindow : Window
    {
        public ICommand SearchCommand { get; private set; }
        public ICommand ReturnHomeCommand { get; private set; }
        public ICommand GetInfoCommand { get; private set; }

        public MainWindow()
        {
            SearchCommand = new RelayCommand(o => GetCoinChart(), o => true);
            ReturnHomeCommand = new RelayCommand(o => GoToHomePage(), o => true);
            GetInfoCommand = new RelayCommand(o => GetCoinData(), o => true);

            InitializeComponent();

            App.SetMainPage(TopCoinsFrame);
            GoToHomePage();
            var navigationViewModel = new NavigationViewModel();
            navigationViewModel.LoadData();

            DataContext = new
            {
                Language = new LanguageViewModel(),
                SearchCommand,
                GetInfoCommand, 
                Navigation = navigationViewModel
            };
        }

        private void GetCoinChart()
        {
            string coinName = SearchTextBox.Text;
            App.MainFrame?.Navigate(new Views.CoinItem(coinName));
        }
        private void GetCoinData()
        {
            string coinName = SearchTextBox.Text;
            App.MainFrame?.Navigate(new Views.CoinData(coinName));
        }
        private void GoToHomePage() 
        {
            App.MainFrame?.Navigate(new Views.TopCoins());
        }

    }
}