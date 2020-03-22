using Qc.WechatMiniProgramSdk.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Qc.WechatMiniProgramSdk
{
    public interface IWechatMiniProgramSdkHook
    {
        /// <summary>
        /// 获取OCR配置
        /// </summary>
        /// <returns></returns>
        WechatMiniProgramConfig GetConfig();

        /// <summary>
        /// 从缓存中获取AccessToken信息,没有则设置
        /// </summary>
        /// <param name="action"></param>
        /// <returns></returns>
        WechatMiniAccessTokenModel CacheAccessToken(Func<WechatMiniAccessTokenModel> action);
    }
}
