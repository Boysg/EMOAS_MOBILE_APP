using Android.Content;

namespace EMOASApp.Provider
{
    [ContentProvider(new []{"EMOASApp.EMOASApp.DataProvider"},
        Enabled = true,
        Name = "cn.jpush.android.service.DataProvider")]
    public partial class DataProvider
    {

    }
}