using Android.App;
using Android.Content;
using Android.Views.Animations;

namespace EMOASApp.Receivers
{
    [BroadcastReceiver(Name = "cn.jpush.android.service.PushReceiver",
        Enabled = true)]
    [IntentFilter(
        new string[]
        {
            "cn.jpush.android.intent.NOTIFICATION_RECEIVED_PROXY",
            "android.intent.action.USER_PRESENT",
            "android.net.conn.CONNECTIVITY_CHANGE",
            "android.intent.action.PACKAGE_ADDED",
            "android.intent.action.PACKAGE_REMOVED",
        },
        Categories = new string[]{"EMOASApp.EMOASApp"},
        Priority = 1000,
        DataScheme = "package")]
    public partial class PushReceiver
    {

    }
}