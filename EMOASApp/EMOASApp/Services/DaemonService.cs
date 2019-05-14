using Android.App;

namespace EMOASApp.Service
{
    [Service(Name = "cn.jpush.android.service.DaemonService",
        Enabled = true,
        Exported = true)]
    [IntentFilter(new string[]{"cn.jpush.android.intent.DaemonService"},
        Categories = new []{"EMOASApp.EMOASApp"})]
    public partial class DaemonService
    {

    }
}