using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfCryptoApp.ViewModels
{
    internal class CombineViewModel : BaseViewModel
    {
        public List<BaseViewModel> ViewModels = new List<BaseViewModel>();
        public void AddToCombine (BaseViewModel viewModel)
        {
            ViewModels.Add(viewModel);
        }
        public void RemoveFromCombine(BaseViewModel viewModel)
        {
            ViewModels.Remove(viewModel);
        }
        public List<BaseViewModel> LoadCombineData() 
        {
            return ViewModels;
        }

    }
}
