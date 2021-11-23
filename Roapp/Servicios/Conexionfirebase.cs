using System;
using System.Collections.Generic;
using System.Text;
using Firebase.Database;

namespace Roapp.Servicios
{
    public class Conexionfirebase
    {
        public static FirebaseClient firebase = new FirebaseClient("https://roapp-5dc09-default-rtdb.firebaseio.com/");
        public const string GoogleMapsApiKey = "AIzaSyDW8VPwKFWLe3xKqx7rom7Sye2LQMqIKew";
    }
}
