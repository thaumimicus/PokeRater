using System;
using System.Collections.Generic;

namespace PokeRater.DatabaseObjects
{
    public class TestPokemonDbo
    {

        List<Pokemon> ratingsList;

        public TestPokemonDbo()
        {
            // test data  
            ratingsList = new List<Pokemon>();
            ratingsList.Add(new Pokemon("Bulbasaur", 1));
            ratingsList.Add(new Pokemon("Ivysaur", 2));
            ratingsList.Add(new Pokemon("Venasaur", 3));
            ratingsList.Add(new Pokemon("Charmander", 4));
            ratingsList.Add(new Pokemon("Charmeleon", 5));
            ratingsList.Add(new Pokemon("Charizard", 6));
            ratingsList.Add(new Pokemon("Squirtle", 7));
            ratingsList.Add(new Pokemon("Wartortle", 8));
            ratingsList.Add(new Pokemon("Blastoise", 9));
        }

        public void ChangePokemonRating(Pokemon pokemon, int newRating)
        {
            // update database if it existed
        }

        public Pokemon GetPokemonBy(string name)
        {
            foreach (Pokemon p in ratingsList)
            {
                if (p.Name.Equals(name)) return p;
            }
            return null;
        }

        public Pokemon GetPokemonBy(int dexNum)
        {
            return ratingsList[dexNum - 1];
        }

        public Pokemon GetRandomPokemon()
        {
            int dexNum;
            Random rand = new Random();
            dexNum = rand.Next(ratingsList.Count) + 1;
            return GetPokemonBy(dexNum);
        }

        public Pokemon GetRandomPokemon(Pokemon ignoreThis)
        {
            int dexNum = ignoreThis.DexNum;
            Random rand = new Random();
            while (dexNum == ignoreThis.DexNum) dexNum = rand.Next(ratingsList.Count) + 1;
            return GetPokemonBy(dexNum);
        }
    }
}
