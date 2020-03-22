using Newtonsoft.Json;

namespace Qc.WechatMiniProgramSdk.Models
{
    /// <summary>
    /// WechatMiniBaseModel
    /// </summary>
    public class WechatMiniBaseModel
    {
        /// <summary>
        /// 错误码
        /// </summary>
        [JsonProperty("errcode")]
        public string ErrCode { get; set; }

        /// <summary>
        /// 错误信息
        /// </summary>
        [JsonProperty("errmsg")]
        public string ErrMsg { get; set; }
    }
}
