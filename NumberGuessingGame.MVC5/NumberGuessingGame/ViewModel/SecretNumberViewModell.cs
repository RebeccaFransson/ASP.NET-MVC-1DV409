using NumberGuessingGame.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
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
                        return String.Format("{0} är för lågt", _lastGuessedNumber);
                    case Outcome.High:
                        return String.Format("{0} är för högt", _lastGuessedNumber);
                    case Outcome.Right:
                        return String.Format("{0} är rätt gissat!", _lastGuessedNumber);
                    case Outcome.OldGuess:
                        return String.Format("Du har redan gissat på {0}!", _lastGuessedNumber);
                    case Outcome.NoMoreGuesses:
                        if (_lastGuessedNumber < _theNumber)
                        {
                            return String.Format("{0} är för lågt. Inga fler gissningar! Det hemliga talet var {1}", _lastGuessedNumber, _theNumber);
                        }
                        else
                        {
                            return String.Format("{0} är för högt. Inga fler gissningar! Det hemliga talet var {1}", _lastGuessedNumber, _theNumber);
                        }
                    default:
                        return "default";
                }
            }
        }
        

        //private int? _secretNumber;
        [DisplayName("Gissa på ett tal mellan 1 och 100")]
        [Required(ErrorMessage = "Ett tal måste anges")]
        [Range(1, 100, ErrorMessage = "Ange ett tal mellan 1 och 100!")]
        public int _guessedNumber { get; set; }

        //public IList<GuessedNumber> _beforeGuesses { get; set; }
        //public string beforeGuessesView
        //{
        //    get
        //    {
        //        string allGuesses = "";
        //        foreach (var guess in _beforeGuesses)
        //        {
        //            allGuesses += "Number: " + guess.Number+" --> Outcome: "+guess.Outcome;
        //        }
        //        return allGuesses;
        //    }
        //}

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
                    return String.Format("{0} gissingar kvar!", _guessesLeft);
                }
            }
        }
    }
}
