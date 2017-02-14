using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace K_means_clustering
{
    class Clustering
    {
        public static Vector[] AssignClusterIds(int amountOfClusters, Vector[] observations) // Where amount of clusters is the 'K' value
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
                possibleCentroids.RemoveAt(centroidIndex);
            }

            ClusterIteration(clusters, observations);

            return observations;
        }

        static void ClusterIteration(Cluster[] clusters, Vector[] observations)
        {
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
                observations[i].clusterId = nearestCluster.id;
                Console.WriteLine(observations[i]);
            }
        }
    }
}
