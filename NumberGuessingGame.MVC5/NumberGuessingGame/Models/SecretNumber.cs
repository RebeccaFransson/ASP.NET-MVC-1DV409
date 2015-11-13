using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NumberGuessingGame.Models
{
    public class SecretNumber
    {
        private List<GuessedNumber> _guessedNumbers;
        private GuessedNumber _lastGuessedNumber;
        private int? _number;
        public const int MaxNumberOfGuesses = 6;
        private Outcome privateOutcome = Outcome.Indefinite;

        public bool CanMakeGuess
        {
            get
            {
                if (Count >= MaxNumberOfGuesses)
                {
                    return false;
                }
                return true;
            }
            
        }
        public int Count
        {
            get { return GuessedNumbers.Count; }
        }
        public IList<GuessedNumber> GuessedNumbers
        {
            get { return _guessedNumbers.AsReadOnly(); }
        }
        public GuessedNumber LastGuessedNumber
        {
            get { return _lastGuessedNumber; }
        }
        public int GuessesLeft
        {
            get { return MaxNumberOfGuesses - Count; }
        }

        public int? Number {
            get{
                if (CanMakeGuess)
                {
                    return _number;
                }
                return null;
            }
            private set { _number = value; }
        }


        public void Initialize()//TODO: initiserar klassens fält och egenskaper - listan rensas -
        {
            Random random = new Random();
            int nr = random.Next(1, 101);
            Number = nr;

        }
        public Outcome MakeGuess(int guess)
        {
            if (!CanMakeGuess)
            {
                return Outcome.NoMoreGuesses;
            }
            foreach (var old in _guessedNumbers)
            {
                if (old.Number.Equals(guess))
                {
                    return Outcome.OldGuess;
                }
            }
            if (guess > Number)
            {
                privateOutcome = Outcome.High;
            }
            if (guess < Number)
            {
                privateOutcome = Outcome.Low;
            }
            if (guess == Number)
            {
                privateOutcome = Outcome.Right;
            }
            
            return privateOutcome;
        }
        public void saveNewGuess(int guess)
        {
            GuessedNumber newGuess;
            newGuess.Number = guess;
            newGuess.Outcome = privateOutcome;
            _lastGuessedNumber = newGuess;

            _guessedNumbers.Add(newGuess); //lägg till talet i listan
        }
        public SecretNumber()
        {
            _guessedNumbers = new List<GuessedNumber>();
            Initialize();
        }

        
    }
}