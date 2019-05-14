using Android.Content;
using CN.Jpush.Android.Service;

namespace EMOASApp
{
    [BroadcastReceiver]
    public class Receiver_test : WakedResultReceiver
    {
        public override void OnWake(Context p0, int p1)
        {
            base.OnWake(p0, p1);
        }

        public override void OnWake(int p0)
        {
            base.OnWake(p0);
        }
    }
}