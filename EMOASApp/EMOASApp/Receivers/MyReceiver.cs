using Android.App;
using Android.Content;
using Android.Widget;

namespace EMOASApp.Receivers
{
    [BroadcastReceiver(Name = "EMOASApp.Receivers.MyReceiver",
        Enabled = true,
        Exported = false)]
    [IntentFilter(new string[]
    {
        "cn.jpush.android.intent.REGISTRATION",
        "cn.jpush.android.intent.MESSAGE_RECEIVED",
        "cn.jpush.android.intent.NOTIFICATION_RECEIVED",
        "cn.jpush.android.intent.NOTIFICATION_OPENED",
        "cn.jpush.android.intent.CONNECTION"
    },
        Categories = new string[]{"EMOASApp.EMOASApp"})]
    public class MyReceiver : BroadcastReceiver
    {
        public override void OnReceive(Context context, Intent intent)
        {
            Toast.MakeText(context, "Received intent!", ToastLength.Short).Show();
        }
    }
}