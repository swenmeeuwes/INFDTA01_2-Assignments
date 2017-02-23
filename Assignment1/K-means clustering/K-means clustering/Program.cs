using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace K_means_clustering
{
    class Program
    {
        readonly static char DEFAULT_DELIMITER = ',';

        static Stopwatch stopwatch;
        static void Main(string[] args)
        {
            stopwatch = new Stopwatch();
            stopwatch.Start();

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

            // OBSOLETE WAY
            //for (int i = 0; i < 10; i++)
            //    Clustering.AssignClusterIds(2, 20, observations.ToArray());

            // With extension method
            List<Tuple<Vector[], float>> resultScoreDictionary = new List<Tuple<Vector[], float>>();
            // Parameters to play with
            var algorithmAmount = 1000; // How many times the KMean-algorithm will be executed
            var amountOfClusters = 5; // K-value in the KMean-algorithm
            var kmeanIterations = 10; // Iterations within the KMean-algorithm
            // End of parameters
            Console.WriteLine("Configuration:");
            Console.WriteLine("K-value (amount of clusters): {0}", amountOfClusters);
            Console.WriteLine("Iterations within the KMean-algorithm: {0}", kmeanIterations);
            Console.WriteLine("Executing the KMean-algorithm {0} times over the dataset ...", algorithmAmount);
            for (int i = 0; i < algorithmAmount; i++)
            {
                Vector[] observationsClone = (Vector[])observations.ToArray().Clone();
                var sse = observationsClone.KMean(amountOfClusters, kmeanIterations);
                resultScoreDictionary.Add(new Tuple<Vector[], float>(observationsClone, sse));
            }

            // Get lowest SSE
            Console.WriteLine("Getting result with lowest SSE ...");
            var bestResult = resultScoreDictionary[0].Item1;
            var lowestSSE = float.MaxValue;
            for (int i = 0; i < resultScoreDictionary.Count; i++)
            {
                var sse = resultScoreDictionary[i].Item2;
                if(sse < lowestSSE)
                {
                    lowestSSE = sse;
                    bestResult = resultScoreDictionary[i].Item1;
                }
            }

            Console.WriteLine("Lowest SSE: {0}", lowestSSE);

            stopwatch.Stop();
            Console.WriteLine("Done!");
            Console.WriteLine("Finished in {0} milliseconds!", stopwatch.ElapsedMilliseconds);
            Console.ReadLine();
        }
    }
}