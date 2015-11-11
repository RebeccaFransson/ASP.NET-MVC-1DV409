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
            /*else
            {
                _secretNumber = new SecretNumber();
            }*/
            

            modelView._outcome = secretNumberObj.MakeGuess(modelView._guessedNumber);
            if (ModelState.IsValid)
            {
                return View(modelView);
            }
            
            return View();
        }
    }
}