using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using EMOASApp.Entity;
using EMOASApp.Utils;
using System;
using System.Security.Cryptography;
using Android.Support.V7.App;
using Newtonsoft.Json;

namespace EMOASApp
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            User user_login = new User();
            //获取Preferences，如果保存有用户名密码直接登录
            ISharedPreferences preferences_login = GetSharedPreferences("login_inf", 0);
            user_login.BM = preferences_login.GetString("BM", string.Empty);
            user_login.AppPwd = preferences_login.GetString("AppPwd", string.Empty);
            if (user_login.BM.Length > 0 && user_login.AppPwd.Length > 0)
            {
                DoLogin(user_login);
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
                using (MD5 pwd_hash = MD5.Create())
                {
                    //密码加密
                    string bm_encrypted = EncryptionUtil.DesEncrypt(editText_user_name.Text);
                    string pwd_encrypted = EncryptionUtil.GetMd5Hash(pwd_hash, editText_password.Text);
                    user_login.BM = bm_encrypted;
                    user_login.AppPwd = pwd_encrypted;
                    //存放Preferences
                    ISharedPreferencesEditor editor_login = preferences_login.Edit();
                    editor_login.PutString("BM", user_login.BM);
                    editor_login.PutString("AppPwd", user_login.AppPwd);
                    editor_login.Commit();
                }
                DoLogin(user_login);
            };
        }

        private bool DoLogin(User user)
        {
            //发送至WebApi
            string url = "http://192.168.1.117:5000/user/login";
            string response = HttpUtil.PostAsync(url, user).Result;
            if (string.IsNullOrEmpty(response))
            {
                Toast.MakeText(this, "用户名或密码错误", ToastLength.Short).Show();
                return false;
            }
            //user接收并保存至全局对象
            Global global = Application as Global;
            global.User = JsonConvert.DeserializeObject<User>(response);
            //启用Jpush
            //Todo 
            //跳转首页到Activity
            Intent intent_home = new Intent(this, typeof(HomeActivity));
            StartActivity(intent_home);

            return true;
        }

        protected override void OnPause()
        {
            base.OnPause();
        }
    }

}