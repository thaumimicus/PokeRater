
using System.Data;

namespace PokeRater.Adapters
{
    interface IPokeRaterAdapter
    {
        DataTable GetAllPokemon();
        void UpdatePokemon(DataTable dt);
    }
}
