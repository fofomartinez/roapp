using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Roapp.VistasModelo;
using Roapp.Modelo;

namespace Roapp.Vistas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Vregistrohistorico : ContentPage
    {
        public Vregistrohistorico()
        {
            InitializeComponent();
        }

        private async void btnGuardar_Clicked(object sender, EventArgs e)
        {
            await InsertarHistorico();
        }

        private async Task InsertarHistorico()
        {
            VMhistorico funcion = new VMhistorico();
            Mhistorico parametros = new Mhistorico();

            parametros.Fecha = txtfecha.Text;
            parametros.Ubicacion = txtubicacion.Text;
            parametros.Tipo = txttipo.Text;

            await funcion.insertar_historico(parametros);

            await DisplayAlert("Registro", "Registro agregado", "ok");

        }


    }
}