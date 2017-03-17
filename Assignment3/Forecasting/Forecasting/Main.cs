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

            chart_forcastingSes.Series.Clear();

            chart_forcastingSes.Series.Add("Cool");
            chart_forcastingSes.Series["Cool"].ChartType = SeriesChartType.Line;
            chart_forcastingSes.Series["Cool"].Points.AddY(1);
            chart_forcastingSes.Series["Cool"].Points.AddY(8);
            chart_forcastingSes.Series["Cool"].Points.AddY(4);
        }

        
    }
}
