using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using static System.Console;

namespace Hangman
{
    public static class Hangman
    {
        private static readonly string[] HangmanArt = {@"
    
        
        
        
        
        
 =========", @"
        |
        |
        |
        |
        |
        |
 =========", @"
    +---+
        |
        |
        |
        |
        |
 =========", @"
    +---+
    |   |
        |
        |
        |
        |
 =========", @"
    +---+
    |   |
    O   |
        |
        |
        |
 =========", @"
    +---+
    |   |
    O   |
    |   |
        |
        |
 =========", @"
    +---+
    |   |
    O   |
   /|   |
        |
        |
 =========", @"
    +---+
    |   |
    O   |
   /|\  |
        |
        |
 =========", @"
    +---+
    |   |
    O   |
   /|\  |
   /    |
        |
 =========", @"
    +---+
    |   |
    O   |
   /|\  |
   / \  |
        |
 ========="};
        private static string[] GrabWords()
        {
            string directory = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            if (directory != null)
            {
                string path = Path.Combine(directory, "words.txt");
                if (File.Exists(path)) return File.ReadAllLines("words.txt");
            }
            WriteLine("Error, couldn't find the words.txt file?");
            Environment.Exit(0);
            return File.ReadAllLines("words.txt");
        }
        
        public static string SelectWord(IReadOnlyList<string> words)
        {
            return words[new Random().Next(words.Count)];
        }
        
        public static bool Guess(string guess, string word)
        {
            return word.Contains(guess);
        }
        
        public static string DrawWord(string guess, string word)
        {
            char[] cArray = word.ToCharArray();
            string spacedWord = string.Join(" ", cArray);
            string result = Regex.Replace(spacedWord, @"[^ " + guess + "]", "_");
            return result;
        }
        
        public static string Art(int amount)
        {
            return HangmanArt[amount];
        }

        public static string Status(int amount, string word, string correctChars, string incorrectChars)
        {
            string result = $"Amount of guesses left: {10 - amount}\n" +
                            $"Word: {DrawWord(correctChars, word)}\nMiss: {incorrectChars}";
            return result;
        }

        private static void Main()
        {
            WriteLine("Welcome to Hangman, we've selected a word and it's your turn to guess it.");
            string[] words = GrabWords();
            string word = SelectWord(words);
            int amount = 0;
            StringBuilder correctChars =  new ("");
            StringBuilder incorrectChars = new ("");
            StringBuilder totalChars  = new ("");
            WriteLine("CHEATING, WORD IS: " + word);
            while (amount < 10)
            {
                string guess = ReadLine();
                // I don't really see the need for a char array?
                char[] wordChar = word.ToCharArray();
                bool guessChar = Guess(guess, word);
                Clear();
                switch (guessChar)
                {
                    case true when guess!.Length == 1 && !totalChars.ToString().Contains(guess):
                        correctChars.Append(guess);
                        break;
                    case false when guess!.Length == 1 && !totalChars.ToString().Contains(guess):
                        incorrectChars.Append(guess);
                        break;
                }
                if (guess.Length >= 1 && !totalChars.ToString().Contains(guess))
                {
                    amount += 1;
                }
                totalChars.Append(guess);
                WriteLine(Art(amount));
                WriteLine(Status(amount, word, correctChars.ToString(), incorrectChars.ToString()));
                if (!guess.Equals(word)) continue;
                WriteLine($"You won, the word was: {word}.");
                Environment.Exit(0);
            }
            WriteLine("You lost!");
            Environment.Exit(0);
        }
    }
}