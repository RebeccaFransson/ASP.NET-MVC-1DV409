﻿using System;
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
        private Outcome privateOutcome = Outcome.Indefinite;

        public bool CanMakeGuess//readonly
        {
            get
            {
                if (Count >= MaxNumberOfGuesses || RightGuess)
                {
                    return false;
                }
                return true;
            }
            
        }
        public bool RightGuess//readonly
        {
            get
            {
                if (_lastGuessedNumber.Number == _number)
                {
                    return true;
                }
                return false;
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
        public bool lastTry//readonly
        {
            get
            {
                if (Count == MaxNumberOfGuesses)
                {
                    return true;
                }
                return false;
            }
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
            if (!CanMakeGuess)
            {
                return Outcome.NoMoreGuesses;
            }
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
            if (guess > _number){
                privateOutcome = Outcome.High;
            }else if (guess < _number){
                privateOutcome = Outcome.Low;
            }
            else if (guess == _number){
                privateOutcome = Outcome.Right;
            }
            _lastGuessedNumber = new GuessedNumber
            {
                Number = guess,
                Outcome = privateOutcome
            };
            _guessedNumbers.Add(_lastGuessedNumber);
            if (lastTry)
            {
                return Outcome.LastTry;
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