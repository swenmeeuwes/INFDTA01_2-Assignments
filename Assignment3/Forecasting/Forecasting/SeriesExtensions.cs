using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

namespace Forecasting
{
    public static class SeriesExtensions
    {
        public static Series ForecastSes(this Series series, float smoothingCoefficient)
        {
            var newSeries = new Series(series.Name);
            newSeries.ChartType = series.ChartType;

            // Can't smooth/ forecast on first point 
            // -> initialize with the average of the first 12 points if possible
            if (series.Points.Count > 12) {
                var sum = 0f;
                for (int i = 0; i < 12; i++)
                {
                    sum += (float)series.Points[i].YValues[0];
                }
                newSeries.Points.AddXY(series.Points[0].XValue, sum / 12);
            }
            else
                // If no first 12 points exist just take the first point (x1)
                newSeries.Points.AddXY(series.Points[0].XValue, series.Points[0].YValues[0]);

            for (int i = 1; i < series.Points.Count; i++)
            {
                var valueY = series.Points[i].YValues[0];
                valueY = smoothingCoefficient * series.Points[i - 1].YValues[0] + (1f - smoothingCoefficient) * newSeries.Points[i - 1].YValues[0]; // 𝒔𝒕=𝜶𝒙𝒕−𝟏+𝟏−𝜶𝒔𝒕−𝟏
                newSeries.Points.AddXY(series.Points[i].XValue, valueY);
            }

            return newSeries;
        }
    }
}
