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
        public ActionResult Index()
        {
            var secretNumber = new SecretNumber();
            var secretNumberViewModel = new SecretNumberViewModell(secretNumber);
            return View(secretNumberViewModel);
        }
    }
}