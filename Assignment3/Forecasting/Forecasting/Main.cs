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

            chart_forcasting.ChartAreas[0].AxisX.Minimum = 0;

            // SES
            float sesSmoothingCoefficient;
            float sesSquaredError;
            var sesSeries = chart.GetSeries(SeriesNames.Ses).FindForecastSesWithLowestError(0.01f, 48 - 37, out sesSmoothingCoefficient, out sesSquaredError);
            chart.SetSeries(SeriesNames.Ses, sesSeries);

            textBox_sesAlpha.Text = sesSmoothingCoefficient.ToString();
            textBox_sesError.Text = sesSquaredError.ToString();

            // DES
            float desDataCoefficient;
            float desTrendCoefficient;
            float desSquaredError;
            //var desSeries = chart.GetSeries(SeriesNames.Des).FindForecastDesWithLowestError(0.01f, 48 - 37, out desDataCoefficient, out desTrendCoefficient, out desSquaredError);
            var desSeries = chart.GetSeries(SeriesNames.Des).ForecastDes(0.2f, 0.5f, 48 - 37, out desSquaredError);
            chart.SetSeries(SeriesNames.Des, desSeries);

            textBox_desAlpha.Text = "0.2";// desDataCoefficient.ToString();
            textBox_desBeta.Text = "0.5";// desTrendCoefficient.ToString();
            textBox_desError.Text = desSquaredError.ToString();
        }
    }
}
