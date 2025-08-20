using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace WpfCryptoApp.ViewModels
{
    internal class NavigationViewModel : BaseViewModel
    {
        public ICommand NavigationCommand { get; private set; }
        private Frame MainFrame { get; set; }
        public Frame CurentFrame
        {
            get => MainFrame;
            set
            {
                MainFrame = value;
                OnPropertyChanged();
            }
        }
        public void LoadData()
        {
            MainFrame = App.MainFrame;
        }

    }
}
