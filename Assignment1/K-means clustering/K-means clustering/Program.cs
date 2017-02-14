using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace K_means_clustering
{
    class Program
    {
        readonly static char DEFAULT_DELIMITER = ',';
        static void Main(string[] args)
        {
            if (args.Length <= 0 || args.Length > 2)
            {
                Console.WriteLine("Please specify the file path as first parameter");
                Console.WriteLine("Usage: <file_path> [delimiter]");
                return;
            }

            var filePath = args[0];
            char delimiter = args.Length > 1 && args[1].ToCharArray().Length == 1 ? args[1].ToCharArray()[0] : DEFAULT_DELIMITER; // Check if delimiter exists and is 1 char, otherwise use default delimiter

            if (!File.Exists(filePath))
            {
                Console.WriteLine("Exception: File doesn't exist!");
                return;
            }

            var observations = new List<Vector>();
            using (StreamReader streamReader = new StreamReader(filePath))
            {
                string line;
                while ((line = streamReader.ReadLine()) != null)
                {
                    var dimensionStringValues = line.Split(delimiter);
                    var dimensions = new float[dimensionStringValues.Length];
                    for (int i = 0; i < dimensions.Length; i++)
                    {
                        dimensions[i] = float.Parse(dimensionStringValues[i]);
                    }
                    var observation = new Vector(dimensions);
                    observations.Add(observation);
                }
            };

            Clustering.AssignClusterIds(2, 20, observations.ToArray());

            Console.WriteLine("Done!");
            Console.ReadLine();
        }
    }
}