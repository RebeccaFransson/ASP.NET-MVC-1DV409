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
        public const int MaxNumberOfGuesses = 7;

        public bool CanMakeGuess//TODO: Om användaren gissat rätt
        {
            get
            {
                if (_guessedNumbers.Count > MaxNumberOfGuesses)
                {
                    return true;
                }
                return false;
            }
            
        }
        public int Count
        {
            get { return _guessedNumbers.Count; }
        }
        public IList<GuessedNumber> GuessedNumbers//TODO: Readonly! Kanske skapa ny referens i egenskapen?
        {
            get { return _guessedNumbers; }
        }
        public GuessedNumber LastGuessedNumber
        {
            get { return _lastGuessedNumber; }
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
            foreach (var old in _guessedNumbers)
            {
                if(old.Equals(guess)){
                    return Outcome.OldGuess;
                }
            }
            if (!CanMakeGuess)
            {
                return Outcome.NoMoreGuesses;
            }
            if (guess > Number)
            {
                return Outcome.High;
            }
            if (guess < Number)
            {
                return Outcome.Low;
            }
            if (guess == Number)
            {
                return Outcome.Right;
            }

            return Outcome.Indefinite;
        }
        public SecretNumber()//TODO: initiera listobjectet
        {
            Initialize();
            List<GuessedNumber> list = new List<GuessedNumber>();
        }

        
    }
}