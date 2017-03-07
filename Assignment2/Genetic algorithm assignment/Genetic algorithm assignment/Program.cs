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
            Population population = Population.CreateRandomPopulation(200);

            Individual ind1 = Individual.CreateRandomIndividual();
            Individual ind2 = Individual.CreateRandomIndividual();
            Console.WriteLine(ind1);
            Console.WriteLine(ind2);

            Console.WriteLine(ind1.Fitness);
            Console.WriteLine(ind2.Fitness);

            Console.ReadLine();
        }
    }
}
