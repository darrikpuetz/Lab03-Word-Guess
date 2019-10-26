using System;
using System.Collections.Generic;
using Xunit;
using static WordGuess.Program;
using System.IO;



namespace TestWordGuess
{
    public class UnitTest1
    {
        [Fact]
        public void Addtest()
        {
            string whoop = "whoop";
            string path = "../../../myFile.txt";
            Assert.Equal(whoop, Add(path, whoop));

        }
        [Fact]
        public void ReadAllWordsTest()
        {
            string path = "../../../myFile.txt";
            Assert.Equal(File.ReadAllText(path), ShowWords(path));

        }


        [Fact]
        public void DoesLetterExist()
        {
            string word = "yeet";
            char letter = 'e';
            Assert.True(LetterGuess(letter, word));

        }
        [Fact]
        public void DoesLetterNotExist()
        {
            string word = "yeet";
            char letter = 'o';
            Assert.False(LetterGuess(letter, word));

        }

    }
}
