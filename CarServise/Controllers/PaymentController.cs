using CarServise.Models.PaypalViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PayPal.Api;
using Microsoft.AspNetCore.Mvc;
using System.Web;

namespace CarServise.Controllers
{
    public class PaymentController:Controller
    {
        public IActionResult PaymentWithPaypal()
        {
            var apicontext = PaypalConfiguration.GetAPIContext();
            try
            {
                string payerId = Request.Form["PayerId"];
                if (string.IsNullOrEmpty(payerId))
                {
                    //string baseURI = 
                }
            }
            catch (Exception)
            {

                throw;
            }


            return View();

        }
        private Payment CreatePayment(APIContext context, string redirectUrl, int id)
        {
            var payer = new Payer() { payment_method = "paypal"};
            var redirUrls = new RedirectUrls()
            {
                cancel_url = redirectUrl,
                return_url = redirectUrl
            };
            var details = new Details()
            {
                tax = "1",
                shipping = "2",
                subtotal = 15.ToString(), //to add cart quantity
            };
            var amount = new Amount()
            {
                currency = "USD",
                total = (Convert.ToDouble(details.tax) +
                        Convert.ToDouble(details.shipping) +
                        Convert.ToDouble(details.subtotal)).ToString(),
                details = details
            };
            var transactionList = new List<Transaction>();
            transactionList.Add(new Transaction
            {
                description = "test description",
                invoice_number = Convert.ToString((new Random()).Next(100000)),
                amount = amount
                //item_list = List<string>()
            });
            var payment = new Payment()
            { 
                intent = "sale",
                payer = payer,
                transactions = transactionList,
                redirect_urls = redirUrls
            };
            return payment.Create(context);
        }
        private Payment ExecutePayment(APIContext context, string payerId, string paymentId)
        {
            var paymentExecute = new PaymentExecution()
            { 
                payer_id = payerId
            };
            var payment = new Payment()
            { 
                id=paymentId
            };
            return payment.Execute(context, paymentExecute);
        }
    }
}
