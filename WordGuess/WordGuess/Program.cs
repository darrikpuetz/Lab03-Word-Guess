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
            //ReadAllines(fileName);
            AppendValuesInFile(fileName);
        }
        static void WriteEntireFile(string path)
        {
            File.WriteAllText(path, "Why is Chris an idiot?");
        }
        static void ReadAllLines(string path)
        {
            string allLines = File.ReadAllText(path);
            Console.WriteLine(allLines);
        }
        static void ReadArrayOfLines(string path)
        {
            string[] lines = File.ReadAllLines(path);
            foreach(string line in lines)
            {
                Console.WriteLine(line);
            }
        }

        static void AppendValuesInFile(string path)
        {
            string[] newLines = { "", "KyungRae", "likes", "gogurt" };
            File.AppendAllLines(path, newLines);

            File.AppendAllText(path, "Also, he likes sweet potatoes");
        }
    }
}
