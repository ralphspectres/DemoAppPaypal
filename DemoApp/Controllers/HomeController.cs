﻿using DemoApp.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult PostToPaypal(string item, string amount)
        {
            DemoApp.Models.PaypalModel paypal = new Models.PaypalModel();
            paypal.cmd = "_xclick";
            paypal.business = ConfigurationManager.AppSettings["BusinessAccountKey"];

            bool useSandbox = Convert.ToBoolean(ConfigurationManager.AppSettings["UseSandbox"]);
            if (useSandbox)
            {
                ViewBag.actionURL = "https://www.sandbox.paypal.com/cgi-bin/webscr";
            }
            else
            {
                ViewBag.actionURL = "https://wwww.paypal.com/cgi-bin/webscr";
            }

            paypal.cancel_return = System.Configuration.ConfigurationManager.AppSettings["CancelURL"]; //+"&PaymentId = 1"; if with database
            paypal.@return = ConfigurationManager.AppSettings["ReturnURL"]; //+"?paymentId = 1"; if with database
            paypal.notify_url = ConfigurationManager.AppSettings["NotidyURL"];

            paypal.currency_code = ConfigurationManager.AppSettings["CurrencyCode"];

            paypal.item_name = item;
            paypal.amount = amount;
            return View(paypal);

        }


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
    }
}