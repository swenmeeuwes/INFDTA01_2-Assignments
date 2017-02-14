using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace K_means_clustering
{
    class Cluster
    {
        public int id { get; set; }
        public Vector centroid { get; set; }

        public Cluster()
        {

        }

        public Cluster(int id, Vector centroid)
        {
            this.id = id;
            this.centroid = centroid;
        }

        public override string ToString()
        {
            return string.Format("Cluster[id: {0}, centroid: {1}]", id, centroid);
        }
    }
}
