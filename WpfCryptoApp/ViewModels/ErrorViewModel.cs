using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WpfCryptoApp.ViewModels
{
    internal class ErrorViewModel : BaseViewModel
    {
        private HttpRequestException message;
        public HttpRequestException Message
        {
            get => message;
            set
            {
                message = value;
                OnPropertyChanged();
            }
        }
        public ErrorViewModel(HttpRequestException msg)
        {
            Message = msg;
        }
    }
}
