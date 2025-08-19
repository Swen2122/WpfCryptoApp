using LiveChartsCore;
using LiveChartsCore.Defaults;
using LiveChartsCore.SkiaSharpView;
using System;
using System.Linq;

namespace WpfCryptoApp.ViewModels.Financial
{
    internal class CandlesticksViewModel : BaseViewModel
    {
        private Axis[] xAxes;
        private ISeries[] series;

        public CandlesticksViewModel()
        {
            var values = new FinancialPoint[]
            {
                new FinancialPoint(new DateTime(2021, 1, 1), 523, 500, 450, 400),
                new FinancialPoint(new DateTime(2021, 1, 2), 500, 450, 425, 400),
                new FinancialPoint(new DateTime(2021, 1, 3), 490, 425, 400, 380),
                new FinancialPoint(new DateTime(2021, 1, 4), 420, 400, 420, 380),
                new FinancialPoint(new DateTime(2021, 1, 5), 520, 420, 490, 400),
                new FinancialPoint(new DateTime(2021, 1, 6), 580, 490, 560, 440)
            };

            Series = new ISeries[]
            {
                new CandlesticksSeries<FinancialPoint>
                {
                    Values = values
                }
            };

            XAxes = new Axis[]
            {
                new Axis
                {
                    LabelsRotation = 15,
                    Labeler = value => new DateTime((long)value).ToString("MMM dd"),
                    UnitWidth = TimeSpan.FromDays(1).Ticks
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