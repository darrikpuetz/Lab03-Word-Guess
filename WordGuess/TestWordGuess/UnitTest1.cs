using System;
using Xunit;
using static WordGuess.Program;



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
            string[] path =  new string [3] { "yeet", "hello", "why" };
            Assert.Equal(path, ReadAllWords(path[3]));

        }
        [Fact]
        public void StartAGameTest()
        {
            string path = "myFile.txt";
            string wrongpath = "../../../myFile.txt";

            Assert.NotEqual(wrongpath, StartAGame(path));

        }


    }
}
