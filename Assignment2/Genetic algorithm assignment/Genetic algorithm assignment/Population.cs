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

        public Population GenericAlgorithm(Population population, int iterations, SelectionMethod selectionMethod = SelectionMethod.ROULETTE, bool useElitism = false)
        {
            switch(selectionMethod)
            {
                case SelectionMethod.ROULETTE: // Not applicable for negative fitness values?  -> http://stackoverflow.com/questions/16186686/genetic-algorithm-handling-negative-fitness-values
                    throw new NotImplementedException();
                case SelectionMethod.RANK: 
                    throw new NotImplementedException();
                case SelectionMethod.TOURNAMENT:
                    throw new NotImplementedException();
                default:
                    throw new Exception("There is no such selection method");
            }
        }

        public Population RouletteIteration(Population population, bool useElitism, int iterationAmount, int iteration)
        {
            if (iteration > iterationAmount)
                return population;
            throw new NotImplementedException();
        }
    }
}
