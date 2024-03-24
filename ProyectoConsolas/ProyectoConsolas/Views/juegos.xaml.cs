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
	public partial class juegos : ContentPage
	{
		public juegos ()
		{
			InitializeComponent ();

            this.BindingContext = new VMJuegos();
        }

        private void MostrarRegistro(object sender, EventArgs e)
        {
            if (this.BindingContext is VMJuegos viewModel)
            {
                viewModel.ToggleModalRegistroCommand.Execute(null);
            }
        }

        private void CerrarModalEditar(object sender, EventArgs e)
        {
            if (this.BindingContext is VMJuegos viewModel)
            {
                viewModel.ToggleModalEdidarCommand.Execute(null);
            }
        }


    }
}