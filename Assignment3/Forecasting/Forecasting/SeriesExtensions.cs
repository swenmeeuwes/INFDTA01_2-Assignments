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
        // SES
        public static Series ForecastSes(this Series series, float smoothingCoefficient, int sight, out float squaredError)
        {
            squaredError = 0f;

            var smoothenedSeries = new Series(series.Name);
            smoothenedSeries.ChartType = series.ChartType;

            // Can't smooth/ forecast on first point 
            // -> initialize with the average of the first 12 (magic number) points if possible
            if (series.Points.Count > 12)
            {
                var sum = 0f;
                for (int i = 0; i < 12; i++)
                {
                    sum += (float)series.Points[i].YValues[0];
                }
                smoothenedSeries.Points.AddXY(series.Points[0].XValue, sum / 12);
            }
            else
                // If no first 12 points exist just take the first point (x1)
                smoothenedSeries.Points.AddXY(series.Points[0].XValue, series.Points[0].YValues[0]);

            for (int i = 1; i < series.Points.Count; i++)
            {
                var smoothenedValueY = smoothingCoefficient * series.Points[i - 1].YValues[0] + (1f - smoothingCoefficient) * smoothenedSeries.Points[i - 1].YValues[0]; // 𝒔𝒕=𝜶𝒙𝒕−𝟏+𝟏−𝜶𝒔𝒕−𝟏
                smoothenedSeries.Points.AddXY(series.Points[i].XValue, smoothenedValueY);

                squaredError += (float)Math.Pow(smoothenedValueY - series.Points[i].YValues[0], 2);
            }

            // "Forecast"
            for (int i = series.Points.Count; i < series.Points.Count + sight; i++)
            {
                smoothenedSeries.Points.AddXY(i, smoothenedSeries.Points[series.Points.Count - 1].YValues[0]);
            }

            // Finish the calculation of "squared error"
            squaredError /= series.Points.Count - 1;
            squaredError = (float)Math.Sqrt(squaredError);

            return smoothenedSeries;
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

        // DES
        public static Series ForecastDes(this Series series, float dataCoefficient, float trendCoefficient, int sight, out float squaredError)
        {
            squaredError = 0f;

            var dataSeries = new Series(series.Name + "_data");
            dataSeries.ChartType = series.ChartType;

            var trendSeries = new Series(series.Name + "_trend");
            trendSeries.ChartType = series.ChartType;

            // Can't smooth/ forecast on the two first points
            // -> initialisation: 𝑠2=𝑥2, 𝑏2=𝑥2−𝑥1
            dataSeries.Points.AddXY(1, series.Points[1].YValues[0]); // Dummy point
            dataSeries.Points.AddXY(1, series.Points[1].YValues[0]); // s2 = x2
            trendSeries.Points.AddXY(1, series.Points[1].YValues[0] - series.Points[0].YValues[0]); // Dummy point
            trendSeries.Points.AddXY(1, series.Points[1].YValues[0] - series.Points[0].YValues[0]); // b2 = x2 - x1

            for (int i = 2; i < series.Points.Count; i++)
            {
                var dataValueY = dataCoefficient * series.Points[i].YValues[0] + (1f - dataCoefficient) * (dataSeries.Points[i - 1].YValues[0] + trendSeries.Points[i - 1].YValues[0]);
                dataSeries.Points.AddXY(i, dataValueY);

                var trendValueY = trendCoefficient * (dataSeries.Points[i].YValues[0] - dataSeries.Points[i - 1].YValues[0]) + (1 - trendCoefficient) * trendSeries.Points[i - 1].YValues[0];
                trendSeries.Points.AddXY(i, trendValueY);
                
                squaredError += (float)Math.Pow(dataValueY - series.Points[i].YValues[0], 2);
            }

            // 'Forecast', available at t=3
            if (series.Points.Count < 3)
                throw new Exception("Need at least 3 data points to forecast DES");

            //var forecastSeries = new Series(series.Name);
            //forecastSeries.ChartType = series.ChartType;

            for (int i = series.Points.Count; i < series.Points.Count + sight; i++)
            {
                dataSeries.Points.AddXY(i, dataSeries.Points[i - 1].YValues[0] + trendSeries.Points[i - 1].YValues[0]);

                var trendValueY = trendCoefficient * (dataSeries.Points[i].YValues[0] - dataSeries.Points[i - 1].YValues[0]) + (1 - trendCoefficient) * trendSeries.Points[i - 1].YValues[0];
                trendSeries.Points.AddXY(i, trendValueY);

                //forecastSeries.Points.AddXY(i, dataSeries.Points[i - 1].YValues[0] + trendSeries.Points[i - 1].YValues[0]);
            }

            // Finish the calculation of "squared error"
            squaredError /= series.Points.Count - 2;
            squaredError = (float)Math.Sqrt(squaredError);

            return dataSeries;
        }

        public static Series FindForecastDesWithLowestError(this Series series, float stepAmount, int sight, out float dataCoefficient, out float trendCoefficient, out float squaredError)
        {
            dataCoefficient = 0f;
            trendCoefficient = 0f;

            Series bestSeries = null;
            var lowestError = float.MaxValue;
            while (dataCoefficient < 1f)
            {
                float error;
                while (trendCoefficient < 1f)
                {
                    var tempSeries = series.ForecastDes(dataCoefficient, trendCoefficient, sight, out error);

                    if (error < lowestError)
                    {
                        lowestError = error;
                        bestSeries = tempSeries;
                    }
                    else if (error >= lowestError)
                    {
                        break;
                    }

                    trendCoefficient += stepAmount;
                }

                dataCoefficient += stepAmount;
            }
            squaredError = lowestError;
            return bestSeries;
        }
    }
}
