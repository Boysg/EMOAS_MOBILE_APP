using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Widget;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace EMOASApp
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_login);
            //获取控件
            EditText editText_user_name = FindViewById<EditText>(Resource.Id.edit_user_name);
            EditText editText_password = FindViewById<EditText>(Resource.Id.edit_password);
            Button button_login = FindViewById<Button>(Resource.Id.btn_login);
            //绑定监听事件
            button_login.Click += (object sender, EventArgs e) =>
            {
                user user_test = new user();
                user_test.BM = editText_user_name.Text;
                user_test.app_pwd = editText_password.Text;
                string json = JsonConvert.SerializeObject(user_test);
                
                string url = "http://192.168.1.117:5000/user/login/" + Utils.EncryptionUtil.DesEncrypt(json);
                Task<string> rtn = Utils.HttpUtil.GetAsync(url);
            };
        }

        protected override void OnPause()
        {
            base.OnPause();
        }
    }

    public class user
    {
        public string BM { get; set; }

        public string app_pwd { get; set; }
    }
}