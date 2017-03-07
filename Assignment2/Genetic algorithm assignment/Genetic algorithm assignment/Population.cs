using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genetic_algorithm_assignment
{
    class Population
    {
        Individual[] individuals;
        public Population(Individual[] individuals)
        {
            this.individuals = individuals;
        }

        public static Population CreateRandomPopulation(int size)
        {
            Individual[] individuals = new Individual[size];
            for (int i = 0; i < individuals.Length; i++)
            {
                individuals[i] = Individual.CreateRandomIndividual();
            }
            return new Population(individuals);
        }

        public Population Evolve(bool useElitism)
        {
            throw new NotImplementedException();
        }
    }
}
