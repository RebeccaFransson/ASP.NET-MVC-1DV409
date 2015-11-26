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
        public SecretNumber Secretnumberobj { get; set; }

        [DisplayName("Gissa på ett tal mellan 1 och 100")]
        [Required(ErrorMessage = "Ett tal måste anges")]
        [Range(1, 100, ErrorMessage = "Ange ett tal mellan 1 och 100!")]
        public int? GuessedNumber { get; set; }
        public int? LastGuessedNumber { get { return Secretnumberobj.LastGuessedNumber.Number; } }

        public Outcome Outcome { get; set; }
        public string OutcomeView
        {
            get
            {
                string outcome;

                switch (Outcome)
                {
                    case Outcome.NoMoreGuesses:
                        outcome = "Inga fler gissingar, starta gärna ett nytt spel!";
                        break;
                    case Outcome.Indefinite:
                        outcome = "Ett fel uppstod";
                        break;

                    case Outcome.Low:
                        outcome = String.Format("{0} är för lågt", LastGuessedNumber);
                        break;

                    case Outcome.High:
                        outcome = String.Format("{0} är för högt", LastGuessedNumber);
                        break;

                    case Outcome.Right:
                        outcome = String.Format("{0} är rätt gissat!", LastGuessedNumber);
                        break;

                    case Outcome.OldGuess:
                        outcome = String.Format("Du har redan gissat på {0}!", LastGuessedNumber);
                        break;

                    default:
                        outcome = "Fel uppstod";
                        break;
                }

                if (!Secretnumberobj.CanMakeGuess && Secretnumberobj.LastGuessedNumber.Outcome != Outcome.Right)
                {
                    outcome += String.Format(" Inga fler gissningar! Det hemliga talet var {0}", Secretnumberobj.Number);
                }

                return outcome;

            }
        }

        public string DoneOnSoManyGuesses
        {
            get
            {
                if (Secretnumberobj.RightGuess)
                {
                    switch (Secretnumberobj.Count)
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

        public string GuessesLeft
        {
            get
            {
                if (Secretnumberobj.RightGuess)
                {
                    return "Rätt gissat!";
                }
                switch (Secretnumberobj.Count)
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
