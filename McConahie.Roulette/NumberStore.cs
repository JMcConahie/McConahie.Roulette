using McConahie.Roulette.Models;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace McConahie.Roulette
{
    public class NumberStore
    {
        public ConcurrentDictionary<Classification, int> Results { get; set; }
        public ConcurrentQueue<int> ResultHistory { get; set; }
        public int LastResult { get; set; } = -1;

        public NumberStore()
        {
            Results = new ConcurrentDictionary<Classification, int>();
            ResultHistory = new ConcurrentQueue<int>();
        }

        //TODO: limit size of result sets
        public void AddResult(int result)
        {
            LastResult = result;
            ResultHistory.Enqueue(result);

            var classifier = new ResultClassifier();
            List<Classification> classifications = classifier.ClassifyResult(result);

            foreach (var classification in classifications)
            {
                Results.AddOrUpdate(classification, 1, (key, oldValue) => oldValue + 1);
            }
        }
    }
}
