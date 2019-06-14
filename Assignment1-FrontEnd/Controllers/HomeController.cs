using Assignment1_FrontEnd.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace Assignment1_FrontEnd.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [HttpGet]
        public ActionResult CreatePayment()
        {
            var url = $"http://localhost:55383/api/payment/get-brands";
            var httpClient = new HttpClient();

            var response = httpClient.GetAsync(url).Result;

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                //var data = response.Content.ReadAsStringAsync().Result;
                //var brands = JsonConvert.DeserializeObject<List<CreditCardBrand>>(data);

                //var viewModel = brands.Select(p => new CreatePaymentViewModel()
                //{
                //    BrandCode = p.Code
                //}).ToList();

                return View();

            }
            return View();
        }

        [HttpPost]
        public ActionResult CreatePayment(CreatePaymentViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError(nameof(model), "Invalid Form Data");
                return View(model);
            }

            var url = $"http://localhost:55383/api/payment/create";
            var httpClient = new HttpClient();

            var parameters = new List<KeyValuePair<string, string>>();
            parameters.Add(new KeyValuePair<string, string>("BrandCode", model.BrandCode));
            parameters.Add(new KeyValuePair<string, string>("Amount", model.Amount.ToString()));
            parameters.Add(new KeyValuePair<string, string>("FirstName", model.FirstName.ToString()));
            parameters.Add(new KeyValuePair<string, string>("LastName", model.LastName.ToString()));
            parameters.Add(new KeyValuePair<string, string>("SecurityCode", model.SecurityCode.ToString()));
            parameters.Add(new KeyValuePair<string, string>("CreditCardNumber", model.CreditCardNumber.ToString()));

            var encodedParameters = new FormUrlEncodedContent(parameters);

            var response = httpClient.PostAsync(url, encodedParameters).Result;

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var data = response.Content.ReadAsStringAsync().Result;
                var result = JsonConvert.DeserializeObject<Payment>(data);

                var viewModel = new PaymentResult()
                {
                    PaymentReferenceNumber = result.PaymentReferenceNumber
                };

                return View(viewModel);
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
            {
                var data = response.Content.ReadAsStringAsync().Result;
                var result = JsonConvert.DeserializeObject<ErrorViewModel>(data);

                foreach (var key in result.ModelState)
                {
                    foreach (var error in key.Value)
                    {
                        ModelState.AddModelError(key.Key, error);
                    }
                }

                return View(model);
            }
            else
            {
                ModelState.AddModelError("", "Sorry. An unexpected error has occured. Please try again later");
                return View(model);
            }
        }
    }
}