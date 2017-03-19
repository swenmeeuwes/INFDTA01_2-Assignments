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
        public static Series ForecastSes(this Series series, float smoothingCoefficient, int sight, out float squaredError)
        {
            squaredError = 0f;

            var newSeries = new Series(series.Name);
            newSeries.ChartType = series.ChartType;

            // Can't smooth/ forecast on first point 
            // -> initialize with the average of the first 12 (magic number) points if possible
            if (series.Points.Count > 12)
            {
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

                squaredError += (float)Math.Pow(valueY - series.Points[i].YValues[0], 2);
            }

            // "Forecast"
            for (int i = series.Points.Count; i < series.Points.Count + sight; i++)
            {
                newSeries.Points.AddXY(i, newSeries.Points[series.Points.Count - 1].YValues[0]);
            }

            // Finish the calculation of "squared error"
            squaredError /= series.Points.Count + sight - 1;
            squaredError = (float)Math.Sqrt(squaredError);

            return newSeries;
        }

        public static Series FindForecastSesWithLowestError(this Series series, float stepAmount, int sight, out float smoothingCoefficient, out float squaredError)
        {
            smoothingCoefficient = 0f;

            Series bestSeries = null;
            var lowestError = float.MaxValue;
            while(smoothingCoefficient < 1f)
            {
                float error;
                var tempSeries = series.ForecastSes(smoothingCoefficient, sight, out error);

                if(error < lowestError)
                {
                    lowestError = error;
                    bestSeries = tempSeries;
                }
                else if (error >= lowestError)
                {
                    break;
                }
                smoothingCoefficient += stepAmount;
            }
            squaredError = lowestError;
            return bestSeries;
        }
    }
}
