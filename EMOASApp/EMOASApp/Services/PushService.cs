using System;
using Android.App;

namespace EMOASApp.Service
{
    [Service(Name = "cn.jpush.android.service.PushService",
        Enabled = true,
        Exported = false)]
    [IntentFilter(new string[]
    {
        "cn.jpush.android.intent.REGISTER",
        "cn.jpush.android.intent.REPORT",
        "cn.jpush.android.intent.PushService",
        "cn.jpush.android.intent.PUSH_TIME"
    })]
    public partial class PushService
    {

    }
}