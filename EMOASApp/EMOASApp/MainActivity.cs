using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Newtonsoft.Json;
using System;
using System.Net.Http;

namespace EMOASApp
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_login);
            string url = "http://192.168.1.117:5000/message/test";
        }
    }
}