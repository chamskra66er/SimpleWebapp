using PayPal.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarServise.Models.PaypalViewModel
{
    public class PaypalConfiguration
    {
        public readonly static string clientId;
        public readonly static string clientSecret;

        static PaypalConfiguration()
        {
            var config = getconfig();
            clientId = "AV2Vl-qjreusTl6hPhhXPFJgIdHC9A67OI3mwaRmXFdNyrLERKlZHx2EERbNvXQgNF_-99VNEY_2uSJI";
            clientSecret = "EMu90bEssZkrm1xQYVTlUAU27v2d1LHXmLzjmqxH9b2RvOZZnoxy9mcelPhuX-4J_h6WvvN2QJK_w8nk";
        }

        private static Dictionary<string,string> getconfig()
        {
            return PayPal.Api.ConfigManager.Instance.GetProperties();
        }
        private static string GetAccessToken()
        {
            string accessToken = 
                new OAuthTokenCredential(clientId, clientSecret, getconfig()).GetAccessToken();
        }
    }
}
