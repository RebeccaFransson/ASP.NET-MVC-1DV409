using NumberGuessingGame.Models;
using NumberGuessingGame.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace NumberGuessingGame.Controllers
{
    public class HomeController : Controller
    {
        public SecretNumber SecretNumberObj{
            get { return Session["SecretnumberObj"] as SecretNumber ?? ((SecretNumber)(Session["SecretnumberObj"] = new SecretNumber())); }
        }

        public ActionResult Index()
        {
            return View(new SecretNumberViewModell { Secretnumberobj = SecretNumberObj });
        }

        [HttpPost]
        public ActionResult Index([Bind(Include = "GuessedNumber")] SecretNumberViewModell modelView)
        {
            if (Session.IsNewSession)
            {
                return View("Timeout");
            }

            modelView.Secretnumberobj = SecretNumberObj;

            if (ModelState.IsValid)
            {
                modelView.Outcome = SecretNumberObj.MakeGuess(modelView.GuessedNumber.Value);
            }

            return View(modelView);
        }

        public ActionResult onesMore()
        {
            SecretNumberObj.Initialize();
            return RedirectToAction("Index");
        }
    }
}