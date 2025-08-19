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
using WpfCryptoApp.ViewModels.CoinCapViewModels;
using WpfCryptoApp.ViewModels.Financial;

namespace WpfCryptoApp.Views
{
    /// <summary>
    /// Interaction logic for CoinItem.xaml
    /// </summary>
    public partial class CoinItem : Page
    {
        public CoinItem(string CoinName)
        {
            InitializeComponent();
            var assetViewModel = new AssetViewModel();
            DataContext = new
            {
                Language = new LanguageViewModel(),
            };
        }

    }
}
