using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Roapp.VistaModelo;
using Xamarin.Forms;
using Roapp.Vistas;

namespace Roapp.VistasModelo
{
    class VMmenuprincipal:BaseViewModel
    {
        #region VARIABLES
       
        #endregion
        #region CONSTRUCTOR
        public VMmenuprincipal(INavigation navigation)
        {
            Navigation = navigation;
            Navegarhistoricocommand = new Command(async () => await NavegarHistorico());
            Navegarnewhistoricocommand = new Command(async () => await NavegarNuevo());
            NavegarAlarmacommand = new Command(async () => await NavegarAlarma());
            NavegarGeocommand = new Command(async () => await NavegarGeo());

        }
        #endregion
        #region OBJETOS 
        
       

        #endregion
        #region PROCESOS
        private async Task NavegarHistorico()
        {
            
            await Navigation.PushAsync(new Vhistorico());
        }

        private async Task NavegarNuevo()
        {

            await Navigation.PushAsync(new Vregistrohistorico());
        }

        private async Task NavegarAlarma()
        {

            await Navigation.PushAsync(new Valarma());
        }

        private async Task NavegarGeo()
        {

            await Navigation.PushAsync(new Vgeolocalizacion());
        }

        #endregion
        #region COMANDOS
        public Command Navegarhistoricocommand { get; }
        public Command Navegarnewhistoricocommand { get; }
        public Command NavegarAlarmacommand { get; }
        public Command NavegarGeocommand { get; }



        #endregion
    }
}

