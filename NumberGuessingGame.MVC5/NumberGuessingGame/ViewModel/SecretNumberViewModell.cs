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
        
        [DisplayName("Gissa på ett tal mellan 1 och 100")]
        [Required(ErrorMessage = "Ett tal måste anges")]
        [Range(1, 100, ErrorMessage = "Ange ett tal mellan 1 och 100!")]
        public int _guessedNumber { get; set; }
        public int? _lastGuessedNumber {get { return secretnumberobj.LastGuessedNumber.Number; } }
        public Outcome outcome { get; set; }
        public string _outcomeView
        {
            get {
                switch (outcome)
                {
                    case Outcome.NoMoreGuesses:
                        return "Inga fler gissingar, starta gärna ett nytt spel!";
                    case Outcome.LastTry:
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

        public string doneOnSoManyGuesses {
            get
            {
                if (secretnumberobj.RightGuess)
                {
                    switch (secretnumberobj.Count)
                    {
                        case 1:
                            return "Du klarade det på första försöket!";
                        case 2:
                            return "Du klarade det på andra försöket!";
                        case 3:
                            return "Du klarade det på tredje försöket!";
                        case 4:
                            return "Du klarade det på fjärde försöket!";
                        case 5:
                            return "Du klarade det på femte försöket!";
                        case 6:
                            return "Du klarade det på sjätte försöket!";
                        case 7:
                            return "Du klarade det på sjunde försöket!";
                        default:
                            return "Du klarade det tyvärr inte...";
                    }
                }
                return null;
            }
        }

        public string guessesLeft
        {
            get
            {
                if (secretnumberobj.RightGuess)
                {
                    return "Rätt gissat!";
                }
                switch (secretnumberobj.Count)
                {
                    case 0:
                        return "Första gissingen!";
                    case 1:
                        return "Andra gissingen!";
                    case 2:
                        return "Tredje gissingen!";
                    case 3:
                        return "Fjärde gissingen!";
                    case 4:
                        return "Femte gissingen!";
                    case 5:
                        return "Sjätte gissingen!";
                    case 6:
                        return "Sista gissingen!";
                    default:
                        return "Inga gissingar kvar!";
                }
            }
        }
    }
}
