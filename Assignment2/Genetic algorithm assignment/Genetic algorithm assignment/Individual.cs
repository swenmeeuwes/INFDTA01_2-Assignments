using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genetic_algorithm_assignment
{
    class Individual: IComparable<Individual>
    {
        static Random random = new Random();

        public byte[] genes; // Should be bit (0, 1) so boolean?
        public float Fitness
        {
            get
            {
                int decodedValue = this.DecodeGenes();
                return (float)(-(Math.Pow(decodedValue, 2)) + 7 * decodedValue);
            }
        }

        public Individual(byte[] genes)
        {
            if (genes.Length != 5)
                throw new Exception("An individual should always have 5 genes!");
            this.genes = genes;
        }

        public static Individual CreateRandomIndividual()
        {
            byte[] genes = new byte[5];
            for (int i = 0; i < genes.Length; i++)
            {
                genes[i] = (byte)random.Next(2);
            }
            return new Individual(genes);
        }

        // Single-point crossover
        // Left from middlepoint = this
        // Right is partner
        public Individual Crossover(Individual partner, float crossoverRate)
        {
            // If random value is over the crossover rate, don't crossover
            var crossoverValue = random.NextDouble();
            if (crossoverValue > crossoverRate)
                return new Individual(this.genes);

            // Single-point crossover
            var middlePoint = random.Next(partner.genes.Length);

            byte[] genePool = new byte[partner.genes.Length];
            for (int i = 0; i < genePool.Length; i++)
            {
                if (i <= middlePoint)
                    genePool[i] = this.genes[i];
                else
                    genePool[i] = partner.genes[i];
            }
            return new Individual(genePool);
        }

        public Individual AttemptMutation(float mutationRate)
        {
            byte[] genePool = new byte[this.genes.Length];
            for (int i = 0; i < this.genes.Length; i++)
            {
                var mutationValue = random.NextDouble();
                if (mutationValue < mutationRate)
                    genePool[i] = (byte)random.Next(2);
                else
                    genePool[i] = this.genes[i];
            }
            return new Individual(genePool);
        }

        public int DecodeGenes()
        {
            int decodedValue = 0;
            for (int i = 0; i < genes.Length; i++)
            {
                if (genes[i] == 1)
                    decodedValue += (int)Math.Pow(2, i);
            }
            return decodedValue;
        }

        public int CompareTo(Individual individual)
        {
            return (int)(this.Fitness - individual.Fitness);
        }

        // Overwritten methods
        public override string ToString()
        {
            var geneString = "[";
            for (int i = genes.Length - 1; i >= 0; i--)
            {
                geneString += genes[i].ToString();
            }
            geneString += "]";
            return string.Format("[Individual(genes: {0})]", geneString);
        }
    }
}
