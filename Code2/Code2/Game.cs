using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Code2
{
    public class Game
    {
        public int[] Answers { get; set; }
        public int TotalGuesses { get; set; }

        public Game(int totalGuesses)
        {
            TotalGuesses = totalGuesses;
            CreateRandomAnswers();
        }

        private void CreateRandomAnswers()
        {
            Random rand = new Random();

            var temp = new int[4];

            for (int i = 0; i < 4; i++)
            {
                temp[i] = ((int)(rand.NextDouble() * 6) + 1);
            }

            Answers = temp;
        }

        public Tuple<int, int> EvaluateGuess(int[] guesses)
        {
            var completeCorrect = new List<int>();
            var wrongSpot = 0;

            for (int i = 0; i < 4; i++)
            {
                if (guesses[i] == Answers[i])
                {
                    completeCorrect.Add(i);
                }
            }

            var unusedGuesses = new List<int>();
            var unusedAnswers = new List<int>();

            for (int i = 0; i < 4; i++)
            {
                if (!completeCorrect.Contains(i))
                {
                    unusedGuesses.Add(guesses[i]);
                    unusedAnswers.Add(Answers[i]);
                }
            }

            foreach (var i in unusedGuesses.Distinct())
            {
                int gCount = unusedGuesses.Count(ug => ug == i);
                int aCount = unusedAnswers.Count(ua => ua == i);

                for (int j = 0; j < Math.Min(gCount, aCount); j++)
                {
                    wrongSpot++;//not the actual index
                }
            }

            return new Tuple<int, int>(completeCorrect.Count, wrongSpot);
        }
    }
}
