using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Qc.WechatMiniProgramSdk.Models
{
    public class WechatMiniUserInfoModel
    {
        public string OpenId { get; set; }
        public string NickName { get; set; }
        public int Gender { get; set; }
        public string Language { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string Country { get; set; }
        public string AvatarUrl { get; set; }
        public WechatMiniUserInfoWatermark Watermark { get; set; }

    }
    public class WechatMiniUserInfoWatermark
    {
        public int Timestamp { get; set; }
        public string AppId { get; set; }
    }
}
