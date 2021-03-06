﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkiaSharp;
using Xamarin.Forms;

namespace Microcharts.Samples.Forms
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        public static IEnumerable<ChartEntry> GenerateEntries()
        {
            var values = Enumerable.Range(0, 12).Select(x => random.Next(-1000, 1000)).ToArray();
            return new ChartEntry[]
            {
                new ChartEntry(values[0]) { ValueLabel = values[0].ToString(), Label = "January", Color = SKColor.Parse("#266489") },
                new ChartEntry(values[1]) { ValueLabel = values[1].ToString(),Label = "February", Color = SKColor.Parse("#68B9C0") },
                new ChartEntry(values[2]) { ValueLabel = values[2].ToString(),Label = "March", Color = SKColor.Parse("#90D585") },
                new ChartEntry(values[3]) { ValueLabel = values[3].ToString(),Label = "April", Color = SKColor.Parse("#F3C151")},
                new ChartEntry(values[4]) { ValueLabel = values[4].ToString(),Label = "May", Color = SKColor.Parse("#F37F64")},
                new ChartEntry(values[5]) { ValueLabel = values[5].ToString(),Label = "June", Color = SKColor.Parse("#424856") },
                new ChartEntry(values[6]) { ValueLabel = values[6].ToString(),Label = "July", Color = SKColor.Parse("#8F97A4")},
                new ChartEntry(values[7]) { ValueLabel = values[7].ToString(),Label = "August", Color = SKColor.Parse("#DAC096") },
                new ChartEntry(values[8]) { ValueLabel = values[8].ToString(),Label = "September", Color = SKColor.Parse("#76846E") },
                new ChartEntry(values[9]) { ValueLabel = values[9].ToString(),Label = "October", Color = SKColor.Parse("#A65B69") },
                new ChartEntry(values[10]) { ValueLabel = values[10].ToString(),Label = "November", Color = SKColor.Parse("#DABFAF") },
                new ChartEntry(values[11]) { ValueLabel = values[11].ToString(),Label = "December", Color = SKColor.Parse("#97A69D") },
            };
        }

        private static Random random = new Random();

        private int chartType = 0;

        private Type[] ChartTypes =
        {
            typeof(BarChart),
            typeof(PointChart),
            typeof(LineChart),
            typeof(DonutChart),
            typeof(PieChart),
            typeof(RadarChart),
            typeof(RadialGaugeChart),
        };

        protected override void OnAppearing()
        {
            base.OnAppearing();
            ChangeChart(null, null);
        }

        private void GenerateData(object sender, EventArgs e)
        {
            if (chart.Chart != null)
            {
                chart.Chart.Entries = GenerateEntries();
            }
        }

        private void ChangeChart(object sender, EventArgs e)
        {
            chartType = (chartType + 1) % ChartTypes.Length;
            var type = ChartTypes[chartType];
            chart.Chart = Activator.CreateInstance(type) as Chart;
            chart.Chart.MinValue = -1000;
            chart.Chart.MaxValue = 1000;
            GenerateData(null, null);
        }

        private void ChangeFont(object sender, EventArgs e)
        {

            chartType = (chartType + 1) % ChartTypes.Length;
            var type = ChartTypes[chartType];
            chart.Chart = Activator.CreateInstance(type) as Chart;
            chart.Chart.MinValue = -1000;
            chart.Chart.MaxValue = 1000;

            Random r = new Random();
            int rInt = r.Next(0, 3);
            var fontName = string.Empty;
            switch (rInt)
            {
                case 0:
                    fontName = "Avenir";
                    break;
                case 1:
                    fontName = "Noteworthy";
                    break;
                case 2:
                    fontName = "Helvetica";
                    break;
                default:
                    fontName = string.Empty; // test if empty
                    break;
            }
            chart.Chart.Typeface = SKTypeface.FromFamilyName(fontName);
            GenerateData(null, null);
        }
    }
}
