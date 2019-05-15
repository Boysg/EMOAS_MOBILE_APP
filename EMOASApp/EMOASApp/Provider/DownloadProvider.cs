using Android.Content;

namespace EMOASApp.Provider
{
    [ContentProvider(new []{"EMOASApp.EMOASApp.DownloadProvider"},
        Name = "cn.jpush.android.service.DownloadProvider",
        Exported = true)]
    public partial class DownloadProvider
    {

    }
}