using PokeRater.Exceptions;
using EloRatingTools;

namespace PokeRater
{
    public class GamePlayer
    {
        public void PlayGame(Pokemon pokemonA, Pokemon pokemonB, Pokemon winner)
        {
            if (winner == pokemonA)
            {
                pokemonA.ChangeRating(pokemonB, EloCalculator.VictoryType.Win);
                pokemonB.ChangeRating(pokemonA, EloCalculator.VictoryType.Loss);
            }
            else if (winner == pokemonB)
            {
                pokemonB.ChangeRating(pokemonA, EloCalculator.VictoryType.Win);
                pokemonA.ChangeRating(pokemonB, EloCalculator.VictoryType.Loss);
            }
            else
            {
                throw new WinnerNotValidException(string.Format("{0} did not participate in the game so is invalid.", winner.name));
            }
        }
    }
}
