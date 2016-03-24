namespace PokeRater.DatabaseObjects
{
    interface IPokemonDbo
    {
        Pokemon GetPokemonBy(int dexNum);
        Pokemon GetPokemonBy(string name);
        Pokemon GetRandomPokemon();
        Pokemon GetRandomPokemon(Pokemon ignoreThis);
        void ChangePokemonRating(Pokemon pokemon, int newRating);
    }
}
