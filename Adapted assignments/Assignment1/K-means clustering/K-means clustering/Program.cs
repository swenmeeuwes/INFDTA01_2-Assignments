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
        readonly static char DEFAULT_DELIMITER = '\t';

        static Stopwatch stopwatch;
        static void Main(string[] args)
        {
            stopwatch = new Stopwatch();

            //if (args.Length <= 0 || args.Length > 2)
            //{
            //    Console.WriteLine("Please specify the file path as first parameter");
            //    Console.WriteLine("Usage: <file_path> [delimiter]");
            //    return;
            //}

            //var filePath = args[0];
            char delimiter = args.Length > 1 && args[1].ToCharArray().Length == 1 ? args[1].ToCharArray()[0] : DEFAULT_DELIMITER; // Check if delimiter exists and is 1 char, otherwise use default delimiter

            //if (!File.Exists(filePath))
            //{
            //    Console.WriteLine("Exception: File doesn't exist!");
            //    return;
            //}

            var observations = new List<Vector>();
            using (StreamReader streamReader = new StreamReader("a2.txt"))
            {
                string line;
                while ((line = streamReader.ReadLine()) != null)
                {
                    //var splitted = line.Split(' ');
                    //var dimensionStringValues = new string[] { splitted[3], splitted[6] };
                    var dimensionStringValues = new string[] { line.Substring(0, 8), line.Substring(9) };
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
            List<Tuple<Cluster[], float>> resultScoreDictionary = new List<Tuple<Cluster[], float>>();
            // Parameters to play with
            Console.WriteLine("Please specify the amount of algorithms that should be run. (Default: 1000)");
            var algorithmAmount = PromptInteger(1000); // How many times the KMean-algorithm will be executed
            Console.WriteLine("Please specify the amount of clusters the algorithm should make. (Default: 5)");
            var amountOfClusters = PromptInteger(5); // K-value in the KMean-algorithm
            Console.WriteLine("Please specify the amount of iterations the algorithm should run. (Default: 10)");
            var kmeanIterations = PromptInteger(10); // Iterations within the KMean-algorithm
            // End of parameters
            Console.WriteLine("Configuration:");
            Console.WriteLine("K-value (amount of clusters): {0}", amountOfClusters);
            Console.WriteLine("Iterations within the KMean-algorithm: {0}", kmeanIterations);
            Console.WriteLine("Executing the KMean-algorithm {0} times over the dataset ...", algorithmAmount);

            stopwatch.Start();

            for (int i = 0; i < algorithmAmount; i++)
            {
                Vector[] observationsClone = (Vector[])observations.ToArray().Clone();
                Tuple<Cluster[], float> result = observationsClone.KMean(amountOfClusters, kmeanIterations);
                resultScoreDictionary.Add(result);
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

            // Print cluster sizes
            Console.WriteLine();
            Console.WriteLine("OUTPUT Cluster sizes");
            for (int i = 0; i < bestResult.Length; i++)
            {
                Console.WriteLine("Cluster {0} has a size of {1}", bestResult[i].id, bestResult[i].size);
            }

            Console.WriteLine();
            Console.WriteLine("Done!");
            Console.WriteLine("Finished in {0} milliseconds!", stopwatch.ElapsedMilliseconds);
            Console.ReadLine();
        }

        static int PromptInteger(int defaultNumericValue)
        {
            var input = Console.ReadLine();

            if (input.Length == 0)
            {
                Console.WriteLine("Using provided default value: {0}", defaultNumericValue);
                return defaultNumericValue;
            }

            int inputInt;
            bool isNumeric = int.TryParse(input, out inputInt);
            if(!isNumeric)
            {
                Console.WriteLine("Please enter a numeric value");
                return PromptInteger(defaultNumericValue);
            }
            return inputInt;
        }
    }
}