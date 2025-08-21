using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfCryptoApp.ViewModels;

namespace WpfCryptoApp.Views
{
    /// <summary>
    /// Interaction logic for CoinData.xaml
    /// </summary>
    public partial class CoinData : Page
    {
        public CoinData(string id)
        {
            InitializeComponent();
            if (string.IsNullOrEmpty(id))
            {
                MessageBox.Show("Coin ID cannot be null or empty.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            var viewModel = new CoinDataViewModel();
            viewModel.LoadDataAsyn(id);
            DataContext = viewModel;
        }
    }
}
