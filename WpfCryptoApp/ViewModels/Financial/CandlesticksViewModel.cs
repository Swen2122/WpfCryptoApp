using LiveChartsCore;
using LiveChartsCore.Defaults;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Painting;
using SkiaSharp;
using System;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Markup;
using WpfCryptoApp.Models.CoinGecko;
using WpfCryptoApp.Services.CoinGecko;

namespace WpfCryptoApp.ViewModels.Financial
{
    internal class CandleSticksViewModel : BaseViewModel
    {
        private Axis[] xAxes;
        private ISeries[] series;
        public async Task LoadDataAsync(string id)
        {
            CoinGeckoApi apiService = new CoinGeckoApi();
            var priceHistory = await apiService.GetPriceHistoryOHLC(id, "usd", 7, 3);
            if (priceHistory == null) return;

            var values = priceHistory.Select(p => new FinancialPoint(
                DateTimeOffset.FromUnixTimeMilliseconds(p.Timestamp).UtcDateTime,
                p.Open, p.High, p.Low,  p.Close)).ToArray();
            Series = new ISeries[]
            {

                new CandlesticksSeries<FinancialPointI>
                {
                     /* Collor
                     UpFill = new SolidColorPaint(SKColors.Blue),
                     UpStroke = new SolidColorPaint(SKColors.CornflowerBlue) { StrokeThickness = 5 },
                     DownFill = new SolidColorPaint(SKColors.Red),
                     DownStroke = new SolidColorPaint(SKColors.Orange) { StrokeThickness = 5 },
                     */
                     Values = values
                    .Select(x => new FinancialPointI( x.Open, x.High, x.Low, x.Close))
                    .ToArray()
                }
            };

            XAxes = new Axis[]
            {
                new Axis
                {
                    LabelsRotation = 15,
                    Labels = values
                    .Select(x => x.Date.ToString("yyyy MMM dd"))
                    .ToArray(),
                    UnitWidth = 0.6f
                }
            };
        }

        public ISeries[] Series
        {
            get => series;
            set
            {
                series = value;
                OnPropertyChanged();
            }
        }

        public Axis[] XAxes
        {
            get => xAxes;
            set
            {
                xAxes = value;
                OnPropertyChanged();
            }
        }
    }
}