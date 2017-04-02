using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forecasting
{
    class DataProvider
    {
        public Tuple<float, float>[] GetData()
        {
            List<Tuple<float, float>> points = new List<Tuple<float, float>>();
            using (StreamReader streamReader = new StreamReader("SwordForecasting.csv"))
            {
                string line;
                while ((line = streamReader.ReadLine()) != null)
                {
                    var dimensions = line.Split(';');
                    var point = new Tuple<float, float>(float.Parse(dimensions[0]) - 1, float.Parse(dimensions[1])); // -1 because the data is one-index based but the code zero-index based
                    points.Add(point);
                }
            };
            return points.ToArray();
        }
    }
}
