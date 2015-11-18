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
        public const int MaxNumberOfGuesses = 2;
        private Outcome privateOutcome = Outcome.Indefinite;

        public bool CanMakeGuess//readonly
        {
            get
            {
                if (Count > MaxNumberOfGuesses || _lastGuessedNumber.Number == _number)
                {
                    return false;
                }
                return true;
            }
            
        }
        public int Count//readonly
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
                if (!CanMakeGuess)
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
            GuessedNumber newGuess;
            newGuess.Number = guess;
            newGuess.Outcome = privateOutcome;
            _lastGuessedNumber = newGuess;
            if (guess < 1 || guess > 100)
            {
                throw new ArgumentOutOfRangeException();
            }
            foreach (var old in _guessedNumbers)
            {
                if (old.Number.Equals(guess))
                {
                    return Outcome.OldGuess;
                }
            }
            if (guess > _number)
            {
                privateOutcome = Outcome.High;
            }
            if (guess < _number)
            {
                privateOutcome = Outcome.Low;
            }
            if (guess == _number)
            {
                privateOutcome = Outcome.Right;
            }

            //int index = _guessedNumbers.FindIndex(newGuess);
            newGuess.Number = guess;
            newGuess.Outcome = privateOutcome;
            _lastGuessedNumber = newGuess;

            _guessedNumbers.Add(_lastGuessedNumber); //lägg till talet i listan
            if (!CanMakeGuess)
            {
                newGuess.Outcome = privateOutcome;
                _lastGuessedNumber = newGuess;

                _guessedNumbers.Add(_lastGuessedNumber);
                return Outcome.NoMoreGuesses;
            }


            return privateOutcome;
        }
        
        public SecretNumber()
        {
            _guessedNumbers = new List<GuessedNumber>();
            Initialize();
        }

        
    }
}