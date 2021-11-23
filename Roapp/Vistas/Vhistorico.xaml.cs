using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Roapp.VistasModelo;

namespace Roapp.Vistas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Vhistorico : ContentPage
    {
        public Vhistorico()
        {
            InitializeComponent();
            _ = mostrarhistorial();
            //lo de abajo debo borrar
            BindingContext = new VMmenuprincipal(Navigation);
        }

        private async Task mostrarhistorial()
        {
            VMhistorico funcion = new VMhistorico();
            var dt = await funcion.mostrar_historico();
            historico.ItemsSource = dt;
        }
    }
}