using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genetic_algorithm_assignment
{
    class Population
    {
        public Individual[] individuals { get; } // Capital letter => property?
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

        public Population GenericAlgorithm(float crossoverRate, float mutationRate, int iterations, SelectionMethod selectionMethod = SelectionMethod.ROULETTE, bool useElitism = false)
        {
            switch(selectionMethod)
            {
                case SelectionMethod.ROULETTE:
                    return RouletteIteration(this, crossoverRate, mutationRate, useElitism, iterations, 0);
                case SelectionMethod.RANK: 
                    throw new NotImplementedException();
                case SelectionMethod.TOURNAMENT:
                    throw new NotImplementedException();
                default:
                    throw new Exception("There is no such selection method");
            }
        }

        public Population RouletteIteration(Population population, float crossoverRate, float mutationRate, bool useElitism, int iterationAmount, int iteration)
        {
            if (iteration > iterationAmount - 1)
                return population;

            var lowestFitness = population.individuals.Min((individual) => (individual.Fitness)); // Sucks to be that guy ...
            var absoluteLowestFitness = Math.Abs(lowestFitness);

            var individualPool = new Pool<Individual>();
            foreach (var individual in population.individuals)
            {
                individualPool.EnterLottery(individual, individual.Fitness + absoluteLowestFitness);
            }

            var successors = new List<Individual>();
            for (int i = 0; i < population.individuals.Length / 2; i++)
            {
                // Pick 2 lucky winners
                var winner1 = individualPool.PickWinner(true); // Keep winner in pool, meaning it can mate with itself ...
                var winner2 = individualPool.PickWinner(true);

                // Create 2 offsprings and put them in the successors, the next generation
                var offspring1 = winner1.Crossover(winner2, crossoverRate);
                offspring1 = offspring1.AttemptMutation(mutationRate);
                successors.Add(offspring1);

                var offspring2 = winner2.Crossover(winner1, crossoverRate);
                offspring2 = offspring2.AttemptMutation(mutationRate);
                successors.Add(offspring2);
            }
            var nextGeneration = new Population(successors.ToArray());

            return RouletteIteration(nextGeneration, crossoverRate, mutationRate, useElitism, iterationAmount, iteration + 1);
        }
    }
}
