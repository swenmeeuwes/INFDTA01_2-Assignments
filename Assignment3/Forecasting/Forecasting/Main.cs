using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Forecasting
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();

            var dataPoints = new DataProvider().GetData();

            var chart = new ChartWrapper(chart_forcasting);
            chart.AddSeries(SeriesNames.Data, SeriesChartType.Line, dataPoints);
            chart.AddSeries(SeriesNames.Ses, SeriesChartType.Line, dataPoints);

            var smoothingCoefficient = 0f; // SES alpha
            var sesSquaredError = 0f;
            var seriesSes = chart.GetSeries(SeriesNames.Ses).FindForecastSesWithLowestError(0.01f, 11, out smoothingCoefficient, out sesSquaredError);
            //var seriesSes = chart.GetSeries(SeriesNames.Ses).ForecastSes(smoothingCoefficient, 11, out sesSquaredError);
            chart.SetSeries(SeriesNames.Ses, seriesSes);

            // Print to UI
            textBox_sesAlpha.Text = smoothingCoefficient.ToString();
            textBox_sesError.Text = sesSquaredError.ToString();
        }
    }
}
