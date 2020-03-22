using Newtonsoft.Json;
using System;

namespace Qc.WechatMiniProgramSdk.Models
{
    /// <summary>
    /// 调用凭据
    /// </summary>
    public class WechatMiniAccessTokenModel : WechatMiniBaseModel
    {
        /// <summary>
        /// 凭证
        /// </summary>
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }

        /// <summary>
        /// 凭证有效时间，单位：秒。目前是7200秒之内的值。
        /// </summary>
        [JsonProperty("expires_in")]
        public int ExpiresIn { get; set; }

        /// <summary>
        /// 凭证有效期止
        /// </summary>
        public DateTime? ExpiresEndTime { get; set; }
    }
}
