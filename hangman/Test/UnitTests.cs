using static Hangman.Hangman;
using Xunit;

namespace Tests
{
    public class UnitTests
    {
        [Fact]
        public void ArtTest()
        {
            Assert.Equal(
                @"
        |
        |
        |
        |
        |
        |
 =========", Art(1));
        }

        [Fact]
        public void GrabWordsTest()
        {
            string[] words = {"cow", "cow", "cow"};
            Assert.Equal("cow", SelectWord(words));
        }
        
        [Fact]
        public void SelectWordTest()
        {
            string[] words = {"cow", "cow", "cow"};
            Assert.Equal("cow", SelectWord(words));
        }
        
        [Fact]
        public void GuessTest()
        {
            Assert.True(Guess("cow", "cow"));
        }
        
        [Fact]
        public void DrawWordTest()
        {
            Assert.Equal("_ o _",DrawWord("o", "cow"));
        }

        [Fact]
        public void StatusTest()
        {
            Assert.Equal("Amount of guesses left: 9\n" +
                         "Word: c _ _\n" +
                         "Miss: p", Status(1, "cow", "c", "p"));
        }
    }
}