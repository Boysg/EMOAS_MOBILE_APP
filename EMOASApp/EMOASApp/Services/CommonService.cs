using Android.App;
using CN.Jpush.Android.Service;

namespace EMOASApp.Service
{
    [Service(Name = "EMOASApp.Service.CommonService",
        Process = ":pushcore")]
    [IntentFilter(new string[]{"cn.jiguang.user.service.action"})]
    class CommonService : JCommonService
    {
    }
}