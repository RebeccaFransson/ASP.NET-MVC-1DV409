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
        public SecretNumber secretnumberobj { get; set; }

        public int? _theNumber {
            get
            {
                return secretnumberobj.Number;
            }
        }

        public int? _lastGuessedNumber {
            get
            {
                return secretnumberobj.LastGuessedNumber.Number;
            }
        }

        [DisplayName("Gissa på ett tal mellan 1 och 100")]
        [Required(ErrorMessage = "Ett tal måste anges")]
        [Range(1, 100, ErrorMessage = "Ange ett tal mellan 1 och 100!")]
        public int _guessedNumber { get; set; }

        public string _outcomeView
        {
            get {
                //switch (secretnumberobj.MakeGuess(_guessedNumber))
                //{
                    
                //}
                switch (secretnumberobj.LastGuessedNumber.Outcome)
                {
                    case Outcome.NoMoreGuesses:
                        if (_lastGuessedNumber < secretnumberobj.Number)
                        {
                            return String.Format("{0} är för lågt. Inga fler gissningar! Det hemliga talet var {1}", _lastGuessedNumber, secretnumberobj.Number);
                        }
                        else
                        {
                            return String.Format("{0} är för högt. Inga fler gissningar! Det hemliga talet var {1}", _lastGuessedNumber, secretnumberobj.Number);
                        }
                    case Outcome.Indefinite:
                        return "Ett fel uppstod";
                    case Outcome.Low:
                        return String.Format("{0} är för lågt", _lastGuessedNumber);
                    case Outcome.High:
                        return String.Format("{0} är för högt", _lastGuessedNumber);
                    case Outcome.Right:
                        return String.Format("{0} är rätt gissat!", _lastGuessedNumber);
                    case Outcome.OldGuess:
                        return String.Format("Du har redan gissat på {0}!", _lastGuessedNumber);
                    default:
                        return "Fel uppstod";
                }

            }
        }
        

        public IList<GuessedNumber> _beforeGuesses {
            get
            {
                return secretnumberobj.GuessedNumbers;
            }
                }

        public int _guessesLeft { get; set; }
        public string _guessesLeftView
        {
            get
            {
                if (!secretnumberobj.CanMakeGuess)
                {
                    if (secretnumberobj.Number == _lastGuessedNumber)
                    {
                        return "Rätt gissat!";
                    }
                    return "Inga fler gissingar!";
                }
                else
                {
                    return String.Format("{0} gissingar kvar!", _guessesLeft);
                }
            }
        }
    }
}
