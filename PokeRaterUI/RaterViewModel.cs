using PokeRater;
using PokeRaterUI.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace PokeRaterUI
{
    public class RaterViewModel : ViewModelBase
    {
        private List<PokemonSprite> _currentSelection;
        public List<PokemonSprite> CurrentSelection
        {
            get { return _currentSelection; }
            set { _currentSelection = value; RaisePropertyChangedEvent("CurrentSelection"); }
        }

        private IGamePlayer player;

        public RaterViewModel(IGamePlayer player)
        {
            this.player = player;
            CurrentSelection = new List<PokemonSprite>();
            UpdateSelection();
        }

        private void UpdateSelection()
        {
            CurrentSelection = player.GetNewSelection().Select(p => new PokemonSprite(p, new BitmapImage(new Uri("pack://application:,,,/PokeRaterUI;component/PokemonPixelSprites/" + p.DexNum + ".png")))).ToList();
        }

        private ICommand _choosePokemonCommand;
        public ICommand ChoosePokemonCommand
        {
            get
            {
                return _choosePokemonCommand ?? (_choosePokemonCommand = new CommandHandler<PokemonSprite>(p => ChoosePokemon(p.Poke), true));
            }
        }

        public void ChoosePokemon(Pokemon choice)
        {
            player.PlayGame(CurrentSelection.Select(p => p.Poke).ToArray(), choice);
            UpdateSelection();
        }

        public class PokemonSprite
        {
            public BitmapImage Image { get; set; }
            public Pokemon Poke { get; set; }

            public PokemonSprite(Pokemon p, BitmapImage b)
            {
                this.Image = b;
                this.Poke = p;
            }
        }
    }
}
