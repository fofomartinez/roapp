using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Forms.GoogleMaps;
using Xamarin.Essentials;

namespace Roapp.Vistas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Vgeolocalizacion : ContentPage
    {
        Pin punto = new Pin();
        public static double latitud = 16.146847;
        public static double longitud = -89.944107;

        public Vgeolocalizacion()
        {
            InitializeComponent();
        }

        private void map_PinDragEnd(object sender, Xamarin.Forms.GoogleMaps.PinDragEventArgs e)
        {
            var posicion = new Position(e.Pin.Position.Latitude, e.Pin.Position.Longitude);
            map.MoveToRegion(MapSpan.FromCenterAndRadius(posicion, Distance.FromMeters(500)));
            latitud = e.Pin.Position.Latitude;
            longitud = e.Pin.Position.Longitude;
        }

        protected override async void OnAppearing()
        {
            punto = new Pin()
            {
                Label = "Tu ubicación",
                Type = PinType.Place,
                Icon = (Device.RuntimePlatform == Device.Android) ? BitmapDescriptorFactory.FromBundle("pin.png") : BitmapDescriptorFactory.FromView(new Image() { Source = "pin.png", WidthRequest = 64, HeightRequest = 64 }),
                Position = new Position(0, 0),
                IsDraggable = true
            };
            map.Pins.Add(punto);
            await LocalizacionActual();
            await MapearSolicitudes();

        }

        public async Task LocalizacionActual()
        {
            try
            {
                var location = await Geolocation.GetLastKnownLocationAsync();
                if (location == null)
                {
                    location = await Geolocation.GetLocationAsync(new GeolocationRequest
                    {

                        DesiredAccuracy = GeolocationAccuracy.High,
                        Timeout = TimeSpan.FromSeconds(30)
                    });

                }
                if (location == null)
                {
                    await DisplayAlert("Alerta", "Sin acceso al GPS", "OK");
                }
                else
                {
                    latitud = location.Latitude;
                    longitud = location.Longitude;
                    var posicion = new Position(latitud, longitud);
                    punto.Position = new Position(latitud, longitud);
                    map.MoveToRegion(MapSpan.FromCenterAndRadius(posicion, Distance.FromMeters(500)));
                }
            }
            catch (Exception)
            {
                await DisplayAlert("Alerta", "Problemas con el GPS del móvil", "OK");
            }
        }



        public async Task MapearSolicitudes()
        {

                double latitud = 16.043918;
                double longitud = -89.926112;
                Pin Puntocliente = new Pin();
                Puntocliente = new Pin()
                {
                    Label = "Punto de reunion",
                    Type = PinType.Place,
                    Icon = (Device.RuntimePlatform == Device.Android) ? BitmapDescriptorFactory.FromBundle("proteger.png") : BitmapDescriptorFactory.FromView(new Image() { Source = "proteger.png", WidthRequest = 64, HeightRequest = 64 }),
                    Position = new Position(latitud, longitud),
                    IsDraggable = true
                };
                map.Pins.Add(Puntocliente);

            double latitud2 = 16.160999;
            double longitud2 = -89.986853;
            Pin Puntocliente2 = new Pin();
            Puntocliente2 = new Pin()
            {
                Label = "Punto de reunion",
                Type = PinType.Place,
                Icon = (Device.RuntimePlatform == Device.Android) ? BitmapDescriptorFactory.FromBundle("proteger.png") : BitmapDescriptorFactory.FromView(new Image() { Source = "proteger.png", WidthRequest = 64, HeightRequest = 64 }),
                Position = new Position(latitud2, longitud2),
                IsDraggable = true
            };
            map.Pins.Add(Puntocliente2);

            /*

            double latitud3 = 15.469288;
            double longitud3 = 90.378040;
            , 
            */

            double latitud3 = 16.322111;
            double longitud3 = -90.171577;
            Pin Centro = new Pin();
            Centro = new Pin()
            {
                Label = "Punto de reunion",
                Type = PinType.Place,
                Icon = (Device.RuntimePlatform == Device.Android) ? BitmapDescriptorFactory.FromBundle("hospital.png") : BitmapDescriptorFactory.FromView(new Image() { Source = "hospital.png", WidthRequest = 64, HeightRequest = 64 }),
                Position = new Position(latitud3, longitud3),
                IsDraggable = true
            };
            map.Pins.Add(Centro);



        }


    }
}