using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace K_means_clustering
{
    public class Cluster
    {
        public int id { get; set; }
        public Vector centroid { get; set; }
        public int size { get; set; }

        public Cluster(int id, Vector centroid)
        {
            this.id = id;
            this.centroid = centroid;

            this.size = 0;
        }

        public override string ToString()
        {
            return string.Format("Cluster[id: {0}, centroid: {1}]", id, centroid);
        }
    }
}
