using PokeRater.Exceptions;
using EloRatingTools;
using System.Collections.Generic;
using System;

namespace PokeRater
{
    public class DualEloPlayer : IGamePlayer
    {
        List<Pokemon> ratingsList; //DB

        public DualEloPlayer()
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
                throw new WinnerNotValidException(string.Format("{0} did not participate in the game so is invalid.", winner.name));
            }

            SaveRatings(selection);
        }

        public Pokemon[] GetNewSelection()
        {
            int a, b;
            Random rand = new Random();
            a = rand.Next(ratingsList.Count);
            b = a;
            while (b == a) b = rand.Next(ratingsList.Count);
            return new Pokemon[2] { ratingsList[a], ratingsList[b] };
        }

        private void SaveRatings(Pokemon[] modifiedSelection)
        {
            foreach (Pokemon p in modifiedSelection)
            {
                ratingsList[p.dexNum - 1] = p;
            }
        }
    }
}
