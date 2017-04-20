﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace K_means_clustering
{
    [Obsolete]
    class Clustering
    {
        public static Vector[] AssignClusterIds(int amountOfClusters, int iterations, Vector[] observations) // Where amount of clusters is the 'K' value
        {
            if (amountOfClusters <= 1)
                throw new Exception("Must have 2 or more clusters");

            Random random = new Random();

            Cluster[] clusters = new Cluster[amountOfClusters];
            List<Vector> possibleCentroids = ((Vector[])observations.Clone()).ToList(); // Fix pls
            for (int i = 0; i < clusters.Length; i++)
            {
                var centroidIndex = random.Next(possibleCentroids.Count);
                clusters[i] = new Cluster(i, possibleCentroids[centroidIndex]);
                possibleCentroids.RemoveAt(centroidIndex); // Make sure the same observation doesn't get picked as centroid for the cluster
            }

            return ClusterIteration(clusters, observations, iterations, 0);
        }

        // Implement if centroids are the same return
        // Assumption: cluster array is sorted on clusterId from 0 to N
        static Vector[] ClusterIteration(Cluster[] clusters, Vector[] observations, int iterations, int iterationStep)
        {
            if (iterationStep >= iterations)
                return observations;

            float sumOfSquaredErrors = 0;
            Vector[] observationSums = new Vector[clusters.Length]; // Used to save the sum of observation tuples by cluster id, where the index of the array is the cluster id
            for (int i = 0; i < observationSums.Length; i++)
                observationSums[i] = new Vector(new float[observations[0].dimensions.Length]);

            // Compute nearest cluster for each observation
            for (int i = 0; i < observations.Length; i++)
            {
                var nearestCluster = clusters[0];
                var nearestCentroidDistance = Vector.Distance(nearestCluster.centroid, observations[i]);
                for (int j = 1; j < clusters.Length; j++)
                {
                    var distance = Vector.Distance(clusters[j].centroid, observations[i]);
                    if (distance < nearestCentroidDistance)
                    {
                        nearestCluster = clusters[j];
                        nearestCentroidDistance = distance;
                    }
                }
                nearestCluster.size++;
                observations[i].clusterId = nearestCluster.id;
                observationSums[nearestCluster.id] += observations[i];

                sumOfSquaredErrors += (float)nearestCentroidDistance;// USE => (float)Math.Pow(nearestCentroidDistance, 2);
            }

            // Adjust centroids to observation average  
            for (int j = 0; j < clusters.Length; j++)
            {
                var centroid = observationSums[j] / clusters[j].size;

                if(centroid == clusters[j].centroid)
                    Console.WriteLine("Centroid of cluster {0} is the same!", j);

                clusters[j].centroid = centroid;
                clusters[j].size = 0;
            }

            Console.WriteLine("SSE: {0}", sumOfSquaredErrors);

            return ClusterIteration(clusters, observations, iterations, iterationStep + 1);
        }
    }
}
