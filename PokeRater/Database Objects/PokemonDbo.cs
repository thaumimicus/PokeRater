using System;
using System.Collections.Generic;
using System.Linq;

namespace PokeRater.DatabaseObjects
{
    class PokemonDbo
    {
        private List<Pokemon> _ratingsList;
        private Random _rand;

        public PokemonDbo()
        {
            _ratingsList = new List<Pokemon>();
            _ratingsList.Add(new Pokemon("Bulbasaur", 1));
            _ratingsList.Add(new Pokemon("Ivysaur", 2));
            _ratingsList.Add(new Pokemon("Venasaur", 3));
            _ratingsList.Add(new Pokemon("Charmander", 4));
            _ratingsList.Add(new Pokemon("Charmeleon", 5));
            _ratingsList.Add(new Pokemon("Charizard", 6));
            _ratingsList.Add(new Pokemon("Squirtle", 7));
            _ratingsList.Add(new Pokemon("Wartortle", 8));
            _ratingsList.Add(new Pokemon("Blastoise", 9));

            _rand = new Random();
        }

        /// <summary>
        /// Get a Pokemon by its dex number.
        /// </summary>
        /// <param name="dexNum">Dex number.</param>
        /// <returns>Pokemon.</returns>
        public Pokemon GetPokemonBy(int dexNum)
        {
            Pokemon row = _ratingsList.AsEnumerable().Where(x => x.DexNum == dexNum).FirstOrDefault();
            return row;
        }

        /// <summary>
        /// Get a Pokemon by its English name.
        /// </summary>
        /// <param name="name"></param>
        /// <returns>Pokemon.</returns>
        public Pokemon GetPokemonBy(string name)
        {
            Pokemon row = _ratingsList.AsEnumerable().Where(x => x.Name == name).FirstOrDefault();
            return row;
        }

        /// <summary>
        /// Gets a random Pokemon from the database.
        /// </summary>
        /// <returns>A random Pokemon.</returns>
        public Pokemon GetRandomPokemon()
        {
            int a = _rand.Next(0, _ratingsList.Count - 1);
            return _ratingsList[a];
        }

        /// <summary>
        /// Gets a random Pokemon from the database that does not match a specific Pokemon.
        /// </summary>
        /// <param name="ignoreThis">Pokemon to ignore.</param>
        /// <returns>A random Pokemon.</returns>
        public Pokemon GetRandomPokemon(Pokemon ignoreThis)
        {
            int iIgnore = _ratingsList.IndexOf(ignoreThis);
            int a = iIgnore;
            while (a != iIgnore)
            {
                a = _rand.Next(0, _ratingsList.Count - 1);
            }
            return _ratingsList[a];
        }

        /// <summary>
        /// Changes the rating of a Pokemon in the database.
        /// </summary>
        /// <param name="pokemon"></param>
        /// <param name="newRating"></param>
        public void ChangePokemonRating(Pokemon pokemon, int newRating)
        {
            Pokemon row = _ratingsList.AsEnumerable().Where(x => x.DexNum == pokemon.DexNum).FirstOrDefault();
            row.ChangeRating(newRating);
        }
    }
}