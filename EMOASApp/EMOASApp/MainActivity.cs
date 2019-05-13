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
using CN.Jpush.Android.Api;

namespace EMOASApp
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        User user = new User();
        protected override void OnCreate(Bundle savedInstanceState)
        {
            //获取
            ISharedPreferences preferences_login = GetSharedPreferences("login_inf", 0);
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
                using (MD5 pwd_hash = MD5.Create())
                {
                    //密码加密
                    string pwd_encrypted = EncryptionUtil.GetMd5Hash(pwd_hash, editText_password.Text);
                    User user_login = new User
                    {
                        BM = editText_user_name.Text,
                        AppPwd = editText_password.Text
                    };
                    //Preferences
                    ISharedPreferencesEditor editor_login = preferences_login.Edit();
                    editor_login.PutString("BM", user_login.BM);
                    editor_login.PutString("AppPwd", pwd_encrypted);
                    editor_login.Commit();
                    //发送至WebApi
                    string json_login = JsonConvert.SerializeObject(user_login);
                    string url = "http://192.168.1.117:5000/user/login/" + EncryptionUtil.DesEncrypt(json_login);
                    Task<string> response = HttpUtil.GetAsync(url);
                    if (response == null)
                    {
                        Toast.MakeText(this, "用户名或密码错误", ToastLength.Short).Show();
                        return;
                    }
                    //user接收
                    user = JsonConvert.DeserializeObject<User>(response.Result);

                }
            };
        }

        protected override void OnPause()
        {
            base.OnPause();
        }
    }
}