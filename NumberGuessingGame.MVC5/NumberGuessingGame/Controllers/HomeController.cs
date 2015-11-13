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

            modelView._outcome = secretNumberObj.MakeGuess(modelView._guessedNumber);
            
            modelView._guessesLeft = secretNumberObj.GuessesLeft;
            modelView._theNumber = secretNumberObj.Number;
            modelView._beforeGuesses = secretNumberObj.GuessedNumbers;
            modelView._canMakeGuess = secretNumberObj.CanMakeGuess;

            secretNumberObj.saveNewGuess(modelView._guessedNumber);
            modelView._lastGuessedNumber = secretNumberObj.LastGuessedNumber.Number;

            if (ModelState.IsValid)
            {
                return View(modelView);
            }
            
            return View();
        }
    }
}