using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Version B
namespace Genetic_algorithm_assignment
{
    class Program
    {
        static void Main(string[] args)
        {
            var populationSize = 10;
            var iterations = 50;

            var population = Population.CreateRandomPopulation(populationSize);
            var evolvedPopulation = population.GenericAlgorithm(0.95f, 0.01f, iterations, SelectionMethod.ROULETTE, true);

            Console.WriteLine("INFORMATION ABOUT THE LAST GENERATION");

            var averageFitness = evolvedPopulation.individuals.Average((individual) => (individual.Fitness));
            Console.WriteLine("Average fitness: {0}", averageFitness);

            var bestFitness = evolvedPopulation.individuals.Max((individual) => (individual.Fitness));
            Console.WriteLine("Best fitness: {0}", bestFitness);

            var fittestIndividual = evolvedPopulation.individuals.Select((individual) => (individual)).Where((individual) => (individual.Fitness == bestFitness)).First();
            Console.WriteLine("Best individual: {0}, decodation of genes: ", fittestIndividual);

            string[] valuesKeys = new string[] { "a", "b", "c", "d", "e" };
            var decodedGenes = fittestIndividual.DecodeGenes();
            for (int i = 0; i < decodedGenes.Count; i++)
            {
                Console.WriteLine("{0} = {1}", valuesKeys[i], decodedGenes[valuesKeys[i]]);
            }

            Console.ReadLine();
        }
    }
}