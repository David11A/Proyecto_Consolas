﻿using ProyectoConsolas.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProyectoConsolas
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class consolas : ContentPage
    {
        public consolas()
        {
            InitializeComponent();
            this.BindingContext = new Consolas();
        }
    }
}