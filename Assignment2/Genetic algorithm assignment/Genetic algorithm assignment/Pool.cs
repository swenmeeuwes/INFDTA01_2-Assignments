using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genetic_algorithm_assignment
{
    class Pool<T> // HashPool better name? Since keys MUST be unique? Maybe Lottery?
    {
        static Random random = new Random();
        Dictionary<T, float> poolInhabitants = new Dictionary<T, float>();
        public void EnterLottery(T potentialWinner, float lotteryTickets)
        {
            poolInhabitants.Add(potentialWinner, lotteryTickets);
        }
        public T PickWinner(bool keepWinnerInPool = false)
        {
            if (this.poolInhabitants.Count == 0)
                throw new Exception("You can't have a lottery without any entries!");

            var boughtLotteryTickets = poolInhabitants.Values.Sum();
            var winningTicketNumber = random.NextDouble() * boughtLotteryTickets;

            var ticketStack = winningTicketNumber;
            foreach (var inhabitant in poolInhabitants)
            {
                if (inhabitant.Value >= ticketStack)
                {
                    // Found the lucky winner!
                    var winner = inhabitant.Key;
                    if (!keepWinnerInPool)
                        poolInhabitants.Remove(winner);

                    return winner;
                }
                ticketStack -= inhabitant.Value;
            }
            throw new Exception("This lottery is a put-up job!");
        }
    }
}
