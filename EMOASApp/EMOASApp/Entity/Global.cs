using Android.App;
using System;
using System.Collections.Generic;

namespace EMOASApp.Entity
{
    //[Application]
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
}