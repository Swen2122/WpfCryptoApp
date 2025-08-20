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
    /// Interaction logic for TopCoins.xaml
    /// </summary>
    public partial class TopCoins : Page
    {
        public TopCoins()
        {
            InitializeComponent();
            var viewModel = new CoinViewModel();
            viewModel.LoadData();

            DataContext = new
            {
                TopCoins = viewModel,
                Language = new LanguageViewModel(),
            };
        }
    }
}
