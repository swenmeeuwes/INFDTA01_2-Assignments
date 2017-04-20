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
        public Tuple<DateTime, float>[] GetData()
        {
            List<Tuple<DateTime, float>> points = new List<Tuple<DateTime, float>>();
            using (StreamReader streamReader = new StreamReader("forecastingWalmart.csv"))
            {
                string line;

                //Skip first line
                streamReader.ReadLine();

                while ((line = streamReader.ReadLine()) != null)
                {
                    var dimensions = line.Split(',');

                    var storeNumber = dimensions[0];
                    var departmentNumber = dimensions[1];
                    var date = dimensions[2];
                    var weeklySales = dimensions[3];

                    if(storeNumber == "1" && departmentNumber == "2") {
                        var point = new Tuple<DateTime, float>(DateTime.Parse(date), float.Parse(weeklySales));
                        points.Add(point);
                    }
                }
            };
            return points.ToArray();
        }
    }
}
