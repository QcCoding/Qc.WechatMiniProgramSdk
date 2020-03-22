using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Qc.WechatMiniProgramSdk
{
    public static class HttpClientExtension
    {

        public static T HttpPostParams<T>(this HttpClient client, string url, IEnumerable<KeyValuePair<string, string>> paraList = null, string contentType = "application/x-www-form-urlencoded")
        {
            var httpContent = new FormUrlEncodedContent(paraList);
            if (contentType != null)
                httpContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(contentType);
            HttpResponseMessage response = client.PostAsync(url, httpContent).Result;
            string result = response.Content.ReadAsStringAsync().Result;
            return Utils.JsonHelper.Deserialize<T>(result);
        }
        public static T HttpPost<T>(this HttpClient client, string url, string postData = null, string contentType = "application/x-www-form-urlencoded")
        {
            postData = postData ?? string.Empty;
            var httpContent = new StringContent(postData, Encoding.UTF8);
            if (contentType != null)
                httpContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(contentType);
            HttpResponseMessage response = client.PostAsync(url, httpContent).Result;
            string result = response.Content.ReadAsStringAsync().Result;
            return Utils.JsonHelper.Deserialize<T>(result);
        }
        public static T HttpPost<T>(this HttpClient client, string url, Dictionary<string, object> dicData)
        {
            string postDataStr = string.Empty;
            int i = 0;
            foreach (var item in dicData)
            {
                if (i++ > 0)
                {
                    postDataStr += "&";
                }
                postDataStr += $"{item.Key}={item.Value}";
            }
            return client.HttpPost<T>(url, postDataStr);
        }
        public static T HttpGet<T>(this HttpClient client, string url)
        {
            HttpResponseMessage response = client.GetAsync(url).Result;
            string result = response.Content.ReadAsStringAsync().Result;
            return Utils.JsonHelper.Deserialize<T>(result);
        }

        public static T HttpGet<T>(this HttpClient client, string url, Dictionary<string, string> queryData)
        {
            var urlAndQuery = AppendUrlQuery(url, queryData);
            return client.HttpGet<T>(urlAndQuery);
        }

        static string AppendUrlQuery(string url, Dictionary<string, string> queryData)
        {
            if (queryData == null || queryData.Count == 0)
                return url;
            string queryStr = string.Empty;
            if ((url.Contains("&") || url.Contains("?")) && !(url.EndsWith("&") || url.EndsWith("?")))
            {
                queryStr += "&";
            }
            else if (!url.Contains("?"))
            {
                queryStr += "?";
            }
            int i = 0;
            foreach (var item in queryData)
            {
                if (i++ > 0)
                {
                    queryStr += "&";
                }
                queryStr += $"{item.Key}={item.Value}";
            }
            url += queryStr;
            return url;
        }
    }
}
