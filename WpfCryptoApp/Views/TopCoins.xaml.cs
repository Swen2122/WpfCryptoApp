using System.Windows.Controls;
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
            var viewModel = new TopCoinsViewModel();
            LoadVMData(viewModel);

            DataContext = new
            {
                TopCoins = viewModel,
            };
        }
        private async void LoadVMData(TopCoinsViewModel viewModel)
        {
            await viewModel.LoadData();
        }
    }
}
