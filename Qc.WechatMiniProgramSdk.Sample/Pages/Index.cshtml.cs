using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace Qc.WechatMiniProgramSdk.Sample.Pages
{
    public class IndexModel : PageModel
    {
        private readonly WechatMiniProgramService _service;
        public IndexModel(WechatMiniProgramService service)
        {
            _service = service;
        }

        [NonHandler]
        public static JsonResult Json(object obj)
        {
            return new JsonResult(obj, new JsonSerializerSettings() { Formatting = Formatting.Indented, NullValueHandling = NullValueHandling.Ignore });
        }

        public IActionResult OnPostAuth_Code2Session(string jsCode)
        {
            var result = _service.Auth_Code2Session(jsCode);
            return Json(result);
        }

        public IActionResult OnPostAuth_GetUserInfo(string sessionKey, string encryptedData, string iv)
        {
            var result = _service.Qc_GetUserInfo(sessionKey, encryptedData, iv);
            return Json(result);
        }

        public IActionResult OnPostAuth_GetAccessToken()
        {
            var result = _service.Auth_GetAccessToken();
            return Json(result);
        }
    }
}
