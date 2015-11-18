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
        private SecretNumber _secretNumber;
        public SecretNumber secretNumberObj{
            get { return _secretNumber ?? (_secretNumber = new SecretNumber()); }
            set { _secretNumber = value;  }
        }

        public ActionResult Index()
        {
            Session.Timeout = 1;
            if (Session["SecretnumberObj"] == null)//if session empty, create it
            {
                Session["SecretnumberObj"] = secretNumberObj;
            }
            return View();
        }

        [HttpPost]
        public ActionResult Index([Bind(Include = "_guessedNumber")] SecretNumberViewModell modelView)
        {
            if (Session["SecretnumberObj"] != null)
            {
                secretNumberObj = (SecretNumber)Session["SecretnumberObj"];
            }
            else
            {
                return View("Timeout");
            }
            if (ModelState.IsValid)
            {
                var outcome = secretNumberObj.MakeGuess(modelView._guessedNumber);
                modelView.secretnumberobj = secretNumberObj;
                modelView._guessesLeft = secretNumberObj.GuessesLeft;
                
                return View(modelView);
            }
            return View("Index");
        }
    }
}