using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Roapp.Servicios;
using Plugin.CurrentActivity;

[Application(Debuggable =true)]
[MetaData("com.google.android.maps.v2.API_KEY",
    Value = Conexionfirebase.GoogleMapsApiKey)]
public class Activitymaps:Application
{
    public Activitymaps(IntPtr handle, JniHandleOwnership transfer)
    : base(handle, transfer)
    {

    }

    public override void OnCreate()
    {
        base.OnCreate();
        CrossCurrentActivity.Current.Init(this);
    }
}

    
