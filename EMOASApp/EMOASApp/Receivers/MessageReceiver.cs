using Android.App;
using Android.Content;
using CN.Jpush.Android.Service;
namespace EMOASApp.Receivers
{
    [BroadcastReceiver(Name = "EMOASApp.Receivers.MessageReceiver",
        Enabled = true,
        Exported = false)]
    [IntentFilter(new string[]{"cn.jpush.android.intent.RECEIVE_MESSAGE"},
        Categories = new string[]{"EMOASApp.EMOASApp"})]
    public class MessageReceiver : JPushMessageReceiver
    {
       
    }
}