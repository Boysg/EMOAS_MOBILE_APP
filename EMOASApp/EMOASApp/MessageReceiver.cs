﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using CN.Jpush.Android.Service;
namespace EMOASApp
{
    [BroadcastReceiver]
    public class MessageReceiver : JPushMessageReceiver
    {
       
    }
}