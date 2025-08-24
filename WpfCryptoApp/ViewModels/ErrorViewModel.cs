using System;
using System.Net.Http;

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
