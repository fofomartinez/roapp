using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Plugin.SimpleAudioPlayer;
using System.Reflection;
using System.IO;

namespace Roapp.Vistas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Valarma : ContentPage
    {
        
        public Valarma()
        {
            InitializeComponent();
        }


        public void PlayAlarma()
        {
            var seed = Environment.TickCount;
            var random = new Random(seed);
            int value = random.Next(0, 4);
            this.btnon.IsVisible = true;

            
            string sonidos = "Roapp.Sonidos.Alerta.mp3";

            if (value == 1)
            {
                sonidos = "Roapp.Sonidos.Sismo.mp3";
                this.txtsismo.IsVisible = true;

            }
            else if(value == 2)
            {
                sonidos = "Roapp.Sonidos.Inundaciones.mp3";
                this.txtinundacion.IsVisible = true;

            }
            else if (value == 3)
            {
                sonidos = "Roapp.Sonidos.Huracan.mp3";
                this.txthuracan.IsVisible = true;
            }
            else 
            {
                sonidos = "Roapp.Sonidos.Alerta.mp3";
                this.txtalarma.IsVisible = true;

            }
            //await DisplayAlert("Registro", "valor: "+sonidos, "ok");

            var assembly = typeof(App).GetTypeInfo().Assembly;
            Stream audioStream = assembly.GetManifestResourceStream(sonidos);
            var audio = Plugin.SimpleAudioPlayer.CrossSimpleAudioPlayer.Current;
            audio.Load(audioStream);
            audio.Play();
        }

        public void StopAlarma()
        {
            var assembly = typeof(App).GetTypeInfo().Assembly;
            Stream audioStream = assembly.GetManifestResourceStream("Roapp.Sonidos.Alerta.mp3");
            var audio = Plugin.SimpleAudioPlayer.CrossSimpleAudioPlayer.Current;
            audio.Load(audioStream);
            audio.Stop();
            this.txthuracan.IsVisible = false;
            this.txtinundacion.IsVisible = false;
            this.txtsismo.IsVisible = false;
            this.txtalarma.IsVisible = false;
        }



        private void btnoff_Clicked(object sender, EventArgs e)
        {



            this.imgdormir.IsVisible = false;
            this.imgalarma.IsVisible = true;
            this.btnoff.IsVisible = false;

            Device.BeginInvokeOnMainThread(() => PlayAlarma());

        }

        private void btnon_Clicked(object sender, EventArgs e)
        {
            this.imgdormir.IsVisible = true;
            this.imgalarma.IsVisible = false;
            this.btnoff.IsVisible = true;
            this.btnon.IsVisible = false;
            Device.BeginInvokeOnMainThread(() => StopAlarma());

        }
    }
}