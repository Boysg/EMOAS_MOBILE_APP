using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace EMOASApp.Utils
{
    class HttpUtil
    {
        /// <summary>
        /// Get一个异步请求
        /// </summary>
        /// <param name="url">目标url</param>
        /// <returns></returns>
        public async static Task<string> GetAsync(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    string url_dest = WebUtility.UrlEncode(url);
                    HttpResponseMessage response = await client.GetAsync(url_dest);
                    response.EnsureSuccessStatusCode();
                    string responseBody = await response.Content.ReadAsStringAsync();
                    // string responseBody = await client.GetStringAsync(uri);

                    return responseBody;
                }
                catch (HttpRequestException e)
                {
                    Console.WriteLine("error[{0}] :{1} ", url, e.Message);
                    return string.Empty;
                }
            }
        }

        /// <summary>
        /// POST一个异步请求
        /// </summary>
        /// <param name="url">目标url</param>
        /// <param name="args">发送的参数(未序列化)</param>
        /// <returns>成功返回response的内容；失败返回0</returns>
        public async static Task<string> PostAsync(string url, object args)
        {
            using (var client = new HttpClient())
            {
                try
                {
                    //序列化
                    var args_json = JsonConvert.SerializeObject(args);
                    //配置httpContent
                    HttpContent content = new StringContent(args_json);
                    content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                    //发送异步请求
                    HttpResponseMessage response = await client.PostAsync(url, content);
                    //如果不是成功状态码抛出异常
                    response.EnsureSuccessStatusCode();
                    //返回response
                    return await response.Content.ReadAsStringAsync();
                }
                catch (Exception e)
                {
                    Console.WriteLine("error[{0}]: {1}", url, e);
                    return string.Empty;
                }
            }
        }
    }
}