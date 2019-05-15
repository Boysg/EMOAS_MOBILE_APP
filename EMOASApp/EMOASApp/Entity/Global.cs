using Android.App;
using Android.Content.PM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
[assembly: Permission(Name = "EMOASApp.EMOASApp.permission.JPUSH_MESSAGE",
    ProtectionLevel = Protection.Signature)]
[assembly: UsesPermission(Name = "EMOASApp.EMOASApp.permission.JPUSH_MESSAGE")]
[assembly: UsesPermission(Name = Android.Manifest.Permission.Internet)]
[assembly: UsesPermission(Name = "android.permission.RECEIVE_USER_PRESENT")]
[assembly: UsesPermission(Name = "android.permission.READ_PHONE_STATE")]
[assembly: UsesPermission(Name = "android.permission.WRITE_EXTERNAL_STORAGE")]
[assembly: UsesPermission(Name = "android.permission.READ_EXTERNAL_STORAGE")]
[assembly: UsesPermission(Name = "android.permission.MOUNT_UNMOUNT_FILESYSTEMS")]
[assembly: UsesPermission(Name = "android.permission.ACCESS_NETWORK_STATE")]
[assembly: UsesPermission(Name = "android.permission.WRITE_SETTINGS")]
[assembly: UsesPermission(Name = "android.permission.ACCESS_WIFI_STATE")]
[assembly: UsesPermission(Name = "android.permission.SYSTEM_ALERT_WINDOW")]
[assembly: UsesPermission(Name = "android.permission.ACCESS_COARSE_LOCATION")]
[assembly: UsesPermission(Name = "android.permission.CHANGE_WIFI_STATE")]
[assembly: UsesPermission(Name = "android.permission.ACCESS_FINE_LOCATION")]
[assembly: UsesPermission(Name = "android.permission.ACCESS_LOCATION_EXTRA_COMMANDS")]
[assembly: UsesPermission(Name = "android.permission.CHANGE_NETWORK_STATE")]
[assembly: UsesPermission(Name = "android.permission.GET_TASKS")]
[assembly: UsesPermission(Name = "android.permission.VIBRATE")]
namespace EMOASApp.Entity
{
    [Application]
    [MetaData("JPUSH_CHANNEL", Value = "developer-default")]
    [MetaData("JPUSH_APPKEY", Value = "b48bef51c51b50d39b93a9f5")]
    class Global : Application
    {
        private static Dictionary<string, object> dictionary = new Dictionary<string, object>();

        private static Global global;

        public static Global GetGlobal()
        {
            return global;
        }

        public static Dictionary<string, object> GetDictionary()
        {
            return dictionary;
        }

        public override void OnCreate()
        {
            base.OnCreate();
            global = this;
        }
    }