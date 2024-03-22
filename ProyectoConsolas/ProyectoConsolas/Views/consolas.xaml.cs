using ProyectoConsolas.ViewModels;
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
            this.BindingContext = new VMConsolas();
        }


        private void OnAgregarClicked(object sender, EventArgs e)
        {
            if (this.BindingContext is VMConsolas viewModel)
            {
                viewModel.ToggleModalCommand.Execute(null);
            }
        }

        private void OnListaJuegos(object sender, EventArgs e)
        {
            if (this.BindingContext is VMConsolas viewModel)
            {
                viewModel.ToggleListaJuegosCommand.Execute(null);
            }
        }

        private void OnEditar(object sender, EventArgs e)
        {
            if (this.BindingContext is VMConsolas viewModel)
            {
                viewModel.ToggleListaJuegosCommand.Execute(null);
            }
        }
        private async void EliminarConsolaTapped(object sender, EventArgs e)
        {
            await DisplayAlert("Eliminar Consola", "¿Estás seguro de que deseas eliminar esta consola?", "Sí", "No");
        }
    }
}