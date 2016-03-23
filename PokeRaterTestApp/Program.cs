using PokeRater;
using System;
using System.Collections.Generic;

namespace PokeRaterTestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Pokemon Bulbasaur = new Pokemon("Bulbasaur", 1);
            Pokemon Charmander = new Pokemon("Charmander", 4);
            Pokemon Squirtle = new Pokemon("Squirtle", 7);

            var ratingsList = new List<Pokemon>();
            ratingsList.Add(Bulbasaur);
            ratingsList.Add(Charmander);
            ratingsList.Add(Squirtle);

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
