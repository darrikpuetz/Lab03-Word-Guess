﻿using System;
using System.IO;
using System.Linq;

namespace WordGuess
{
    public class Program
    {
        /// <summary>
        /// Defining the text path.
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            string filepath = "../../../myFile.txt";
            StartAGame(filepath);

        }
        /// <summary>
        /// Starting the game displaying the options to call other mehtods.
        /// </summary>
        /// <param name="path"></param>
        public static bool StartAGame(string path)
        {
            bool pickAgain = true;
            while (pickAgain)
            {
                Console.WriteLine("Shaquille Oatmeal's Word Guess Game");
                Console.WriteLine("        %%%%&");
                Console.WriteLine("       .#/(/#&");
                Console.WriteLine("       #(((%#& ");
                Console.WriteLine("        %#/#%&");
                Console.WriteLine("        %&&&&%&*");
                Console.WriteLine("    ,.(%#####% ..&&&");
                Console.WriteLine("  #%    *####. .*. ###");
                Console.WriteLine(",..                ,,");
                Console.WriteLine("-------------------------------");

                Console.WriteLine("1) Play Game");
                Console.WriteLine("2) Admin");
                Console.WriteLine("3) Exit");

                Int32.TryParse(Console.ReadLine(), out int option);
                try
                {
                    switch (option)
                    {
                        case 1:
                            Console.Clear();
                            Console.WriteLine(" Welcome to the game.");
                            GetAWord(path);
                            pickAgain = false;
                            break;
                        case 2:
                            Console.WriteLine(" Welcome to the Admin section.");
                            Console.Clear();
                            Admin(path);
                            break;
                        case 3:
                            Console.WriteLine("Exit");
                            Environment.Exit(0);
                            pickAgain = false;
                            break;
                        default:
                            Console.ReadKey();
                            break;
                    }
                    return true;

                }
                catch (Exception e)
                {

                    Console.WriteLine(e.Message);
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Section of choices that allow the user to change/view words.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static bool Admin(string path)
        {
            bool pickAgain = true;
            while (pickAgain)
            {
                Console.WriteLine("Admin Menu");
                Console.WriteLine("1) Active Words");
                Console.WriteLine("2) Add Word");
                Console.WriteLine("3) Remove Word");
                Console.WriteLine("5) Exit Admin Menu");
                Int32.TryParse(Console.ReadLine(), out int option);
                try
                {
                    switch (option)
                    {
                        case 1:
                            Console.WriteLine("These are the words available.");
                            foreach (string word in ReadAllWords(path))
                            {
                                Console.WriteLine(word);
                            }
                            StartAGame(path);
                            break;
                        case 2:
                            Console.WriteLine("Enter a word to add.");
                            string addWord = Console.ReadLine();
                            Add(path, addWord);
                            StartAGame(path);
                            break;
                        case 3:
                            foreach (string word in ReadAllWords(path))
                            {
                                Console.WriteLine(word);
                            }
                            Console.WriteLine("Enter a word to remove.");
                            string removeWord = Console.ReadLine();
                            Remove(removeWord, path);
                            Console.WriteLine($"{removeWord} was removed. ");
                            StartAGame(path);

                            break;
                        case 5:
                            Console.WriteLine("Exit");
                            Console.Clear();
                            break;
                        default:
                            Console.Clear();
                            Environment.Exit(0);
                            break;

                    }
                    return true;

                }
                catch (IOException e)
                {
                    Console.WriteLine(e.Message);
                    return false;
                }
            }
            return true;
        }
        /// <summary>
        /// Writing to the console the words that have been added.
        /// </summary>
        /// <param name="path"></param>
        /// <param name="newWords"></param>
        public static void WriteEntireFile(string path, string[] newWords)
        {
            using (StreamWriter makeWords = new StreamWriter(path))
            {
                try
                {
                    foreach (string word in newWords)
                    {
                        makeWords.WriteLine(word);
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }
        /// <summary>
        /// Adding a word to the array of words found in the Admin section.
        /// </summary>
        /// <param name="path"></param>
        /// <param name="addedWord"></param>
        /// <returns></returns>
        public static string Add(string path, string addedWord)
        {
            using (StreamWriter writing = File.AppendText(path))
            {
                writing.WriteLine(addedWord);
            }
            return addedWord;
        }

        public static void ReadTheFile(string path)
        {
            try
            {
                string[] allLines = File.ReadAllLines(path);
                for (int i = 0; i < allLines.Length; i++)
                {
                    Console.WriteLine(allLines[i]);
                }
                foreach (string line in allLines)
                {
                    Console.WriteLine(line);
                }

            }
            catch (Exception)
            {

                throw;
            }
        }
        /// <summary>
        /// Randomly generating an array of letters based on the word that chosen.
        /// </summary>
        /// <param name="path"></param>
        public static void GetAWord(string path)
        {
            try
            {
                Random randomword = new Random();
                string[] allTheWords = ReadAllWords(path);
                int randomWordPicked = randomword.Next(allTheWords.Length);
                string wordPicked = allTheWords[randomWordPicked];
                string[] underScores = new string[wordPicked.Length];
                bool finished = false;
                string alreadyGuessed = "";

                for (int i = 0; i < underScores.Length; i++)
                {
                    underScores[i] = " _ ";
                    Console.WriteLine(underScores[i]);
                }
                while (!finished)
                {
                    Console.WriteLine("Try guessing a letter.");
                    string gameInput = Console.ReadLine();
                    alreadyGuessed += gameInput;
                    for (int i = 0; i < underScores.Length; i++)
                    {
                        bool compareValue = string.Equals(underScores[i], gameInput, StringComparison.CurrentCultureIgnoreCase);
                        if (compareValue)
                        {
                            underScores[i] = gameInput;
                        }
                    }
                    if (wordPicked.Contains(gameInput))
                    {
                        for (int i = 0; i < wordPicked.Length; i++)
                        {
                            if (wordPicked[i].ToString() == gameInput)
                            {
                                underScores[i] = gameInput;
                            }
                        }
                    }
                    Console.WriteLine($"You guessed: {alreadyGuessed}");
                    foreach (string letter in underScores)
                    {
                        Console.WriteLine(letter);
                    }
                    if (!underScores.Contains(" _ "))
                    {
                        Console.WriteLine("Congrats you animal!");
                        finished = true;
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }

        }
        /// <summary>
        /// Reading the words that were made within the text file.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>

        public static string[] ReadAllWords(string path)
        {
            string[] allWords = File.ReadAllLines(path);
            return allWords;
        }

        public static string Remove(string word, string path)
        {
            Console.Clear();
            try
            {
                string[] wordArr = File.ReadAllLines(path);
                string[] newArr = new string[wordArr.Length];
                bool deletedTheWord = false;
                using (StreamWriter writer = File.CreateText(path))
                {
                    int count = 0;
                    for (int i = 0; i < wordArr.Length; i++)
                    {
                        if (word == wordArr[i])
                        {
                            deletedTheWord = true;
                        }
                        else
                        {
                            newArr[count] = wordArr[i];
                            count++;
                        }
                    }
                    if (deletedTheWord)
                    {
                        for (int i = 0; i < newArr.Length; i++)
                        {
                            writer.WriteLine(newArr[i]);
                        }
                    }
                    return word;
                }
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
                string nope = "Didn't Work";
                return nope;
            }
        }
        public static string ShowWords(string path)
        {
            string file = File.ReadAllText(path);
                return file;
        }
        public static bool LetterGuess(char letter, string word)
        {
            if(word.Contains(letter))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }

}
