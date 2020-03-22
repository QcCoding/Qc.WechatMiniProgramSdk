using Newtonsoft.Json;

namespace Qc.WechatMiniProgramSdk.Models
{
    /// <summary>
    /// auth.code2Session 返回模型
    /// </summary>
    public class WechatMiniUserSessionModel : WechatMiniBaseModel
    {
        /// <summary>
        /// 用户唯一标识
        /// </summary>
        [JsonProperty("openid")]
        public string OpenId { get; set; }

        /// <summary>
        /// 会话密钥
        /// </summary>
        [JsonProperty("session_key")]
        public string SessionKey { get; set; }

        /// <summary>
        /// 用户在开放平台的唯一标识符，在满足 UnionID 下发条件的情况下会返回，详见 UnionID 机制说明 https://developers.weixin.qq.com/miniprogram/dev/framework/open-ability/union-id.html。
        /// </summary>
        [JsonProperty("unionid")]
        public string UnionId { get; set; }
    }
}
