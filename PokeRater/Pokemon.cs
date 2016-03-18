﻿using EloRatingTools;

namespace PokeRater
{
    /// <summary>
    /// Public class for the Pokemon object.
    /// </summary>
    public class Pokemon
    {
        #region Members and Accessors
        private string _name;
        public string name
        {
            get
            {
                return _name;
            }
        }

        private int _dexNum;
        public int dexNum
        {
            get
            {
                return _dexNum;
            }
        }

        private int _rating;
        public int rating
        {
            get
            {
                return _rating;
            }
        }

        private int _gamesPlayed;
        public int gamesPlayed
        {
            get
            {
                return _gamesPlayed;
            }
        }
        #endregion

        /// <summary>
        /// Public constructor for Pokemon.
        /// </summary>
        /// <param name="name">Name of the Pokemon.</param>
        /// <param name="dexNum">The Pokemon's national dex number.</param>
        public Pokemon(string name, int dexNum)
        {
            _name = name;
            _dexNum = dexNum;
            _rating = 2000;
            _gamesPlayed = 0;
        }

        /// <summary>
        /// Changes the rating of the Pokemon based on a game.
        /// </summary>
        /// <param name="opponent">Opponent played.</param>
        /// <param name="victoryType">Whether the Pokemon won.</param>
        public void ChangeRating(Pokemon opponent, EloCalculator.VictoryType victoryType)
        {
            _rating = EloCalculator.CalculateNewElo(rating, opponent.rating, gamesPlayed, victoryType);
        }

        /// <summary>
        /// Adds a played game to the Pokemon.
        /// </summary>
        public void PlayGame()
        {
            _gamesPlayed += 1;
        }
    }
}