using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genetic_algorithm_assignment
{
    class Program
    {
        static void Main(string[] args)
        {
            var population = Population.CreateRandomPopulation(10);
            var evolvedPopulation = population.GenericAlgorithm(0.95f, 0.01f, 10);

            Console.WriteLine("INFORMATION ABOUT THE LAST GENERATION");

            var averageFitness = evolvedPopulation.individuals.Average((individual) => (individual.Fitness));
            Console.WriteLine("Average fitness: {0}", averageFitness);

            var bestFitness = evolvedPopulation.individuals.Max((individual) => (individual.Fitness));
            Console.WriteLine("Best fitness: {0}", bestFitness);

            var fittestIndividual = evolvedPopulation.individuals.Select((individual) => (individual)).Where((individual) => (individual.Fitness == bestFitness)).First();
            Console.WriteLine("Best individual: {0}, decodation of genes: {1}", fittestIndividual, fittestIndividual.DecodeGenes());

            Console.ReadLine();
        }
    }
}