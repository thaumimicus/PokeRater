using PokeRater.Exceptions;
using EloRatingTools;
using PokeRater.DatabaseObjects;

namespace PokeRater
{
    public class DualEloPlayer : IGamePlayer
    {
        private IPokemonDbo _pDbo;

        public DualEloPlayer()
        {
            _pDbo = new PokemonDbo();
        }

        public void PlayGame(Pokemon[] selection, Pokemon winner)
        {
            if (winner == selection[0])
            {
                selection[0].ChangeRating(selection[1], EloCalculator.VictoryType.Win);
                selection[1].ChangeRating(selection[0], EloCalculator.VictoryType.Loss);
            }
            else if (winner == selection[1])
            {
                selection[1].ChangeRating(selection[0], EloCalculator.VictoryType.Win);
                selection[0].ChangeRating(selection[1], EloCalculator.VictoryType.Loss);
            }
            else
            {
                throw new WinnerNotValidException(string.Format("{0} did not participate in the game so is invalid.", winner.Name));
            }

            SaveRatings(selection);
        }

        public Pokemon[] GetNewSelection()
        {
            Pokemon pokeA = _pDbo.GetRandomPokemon();
            Pokemon pokeB = _pDbo.GetRandomPokemon(pokeA);

            return new Pokemon[2] { pokeA, pokeB };
        }

        private void SaveRatings(Pokemon[] modifiedSelection)
        {
            foreach (Pokemon p in modifiedSelection)
            {
                _pDbo.ChangePokemonRating(p, p.Rating);
            }
        }
    }
}
