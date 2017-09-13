using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace EngineCommon
{
    public class ReCaptchaClass
    {
        //public static string PrivateKey = "";
        public static string Validate(string EncodedResponse, string PrivateKey)
        {
            var client = new System.Net.WebClient();

            //string PrivateKey = "6LcH-v8SerfgAPlLLffghrITSL9xM7XLrz8aeory";

            var GoogleReply = client.DownloadString(string.Format("https://www.google.com/recaptcha/api/siteverify?secret={0}&response={1}", PrivateKey, EncodedResponse));

            //  var captchaResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<ReCaptchaClass>(GoogleReply);
            JavaScriptSerializer js = new JavaScriptSerializer();
            MyObject data = js.Deserialize<MyObject>(GoogleReply);
            var captchaResponse = data.success;
            return captchaResponse.ToString();
        }
        public class MyObject
        {
            public string success { get; set; }

        }
    }
}
