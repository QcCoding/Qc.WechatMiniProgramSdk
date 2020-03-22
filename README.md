# WechatMiniProgramSdk

## Qc.WechatMiniProgramSdk

`Qc.WechatMiniProgramSdk` 是一个基于 `.NET Standard 2.0` 构建，对微信小程序平台的常用接口进行了封装。


### 使用 WechatMiniProgramSdk


#### 一.安装程序包

[![Nuget](https://img.shields.io/nuget/v/Qc.WechatMiniProgramSdk)](https://www.nuget.org/packages/Qc.WechatMiniProgramSdk/)

- dotnet cli  
  `dotnet add package Qc.WechatMiniProgramSdk`
- 包管理器  
  `Install-Package Install-Package Qc.WechatMiniProgramSdk`

#### 二.添加配置

> 如需实现自定义存储 AccessToken，动态获取应用配置，可自行实现接口 `IWechatMiniProgramSdkHook`  
> 默认提供 `DefaultWechatMiniProgramSdkHook`，存储 AccessToken 等信息到指定目录(默认./AppData)

```cs
using WechatMiniProgramSdk;
public void ConfigureServices(IServiceCollection services)
{
  //...
  services.AddWechatMiniProgramSdk<WechatMiniProgramSdk.DefaultWechatMiniProgramSdkHook>(opt =>
  {
      opt.AppId = "Api Key";
      opt.AppSecret = "Secret Key";
  });
  //...
}
```

#### 三.代码中使用

在需要地方注入`WechatMiniProgramService`后即可使用

### WechatMiniProgramConfig 配置项

WechatMiniProgram文档地址: 

## 示例说明

`Qc.WechatMiniProgramSdk.Sample` 为示例项目，可进行测试
