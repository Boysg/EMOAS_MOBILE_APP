using Android.App;
using Android.Content;
using Android.OS;
using Android.Support.V7.App;
using Android.Widget;
using EMOASApp.Entity;
using EMOASApp.Utils;
using Newtonsoft.Json;
using System;
using System.Security.Cryptography;
using System.Threading.Tasks;
using CN.Jpush.Android.Service;

namespace EMOASApp
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            string bm; //用户名
            string app_pwd;  //密码
            //获取Preferences，如果保存有用户名密码直接登录
            ISharedPreferences preferences_login = GetSharedPreferences("login_inf", 0);
            bm = preferences_login.GetString("BM", string.Empty);
            app_pwd = preferences_login.GetString("AppPwd", string.Empty);
            if (!string.IsNullOrEmpty(bm) && !string.IsNullOrEmpty(app_pwd))
            {
                DoLogin(bm, app_pwd);
            }
            //
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_login);
            //获取控件
            EditText editText_user_name = FindViewById<EditText>(Resource.Id.edit_user_name);
            EditText editText_password = FindViewById<EditText>(Resource.Id.edit_password);
            Button button_login = FindViewById<Button>(Resource.Id.btn_login);
            //绑定登录button监听事件
            button_login.Click += (object sender, EventArgs e) =>
            {
                bm = editText_user_name.Text;
                app_pwd = editText_password.Text;
                //存放Preferences
                ISharedPreferencesEditor editor_login = preferences_login.Edit();
                editor_login.PutString("BM", bm);
                editor_login.PutString("AppPwd", app_pwd);
                editor_login.Commit();
                //登录
                DoLogin(bm, app_pwd);
            };
        }

        private bool DoLogin(string bm, string app_pwd)
        {
            using (MD5 pwd_hash = MD5.Create())
            {
                User user = new User()
                {
                    BM = EncryptionUtil.DesEncrypt(bm),
                    AppPwd = EncryptionUtil.GetMd5Hash(pwd_hash, app_pwd)
                };
                //发送至WebApi
                Task<string> response = HttpUtil.PostAsync("http://192.168.1.117:5000/user/login", user);
                string responseResult = response.Result;
                if (response)
                {
                    Toast.MakeText(this, "用户名或密码错误", ToastLength.Short).Show();
                    return false;
                }
                //user接收并保存至全局对象
                Global.GetDictionary().Add("user", JsonConvert.DeserializeObject<User>(response));
                //启用Jpush
                //Todo 
                //跳转首页到Activity
                Intent intent_home = new Intent(this, typeof(HomeActivity));
                StartActivity(intent_home);
            }
            return true;
        }

        protected override void OnPause()
        {
            base.OnPause();
        }
    }

}