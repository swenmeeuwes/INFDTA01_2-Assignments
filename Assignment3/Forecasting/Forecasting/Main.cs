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
            chart.AddSeries(SeriesNames.Des, SeriesChartType.Line, dataPoints);

            var sesSmoothingCoefficient = 0f;
            var sesSquaredError = 0f;
            var sesSeries = chart.GetSeries(SeriesNames.Ses).FindForecastSesWithLowestError(0.01f, 11, out sesSmoothingCoefficient, out sesSquaredError);
            chart.SetSeries(SeriesNames.Ses, sesSeries);

            var desSmoothingCoefficient = 0f;
            var desSquaredError = 0f;
            var desSeries = chart.GetSeries(SeriesNames.Des);//.FindForecastSesWithLowestError(0.01f, 11, out desSmoothingCoefficient, out desSquaredError);
            chart.SetSeries(SeriesNames.Des, desSeries);



            // Print to UI
            textBox_sesAlpha.Text = sesSmoothingCoefficient.ToString();
            textBox_sesError.Text = sesSquaredError.ToString();
        }
    }
}
