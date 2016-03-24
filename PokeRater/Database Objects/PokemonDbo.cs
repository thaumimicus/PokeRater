using System;
using System.Data;
using System.Linq;
using PokeRater.Adapters;

namespace PokeRater.DatabaseObjects
{
    class PokemonDbo : IPokemonDbo
    {
        private Random _rand;
        private string _connectionString = "";
        private IPokeRaterAdapter _prAdapter;
        private DataTable _pokemon;

        public PokemonDbo()
        {
            _rand = new Random();
            _prAdapter = new PokeRaterSqlAdapter(_connectionString);
            _pokemon = _prAdapter.GetAllPokemon();
        }

        /// <summary>
        /// Get a Pokemon by its dex number.
        /// </summary>
        /// <param name="dexNum">Dex number.</param>
        /// <returns>Pokemon.</returns>
        public Pokemon GetPokemonBy(int dexNum)
        {
            DataRow row = _pokemon.AsEnumerable().Where(x => (int)x["DexNum"] == dexNum).FirstOrDefault();
            return new Pokemon(row);
        }

        /// <summary>
        /// Get a Pokemon by its English name.
        /// </summary>
        /// <param name="name"></param>
        /// <returns>Pokemon.</returns>
        public Pokemon GetPokemonBy(string name)
        {
            DataRow row = _pokemon.AsEnumerable().Where(x => (string)x["Name"] == name).FirstOrDefault();
            return new Pokemon(row);
        }

        /// <summary>
        /// Gets a random Pokemon from the database.
        /// </summary>
        /// <returns>A random Pokemon.</returns>
        public Pokemon GetRandomPokemon()
        {
            int a = _rand.Next(_pokemon.Rows.Count);
            return GetPokemonBy(a);
        }

        /// <summary>
        /// Gets a random Pokemon from the database that does not match a specific Pokemon.
        /// </summary>
        /// <param name="ignoreThis">Pokemon to ignore.</param>
        /// <returns>A random Pokemon.</returns>
        public Pokemon GetRandomPokemon(Pokemon ignoreThis)
        {
            int a = ignoreThis.DexNum;
            while (a != ignoreThis.DexNum)
            {
                a = _rand.Next(_pokemon.Rows.Count);
            }
            return GetPokemonBy(a);
        }

        /// <summary>
        /// Changes the rating of a Pokemon in the database.
        /// </summary>
        /// <param name="pokemon"></param>
        /// <param name="newRating"></param>
        public void ChangePokemonRating(Pokemon pokemon, int newRating)
        {
            DataRow row = _pokemon.AsEnumerable().Where(x => (int)x["DexNum"] == pokemon.DexNum).FirstOrDefault();
            row["Rating"] = newRating;
            _prAdapter.UpdatePokemon(_pokemon);
        }
    }
}