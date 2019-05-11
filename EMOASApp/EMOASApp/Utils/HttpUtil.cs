using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Newtonsoft.Json;

namespace EMOASApp.Utils
{
    class HttpUtil
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="url"></param>
        /// <param name="args"></param>
        public async static Task<string> GetRouteData(string url, object args)
        {
            using (var client = new HttpClient())
            {
                try
                {
                    //序列化
                    var str = JsonConvert.SerializeObject(args);

                    HttpContent content = new StringContent(str);
                    content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                    HttpResponseMessage response = await client.PostAsync(url, content);//改成自己的

                    response.EnsureSuccessStatusCode();//用来抛异常的
                    return await response.Content.ReadAsStringAsync();
                }
                catch (Exception e)
                {
                    Console.WriteLine("\nException Caught!");
                    Console.WriteLine("Message :{0} ", e.Message);
                    return "error";
                }
            }
        }
    }
}