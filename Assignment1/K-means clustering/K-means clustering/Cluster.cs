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
        public Vector[] observations { get; set; }

        public Cluster()
        {

        }

        public Cluster(int id, Vector centroid, Vector[] observation)
        {
            this.id = id;
            this.centroid = centroid;
            this.observations = observations;
        }
    }
}
