using NumberGuessingGame.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NumberGuessingGame.ViewModel
{
    public class SecretNumberViewModell
    {
        private int? _number;
        SecretNumberViewModell(SecretNumber secretNumber)//Kanske ska få en GuessesNumber
        {
            _number = secretNumber.Number;
        }
    }
}