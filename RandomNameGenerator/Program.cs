using System;
using System.Collections.Generic;
using System.Linq;

namespace RandomNameGenerator
{
    class Program
    {
        private static List<Letter> _letters;

        /// <summary>
        /// Generate random words.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            _letters = new List<Letter>
            {
                new Vowel("a"),
                new Vowel("e"),
                new Vowel("i"),
                new Vowel("o"),
                new Vowel("u"),
                new Consonant("b"),
                new Consonant("c"),
                new Consonant("d"),
                new Consonant("f"),
                new Consonant("g"),
                new Consonant("h"),
                new Consonant("j"),
                new Consonant("k"),
                new Consonant("l"),
                new Consonant("m"),
                new Consonant("n"),
                new Consonant("p"),
                new Consonant("q"),
                new Consonant("r"),
                new Consonant("s"),
                new Consonant("t"),
                new Consonant("v"),
                new Consonant("w"),
                new Consonant("x"),
                new Consonant("y"),
                new Consonant("z")
            };

            Console.WriteLine("Size?");
            int size = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("How many?");
            int num = Convert.ToInt32(Console.ReadLine());

            string cont = "y";
            while (cont != "n")
            {
                Console.WriteLine();
                Generate(size, num);
                Console.WriteLine();

                Console.WriteLine("Again?");
                cont = Console.ReadLine();
            }
        }

        /// <summary>
        /// Generate [num] amount of random words of [size] letters.
        /// Avoids double consonants and tripple vowels.
        /// </summary>
        /// <param name="size">Letters per word.</param>
        /// <param name="num">Number of words to generate.</param>
        static void Generate(int size, int num)
        {
            Random random = new Random();

            for (int i = 0; i < num; i++)
            {
                List<Letter> word = new List<Letter>();
                
                for (int j = 0; j < size; j++)
                {
                    Letter letter = _letters[random.Next(0, _letters.Count)];

                    if (word.Count != 0)
                    {
                        while (letter.GetType() == typeof (Consonant)
                               &&
                               word.Last().GetType() == typeof (Consonant)
                               
                               ||

                               letter.GetType() == typeof(Vowel)
                               &&
                               word.Last().GetType() == typeof(Vowel)
                               &&
                               word[word.Count - 1].GetType() == typeof(Vowel))
                        {
                            letter = _letters[random.Next(0, _letters.Count)];
                        }
                    }

                    word.Add(letter);
                }

                string printWord = "";

                foreach (Letter l in word)
                {
                    printWord += l.Get;
                }

                Console.WriteLine(printWord);
            }
        }
    }
}
