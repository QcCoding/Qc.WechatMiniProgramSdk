using Microsoft.Extensions.Options;
using Qc.WechatMiniProgramSdk.Models;
using Qc.WechatMiniProgramSdk.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Qc.WechatMiniProgramSdk
{
    public class DefaultWechatMiniProgramSdkHook : IWechatMiniProgramSdkHook
    {
        private readonly WechatMiniProgramConfig _apiConfig;
        public DefaultWechatMiniProgramSdkHook(IOptions<WechatMiniProgramConfig> options)
        {
            _apiConfig = options.Value;
        }
        /// <summary>
        /// 获取配置
        /// </summary>
        /// <returns></returns>
        public WechatMiniProgramConfig GetConfig()
        {
            return _apiConfig;
        }
        /// <summary>
        /// 从缓存中获取AccessToken等信息
        /// </summary>
        /// <returns></returns>
        private WechatMiniAccessTokenModel GetTokenInfo()
        {
            string readPath = Path.Combine(Path.GetFullPath(_apiConfig.SaveTokenDirPath), _apiConfig.AppId + ".txt");
            if (!File.Exists(readPath))
                return null;
            var accessResult = File.ReadAllText(readPath);
            var result = JsonHelper.Deserialize<WechatMiniAccessTokenModel>(accessResult);
            if (result.ExpiresEndTime.HasValue && result.ExpiresEndTime.Value <= DateTime.Now)
                return null;
            return result;
        }
        /// <summary>
        /// 保存Token信息
        /// </summary>
        /// <returns></returns>
        private WechatMiniAccessTokenModel SaveTokenInfo(WechatMiniAccessTokenModel input)
        {
            if (!Directory.Exists(_apiConfig.SaveTokenDirPath))
            {
                Directory.CreateDirectory(_apiConfig.SaveTokenDirPath);
            }
            string savePath = Path.Combine(_apiConfig.SaveTokenDirPath, _apiConfig.AppId + ".txt");
            input.ExpiresEndTime = DateTime.Now.AddSeconds(input.ExpiresIn - 5 * 60);
            File.WriteAllText(savePath, JsonHelper.Serialize(input));
            return input;
        }

        /// <summary>
        /// 从缓存中获取AccessToken信息,没有则设置
        /// </summary>
        /// <param name="action"></param>
        /// <returns></returns>
        public WechatMiniAccessTokenModel CacheAccessToken(Func<WechatMiniAccessTokenModel> action)
        {
            var tokenInfo = GetTokenInfo();
            if (tokenInfo != null)
            {
                return tokenInfo;
            }
            tokenInfo = action();
            if (tokenInfo.IsError())
                return tokenInfo;

            return SaveTokenInfo(tokenInfo);
        }
    }
}
