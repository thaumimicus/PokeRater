namespace PokeRater
{
    public interface IGamePlayer
    {
        void PlayGame(Pokemon[] selection, Pokemon winner);
        Pokemon[] GetNewSelection();
    }
}