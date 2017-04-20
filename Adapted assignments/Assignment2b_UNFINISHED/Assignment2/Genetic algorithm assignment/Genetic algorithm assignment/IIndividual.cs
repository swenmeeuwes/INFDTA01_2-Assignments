using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genetic_algorithm_assignment
{
    interface IIndividual
    {
        IIndividual Crossover(IIndividual partner, float crossoverRate);
        IIndividual Mutate(float mutationRate);
        IIndividual ComputeFitness();
    }
}
