﻿using System;
using BMDex.ViewModels;
using Prism.Regions;

namespace BMDex.Views
{
    public partial class PokemonListPage
    {
        public PokemonListPage()
        {
            Content = Build();

            //BindingContext = new PokemonListViewModel(Prism.Resolve());
        }
    }
}
