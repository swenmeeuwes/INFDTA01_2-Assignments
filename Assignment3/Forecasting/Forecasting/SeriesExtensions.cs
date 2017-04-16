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
        public static Series ForecastSes(this Series series, float smoothingCoefficient, int lastForecast, out float squaredError)
        {
            squaredError = 0f;

            var forecastSeries = new Series(series.Name);
            forecastSeries.ChartType = series.ChartType;

            // Can't smooth/ forecast on first point 
            // -> initialize with the average of the first 12 (magic number) points if possible
            if (series.Points.Count > 12)
            {
                var sum = 0f;
                for (int i = 0; i < 12; i++)
                {
                    sum += (float)series.Points[i].YValues[0];
                }
                forecastSeries.Points.AddXY(0, sum / 12);
            }
            else
                // If no first 12 points exist just take the first point (x1)
                forecastSeries.Points.AddXY(0, series.Points[0].YValues[0]);

            for (int i = 1; i < series.Points.Count; i++)
            {
                var smoothenedValueY = smoothingCoefficient * series.Points[i - 1].YValues[0] + (1f - smoothingCoefficient) * forecastSeries.Points[i - 1].YValues[0]; // 𝒔𝒕=𝜶𝒙𝒕−𝟏+𝟏−𝜶𝒔𝒕−𝟏
                forecastSeries.Points.AddXY(i, smoothenedValueY);

                squaredError += (float)Math.Pow(smoothenedValueY - series.Points[i].YValues[0], 2);
            }

            // "Forecast"
            var lastSmoothendValue = forecastSeries.Points.Last().YValues[0];
            for (int i = series.Points.Count; i <= lastForecast; i++)
            {
                forecastSeries.Points.AddXY(i, lastSmoothendValue);
            }

            // Finish the calculation of "squared error"
            squaredError /= series.Points.Count - 1;
            squaredError = (float)Math.Sqrt(squaredError);

            return forecastSeries;
        }

        public static Series FindForecastSesWithLowestError(this Series series, float stepAmount, int lastForecast, out float smoothingCoefficient, out float squaredError)
        {
            smoothingCoefficient = 0f;

            Series bestSeries = null;
            var lowestError = float.MaxValue;
            while(smoothingCoefficient < 1f)
            {
                float error;
                var tempSeries = series.ForecastSes(smoothingCoefficient, lastForecast, out error);

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
        public static Series ForecastDes(this Series series, float dataCoefficient, float trendCoefficient, int lastForecast, out float squaredError)
        {
            // 'Forecast', available at t=3
            if (series.Points.Count < 3)
                throw new Exception("Need at least 3 data points to forecast DES");

            squaredError = 0f;

            var forecastSeries = new Series(series.Name);
            forecastSeries.ChartType = series.ChartType;

            var levelSeries = new Dictionary<int, double>();
            var trendSeries = new Dictionary<int, double>();

            // Can't smooth/ forecast on the two first points
            // -> initialisation: 𝑠2=𝑥2, 𝑏2=𝑥2−𝑥1  (so s1=x1, b1=x1-x, since we work 0 index based)
            levelSeries.Add(1, series.Points[1].YValues[0]);
            trendSeries.Add(1, series.Points[1].YValues[0] - series.Points[0].YValues[0]);

            var dataPoints = series.Points;
            for (int i = 2; i < dataPoints.Count; i++)
            {
                var s = dataCoefficient * dataPoints[i].YValues[0] + (1.0 - dataCoefficient) * (levelSeries[i - 1] + trendSeries[i - 1]);
                levelSeries.Add(i, s);

                var b = trendCoefficient * (levelSeries[i] - levelSeries[i - 1]) + (1 - trendCoefficient) * trendSeries[i - 1];
                trendSeries.Add(i, b);
            }

            // 'Forecast', available at t=3, which is t=2 in a 0 index based
            for (int i = 2; i < series.Points.Count; i++)
            {
                var f = levelSeries[i - 1] + trendSeries[i - 1];
                forecastSeries.Points.AddXY(i, f);

                squaredError += (float)Math.Pow(f - series.Points[i].YValues[0], 2);
            }

            var finalSmoothedValue = levelSeries.Last().Value;
            var finalEstimateTrend = trendSeries.Last().Value;
            for (int i = series.Points.Count; i <= lastForecast; i++)
            {
                var f = finalSmoothedValue + (i - series.Points.Count) * finalEstimateTrend;
                forecastSeries.Points.AddXY(i, f);
            }

            // Finish the calculation of "squared error"
            squaredError /= series.Points.Count - 2;
            squaredError = (float)Math.Sqrt(squaredError);

            return forecastSeries;
        }

        public static Series FindForecastDesWithLowestError(this Series series, float stepAmount, int lastForecast, out float dataCoefficient, out float trendCoefficient, out float squaredError)
        {
            dataCoefficient = 0.1f;
            trendCoefficient = 0.1f;

            Series bestSeries = null;
            var bestDataCoefficient = dataCoefficient;
            var bestTrendCoefficient = trendCoefficient;
            var lowestError = float.MaxValue;
            while (dataCoefficient < 1f)
            {
                trendCoefficient = 0.1f;
                

                float error;
                while (trendCoefficient < 1f)
                {
                    Console.WriteLine("{0}, {1}, {2}", lowestError, dataCoefficient, trendCoefficient);

                    var tempSeries = series.ForecastDes(dataCoefficient, trendCoefficient, lastForecast, out error);

                    if (error < lowestError)
                    {
                        lowestError = error;
                        bestSeries = tempSeries;
                        bestDataCoefficient = dataCoefficient;
                        bestTrendCoefficient = trendCoefficient;                        
                    }
                    else if (error >= lowestError)
                    {
                        break;
                    }

                    trendCoefficient += stepAmount;
                }

                dataCoefficient += stepAmount;
            }

            dataCoefficient = bestDataCoefficient;
            trendCoefficient = bestTrendCoefficient;
            squaredError = lowestError;

            Console.WriteLine("FINAL {0}, {1}, {2}", lowestError, bestDataCoefficient, bestTrendCoefficient);

            return bestSeries;
        }
    }
}
