using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

namespace Forecasting
{
    class ChartWrapper
    {
        Chart chart;
        Dictionary<SeriesNames, Series> content;

        public ChartWrapper(Chart chart)
        {
            this.chart = chart;
            this.content = new Dictionary<SeriesNames, Series>();

            UpdateSeries();
        }

        public void AddSeries(SeriesNames id, SeriesChartType type, Tuple<float, float>[] data)
        {
            var series = new Series(id.ToString());
            series.ChartType = type;

            for (int i = 0; i < data.Length; i++)
            {
                series.Points.AddXY(data[i].Item1, data[i].Item2);
            }
            content.Add(id, series);

            UpdateSeries();
        }

        public void SetSeries(SeriesNames id, Series series)
        {
            content[id] = series;
            series.BorderWidth = 2;

            UpdateSeries();
        }

        public Series GetSeries(SeriesNames id)
        {
            return content[id];
        }

        private void UpdateSeries()
        {
            chart.Series.Clear();

            foreach (var data in content)
            {
                chart.Series.Add(data.Value);
            }
        }
    }
}
