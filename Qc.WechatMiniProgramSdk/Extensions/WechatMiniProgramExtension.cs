using Qc.WechatMiniProgramSdk.Models;

namespace Qc.WechatMiniProgramSdk
{
    public static class WechatMiniProgramApiExtension
    {
        public static bool IsError(this WechatMiniBaseModel input)
        {
            return input == null || string.IsNullOrEmpty(input.ErrCode) == false && input.ErrCode != "0";
        }
        public static bool IsSuccess(this WechatMiniBaseModel input)
        {
            return input != null && string.IsNullOrWhiteSpace(input.ErrCode) || input.ErrCode == "0";
        }
    }
}
