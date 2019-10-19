using System;
using System.IO;

namespace WordGuess
{
    class Program
    {
        static void Main(string[] args)
        {
            string fileName = "../../../myFile.txt";
            //WriteEntireFile(fileName);
            //ReadArrayOfLines(fileName);
            //ReadAllLines(fileName);
            //AppendValuesInFile(fileName);
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
                            Console.WriteLine(" Welcome to the game.");
                            break;
                        case 2:
                            Console.WriteLine(" Welcome to the Admin section.");
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

                }
                catch (Exception e)
                {

                    Console.WriteLine(e.Message);
                }

            }

        }

        public static void Admin()
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
                            break;
                        case 2:
                            Console.WriteLine("Enter a word to add.");
                            break;
                        case 3:
                            Console.WriteLine("Enter a word to remove.");
                            break;
                        case 5:
                            Console.WriteLine("Exit");
                            pickAgain = false;
                            break;
                        default:
                            Console.ReadKey();
                            Environment.Exit(0);
                            break;
                    }

                }
                catch (Exception e)
                {

                    Console.WriteLine(e.Message);
                }

            }
        }
        public static string MakeEntireFile(string path)
        {
            using (StreamWriter makeWords = new StreamWriter(path))
            {
                makeWords.WriteLine("kobe");
                makeWords.WriteLine("lakers");
                makeWords.WriteLine("dunk");
                makeWords.WriteLine("basketball");
                makeWords.WriteLine("fisher");
                makeWords.WriteLine("championship");

            }
        }
        public static string WriteEntireFile(string path)
        {
            using (StreamWriter makeWords = File.AppendText(path))
            {
                makeWords.WriteLine("added word");
                return path;
            }
        }

        public static void Delete(string path)
        {
            try
            {
                File.Delete(path);
            }
            catch (Exception)
            {

                throw;
            }
        }

        static void ReadAllLines(string path)
        {
            try
            {
                string allLines = File.ReadAllText(path);
                for (int i = 0; i < allLines.Length; i++)
                {
                    Console.WriteLine(allLines[i]);
                }

            }
            catch (Exception)
            {

                throw;
            }
        }



        //static void ReadArrayOfLines(string path)
        //{
        //    string[] lines = File.ReadAllLines(path);
        //    foreach (string line in lines)
        //    {
        //        Console.WriteLine(line);
        //    }
        //}

        static void AppendValuesInFile(string path)
        {
            string[] newLines = { "", "KyungRae", "likes", "gogurt" };
            File.AppendAllLines(path, newLines);

            File.AppendAllText(path, "Also, he likes sweet potatoes");
        }
    }
}
