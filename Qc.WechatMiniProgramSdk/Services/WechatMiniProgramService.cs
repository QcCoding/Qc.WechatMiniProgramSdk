using Microsoft.Extensions.Options;
using Qc.WechatMiniProgramSdk.Models;
using Qc.WechatMiniProgramSdk.Utils;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace Qc.WechatMiniProgramSdk
{
    public class WechatMiniProgramService
    {
        private readonly HttpClient _httpClient;
        private readonly WechatMiniProgramConfig _apiConfig;
        private readonly IWechatMiniProgramSdkHook _sdkHook;
        public WechatMiniProgramService(IHttpClientFactory _httpClientFactory
            , IWechatMiniProgramSdkHook WechatMiniProgramSdkHook
            )
        {
            _sdkHook = WechatMiniProgramSdkHook;
            _apiConfig = WechatMiniProgramSdkHook.GetConfig();
            if (_apiConfig == null)
                throw new Exception("WechatMiniProgram not configured");
            _httpClient = _httpClientFactory.CreateClient("WechatMiniProgram");
            if (!string.IsNullOrWhiteSpace(_apiConfig.ApiUrl))
                _httpClient.BaseAddress = new Uri(_apiConfig.ApiUrl);
            if (_apiConfig.Timeout.HasValue)
                _httpClient.Timeout = TimeSpan.FromSeconds(_apiConfig.Timeout.Value);
        }

        /// <summary>
        /// 登录凭证校验。通过 wx.login[https://developers.weixin.qq.com/miniprogram/dev/api/open-api/login/wx.login.html] 接口获得临时登录凭证 code 后传到开发者服务器调用此接口完成登录流程。
        /// 更多使用方法详见 小程序登录 https://developers.weixin.qq.com/miniprogram/dev/framework/open-ability/login.html。
        /// </summary>
        /// <param name="jsCode"></param>
        /// <returns></returns>
        public WechatMiniUserSessionModel Auth_Code2Session(string jsCode)
        {
            var result = _httpClient.HttpGet<WechatMiniUserSessionModel>($"sns/jscode2session?appid={_apiConfig.AppId}&secret={_apiConfig.AppSecret}&js_code={jsCode}&grant_type=authorization_code");
            return result;
        }

        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <param name="sessionKey"></param>
        /// <param name="encryptedData"></param>
        /// <param name="iv"></param>
        /// <returns></returns>
        public WechatMiniUserInfoModel Qc_GetUserInfo(string sessionKey, string encryptedData, string iv)
        {
            var plaintextUserInfo = WechatMiniEncryptionHelper.AesDecryptData(sessionKey, iv, encryptedData);
            if (plaintextUserInfo != null)
                return JsonHelper.Deserialize<WechatMiniUserInfoModel>(plaintextUserInfo);
            return null;
        }

        /// <summary>
        /// 获取接口调用凭据
        /// </summary>
        /// <returns></returns>
        public WechatMiniAccessTokenModel Auth_GetAccessToken()
        {
            return _sdkHook.CacheAccessToken(() =>
            {
                var result = _httpClient.HttpGet<WechatMiniAccessTokenModel>($"/cgi-bin/token?grant_type=client_credential&appid={_apiConfig.AppId}&secret={_apiConfig.AppSecret}");
                return result;
            });
        }
    }
}
