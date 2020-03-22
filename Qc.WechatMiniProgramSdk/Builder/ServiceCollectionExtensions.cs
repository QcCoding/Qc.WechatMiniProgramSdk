using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Qc.WechatMiniProgramSdk
{
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// 添加微信小程序SDK，注入默认实现的DefaultWechatMiniProgramSdkHook
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="services"></param>
        /// <param name="optionsAction"></param>
        /// <returns></returns>
        public static IServiceCollection AddWechatMiniProgramSdk(this IServiceCollection services, Action<WechatMiniProgramConfig> optionsAction)
        {
            services.AddWechatMiniProgramSdk<DefaultWechatMiniProgramSdkHook>(optionsAction);

            return services;
        }
        /// <summary>
        /// 添加微信小程序SDK，可注入自定义的IWechatMiniProgramSdkHook
        /// </summary>
        /// <param name="services"></param>
        /// <param name="optionsAction"></param>
        /// <returns></returns>
        public static IServiceCollection AddWechatMiniProgramSdk<T>(this IServiceCollection services, Action<WechatMiniProgramConfig> optionsAction = null) where T : class, IWechatMiniProgramSdkHook
        {
            if (optionsAction != null)
            {
                services.Configure(optionsAction);
            }
            services.AddScoped<IWechatMiniProgramSdkHook, T>();
            services.AddScoped<WechatMiniProgramService, WechatMiniProgramService>();
            services.AddHttpClient();
            return services;
        }
    }
}
