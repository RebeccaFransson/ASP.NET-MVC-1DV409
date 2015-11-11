using NumberGuessingGame.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NumberGuessingGame.ViewModel
{
    public class SecretNumberViewModell
    {
        //private int? _secretNumber;
        public int _guessedNumber { get; set; }

        //private GuessedNumber _lastGuessedNumber;
        public Outcome _outcome { get; set; }

        
    }
}