using PokeRater;
using System.Collections.Generic;
using System.Windows.Input;

namespace PokeRaterUI
{
    public class RaterViewModel : ViewModelBase { 

        private List<Pokemon> _currentSelection;
        public List<Pokemon> CurrentSelection
        {
            get { return _currentSelection; }
            set { _currentSelection = value; RaisePropertyChangedEvent("CurrentSelection"); }
        }

        private IGamePlayer player;

        public RaterViewModel(IGamePlayer player)
        {
            this.player = player;
            UpdateSelection();
        }

        private void UpdateSelection()
        {
            CurrentSelection = new List<Pokemon>(player.GetNewSelection());
        }

        private ICommand _choosePokemonCommand;
        public ICommand ChoosePokemonCommand
        {
            get
            {
                return _choosePokemonCommand ?? (_choosePokemonCommand = new CommandHandler<Pokemon>(p => ChoosePokemon(p), true));
            }
        }

        public void ChoosePokemon(Pokemon choice)
        {
            player.PlayGame(CurrentSelection.ToArray(), choice);
            UpdateSelection();
        }
    }
}
