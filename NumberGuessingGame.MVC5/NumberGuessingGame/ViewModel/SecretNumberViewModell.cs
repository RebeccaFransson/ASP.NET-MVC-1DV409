using NumberGuessingGame.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace NumberGuessingGame.ViewModel
{
    public class SecretNumberViewModell
    {
        public int? _theNumber { get; set; }

        public int? _lastGuessedNumber { get; set; }

        public Outcome _outcome { get; set; }
        public string _outcomeView
        {
            get {
                switch (_outcome)
                {
                    case Outcome.Indefinite:
                        return "standard";
                    case Outcome.Low:
                        return _lastGuessedNumber + " är för lågt";
                    case Outcome.High:
                        return _lastGuessedNumber + " är för högt";
                    case Outcome.Right:
                        return _lastGuessedNumber + " är rätt gissat!";
                    case Outcome.OldGuess:
                        return "Du har redan gissat på " + _lastGuessedNumber + "!";
                    case Outcome.NoMoreGuesses:
                        if (_lastGuessedNumber < _theNumber)
                        {
                            return _lastGuessedNumber+" är för lågt. Inga fler gissningar! Det hemliga talet var " + _theNumber;
                        }
                        else
                        {
                            return _lastGuessedNumber + " är för högt. Inga fler gissningar! Det hemliga talet var " + _theNumber;
                        }
                    default:
                        return "default";
                }
            }
        }
        

        //private int? _secretNumber;
        [DisplayName("Gissa på ett tal mellan 1 och 100")]
        public int _guessedNumber { get; set; }

        public IList<GuessedNumber> _beforeGuesses { get; set; }
        public string beforeGuessesView
        {
            get
            {
                string allGuesses = "";
                foreach (var guess in _beforeGuesses)
                {
                    allGuesses += "<br>Number: "+guess.Number+" --> Outcome: "+guess.Outcome;
                }
                return allGuesses;
            }
        }

        public bool _canMakeGuess { get; set; }

        public int _guessesLeft { get; set; }
        public string _guessesLeftView
        {
            get
            {
                if (_guessesLeft == 0)
                {
                    return "Inga fler gissingar!";
                }
                if (_theNumber == _lastGuessedNumber)
                {
                    return "Rätt gissat!";
                    //sätt så vi kan spela igen?
                }
                else
                {
                    return _guessesLeft + " gissingar kvar!";
                }
            }
        }
    }
}
