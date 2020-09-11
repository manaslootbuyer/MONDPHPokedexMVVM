using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MONDPHPokedex.ViewModel;
using Xamarin.Forms;

namespace MONDPHPokedex
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public IList<Pokemon> PokemonsList { get; private set; }

        public MainPage()
        {
            InitializeComponent();
            this.BindingContext = new MainViewModel();
            PopulateList();
            listPokemon.ItemsSource = PokemonsList;
        }

        private void PopulateList() 
        {
            PokemonsList = new List<Pokemon>();

            PokemonsList.Add(new Pokemon
            {
                Name = "Pikachu",
                Description = "Pikachu is an Electric type Pokémon introduced in Generation 1. It is known as the Mouse Pokémon.",
                ImageUrl = "https://mondphpokedexapi.azurewebsites.net/images/pikachu.jpg"
            });

            PokemonsList.Add(new Pokemon
            {
                Name = "Bulbasaur",
                Description = "Bulbasaur is a Grass/Poison type Pokémon introduced in Generation 1. It is known as the Seed Pokémon.",
                ImageUrl = "https://mondphpokedexapi.azurewebsites.net/images/bulbasaur.jpg"
            });

            PokemonsList.Add(new Pokemon
            {
                Name = "Charmander",
                Description = "Charmander is a Fire type Pokémon introduced in Generation 1. It is known as the Lizard Pokémon.",
                ImageUrl = "https://mondphpokedexapi.azurewebsites.net/images/charmander.jpg"
            });

            PokemonsList.Add(new Pokemon
            {
                Name = "Butterfree",
                Description = "Butterfree is a Bug/Flying type Pokémon introduced in Generation 1. It is known as the Butterfly Pokémon.",
                ImageUrl = "https://mondphpokedexapi.azurewebsites.net/images/butterfree.jpg"
            });

            PokemonsList.Add(new Pokemon
            {
                Name = "Pidgeotto",
                Description = "Pidgeotto is a Normal/Flying type Pokémon introduced in Generation 1. It is known as the Bird Pokémon.",
                ImageUrl = "https://mondphpokedexapi.azurewebsites.net/images/pidgeotto.jpg"
            });

            PokemonsList.Add(new Pokemon
            {
                Name = "Raichu",
                Description = "Raichu is an Electric type Pokémon introduced in Generation 1. It is known as the Mouse Pokémon.\nRaichu has a new Alolan form introduced in Pokémon Sun/Moon.",
                ImageUrl = "https://mondphpokedexapi.azurewebsites.net/images/raichu.jpg"
            });
        }

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(searchBar.Text))
            {
                var searchResult = PokemonsList.Where(c => c.Name.ToLower().Contains(searchBar.Text.ToLower()));
                PokemonsList = searchResult.ToList();
            }
            else 
            {
                PopulateList();
            }

            listPokemon.ItemsSource = PokemonsList;
        }

        private void ListPokemon_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            Pokemon selectedItem = e.Item as Pokemon;
            Navigation.PushAsync(new PokemonDetailsPage(selectedItem));
        }
    }
}
