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

        public MainWindow()
        {
            SearchCommand = new RelayCommand(o => GetCoinChart(), o => true);

            InitializeComponent();
   
            App.MainFrame = TopCoinsFrame;

            var navigationViewModel = new NavigationViewModel();
            navigationViewModel.LoadData();

            DataContext = new
            {
                Language = new LanguageViewModel(),
                SearchCommand,
                Navigation = navigationViewModel
            };
        }

        private void GetCoinChart()
        {
            string coinName = SearchTextBox.Text;
            App.MainFrame?.Navigate(new Views.CoinItem(coinName));
        }

    }
}