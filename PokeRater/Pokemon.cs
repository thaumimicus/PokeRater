using EloRatingTools;
using System.Data;

namespace PokeRater
{
    /// <summary>
    /// Public class for the Pokemon object.
    /// </summary>
    public class Pokemon
    {
        #region Members and Accessors
        private string _name;
        public string Name
        {
            get
            {
                return _name;
            }
        }

        private int _dexNum;
        public int DexNum
        {
            get
            {
                return _dexNum;
            }
        }

        private int _rating;
        public int Rating
        {
            get
            {
                return _rating;
            }
        }

        private int _gamesPlayed;
        public int GamesPlayed
        {
            get
            {
                return _gamesPlayed;
            }
        }
        #endregion


        public Pokemon(DataRow row)
        {
            _name = (string)row["Name"];
            _dexNum = (int)row["DexNum"];
            _rating = (int)row["Rating"];
            _gamesPlayed = (int)row["GamesPlayed"];
        }

        public Pokemon(string name, int dexnum)
        {
            _name = name;
            _dexNum = dexnum;
            _rating = 2000;
        }

        public void ChangeRating(int newRating)
        {
            _rating = newRating;
        }

        /// <summary>
        /// Changes the rating of the Pokemon based on a game.
        /// </summary>
        /// <param name="opponent">Opponent played.</param>
        /// <param name="victoryType">Whether the Pokemon won.</param>
        public void ChangeRating(Pokemon opponent, EloCalculator.VictoryType victoryType)
        {
            _rating = EloCalculator.CalculateNewElo(Rating, opponent.Rating, GamesPlayed, victoryType);
        }

        /// <summary>
        /// Adds a played game to the Pokemon.
        /// </summary>
        public void PlayGame()
        {
            _gamesPlayed += 1;
        }

        public override string ToString()
        {
            return DexNum + ": " + Name;
        }
    }
}