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
        // Método para manejar el clic en la imagen de eliminar
        private async void OnEliminarClicked(object sender, EventArgs e)
        {
            // Mostrar un alert al usuario para confirmar la eliminación
            bool eliminar = await DisplayAlert("Eliminar", "¿Estás seguro que quieres eliminar este juego?", "Sí", "No");

            if (eliminar)
            {
                // Lógica para eliminar el elemento
                // Aquí debes llamar al método de tu ViewModel para eliminar el elemento correspondiente
            }
        }
    }
}