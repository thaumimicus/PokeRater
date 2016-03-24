using PokeRater;
using System;
using System.Collections.Generic;

namespace PokeRaterTestApp
{
    class Program
    {
        static void Main(string[] args)
        {

            var ratingsList = new List<Pokemon>();

            ShowRatings(ratingsList);
        }

        private static void ShowRatings(List<Pokemon> pokemon)
        {
            foreach (Pokemon p in pokemon)
            {
                Console.WriteLine(string.Format("{0} : {1}", p.Name, p.Rating.ToString()));
                Console.ReadKey();
            }
        }
    }
}
