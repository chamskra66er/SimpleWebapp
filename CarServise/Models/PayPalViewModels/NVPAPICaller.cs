using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace CarServise.Models.PayPalViewModels
{
    public class NVPAPICaller
    {
        private const bool bSandbox = true;
        private const string CVV2 = "CVV2";

        private string pEndPointURL = "https://api-3t.paypal.com/nvp";
        private string host = "www.paypal.com";

        private string pEndPointURL_SB = "https://api-3t.sandbox.paypal.com/nvp";
        private string host_SB = "www.sandbox.paypal.com";

        private const string SIGNATURE = "SIGNATURE";
        private const string PWD = "PWD";
        private const string ACCT = "ACCT";

        public string APIUsername = "sb-sohwo937501_api1.business.example.com";
        private string APIPassword = "7U6VPX6L9785BJQH";
        private string APISignature = "AYYPyIXVYHzARvL04gfl6O8F3VR2AU105X.XDLzZeQqHGLgLqj7MrDoo";
        private string Subject = "";
        private string BNCode = "PP-ECWizard";

        private const int Timeout = 15000;
        private static readonly string[] SECURED_NVPS = new string[] { ACCT, CVV2, SIGNATURE, PWD };

        public void SetCredentials(string Userid, string Pwd, string Signature)
        {
            APIUsername = Userid;
            APIPassword = Pwd;
            APISignature = Signature;
        }
        public bool ShortcutExpressCheckout(string amt, ref string token, ref string retMsg)
        {
            if (bSandbox)
            {
                pEndPointURL = pEndPointURL_SB;
                host = host_SB;
            }

            string returnURL = "http://localhost:44368/Checkout/CheckoutReview.aspx";
            string cancelURL = "http://localhost:44368/Checkout/CheckoutReview.aspx";

            NVPCodec encoder = new NVPCodec();
            encoder["METHOD"] = "SetExpressCheckout";
            encoder["RETURNURL"] = returnURL;
            encoder["CANCELURL"] = cancelURL;
            encoder["BRANDNAME"] = "Wingtip Toys Sample Application";
            encoder["PAYMENTREQUEST 0 AMT"] = amt;
            encoder["PAYMENTREQUEST_0_ITEMAMT"] = amt;
            encoder["PAYMENTREQUEST_0_PAYMENTACTION"] = "Sale";
            encoder["PAYMENTREQUEST 0 CURRENCYCODE"] = "USD";

            //using (WingtipToys.Logic.ShopingCartActions myCartOrders = new WingtipToys.Logic.ShoppingCartAction())
            //{ 
            //    List<CartItem>
            //}

                return false;
        }
    }
    public sealed class NVPCodec : NameValueCollection
    {
        private const string AMPERSAND = "&";
        private const string EQUALS = "=";
        private static readonly char[] AMPERSAND_CHAR_ARRAY = AMPERSAND.ToCharArray();
        private static readonly char[] EQUALS_CHAR_ARRAY = EQUALS.ToCharArray();
        public string Encode()
        {
            StringBuilder sb = new StringBuilder();
            bool firstPair = true;
            foreach (string kv in AllKeys)
            {
                string name = HttpUtility.UrlEncode(kv);
                string value = HttpUtility.UrlEncode(this[kv]);
                if (!firstPair)
                {
                    sb.Append(AMPERSAND);
                }
                sb.Append(name).Append(EQUALS).Append(value);
                firstPair = false;
            }
            return sb.ToString();
        }

    }
}
