using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MONDPHPokedex
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PokemonDetailsPage : ContentPage
    {
        public PokemonDetailsPage(Pokemon pokemon)
        {
            InitializeComponent();
            this.Title = pokemon.Name;
            imgThumbnail.Source = pokemon.ImageUrl;
            lblName.Text = pokemon.Name;
            lblDescription.Text = pokemon.Description;
        }
    }
}