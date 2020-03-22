using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using System.Security.Cryptography;

namespace Qc.WechatMiniProgramSdk
{
    public static class BuilderExtensions
    {
        public static IApplicationBuilder UseWechatMiniProgramSdk(this IApplicationBuilder app, Func<WechatMiniProgramConfig> configHandler)
        {
            return app;
        }
    }
}
