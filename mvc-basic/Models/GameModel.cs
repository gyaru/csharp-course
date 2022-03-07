using System;

namespace mvc_basic.Models
{
    public class GameModel
    {
        public static int RandomNumber()
        {
            Random rand = new();
            int randomNumber = rand.Next(1, 100);
            return randomNumber;
        }

        public static bool CompareGuess(int guess, int? random)
        {
            return guess == random;
        }
    }
}