using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NRMA.BowlingScorer.Core;
namespace NRMA.BowlingScorer.Test
{
    [TestClass]
    public class TestBowlingScore
    {
        ScoreEngine engine = new ScoreEngine();
        
        [TestMethod]
        public void AllRollStrike()
        {
            var input = "10 10 10 10 10 10 10 10 10 10 10 10";
            Assert.AreEqual( engine.Score(input), 300);
        }

        [TestMethod]
        public void StrikeOnFirstRoll()
        {
            var input = "10 0 9 9 1 4 5";
            Assert.AreEqual(engine.Score(input), 51);
        }

        [TestMethod]
        public void SpareOnSecondRoll()
        {
            var input = "0 10 5 4";
            Assert.AreEqual(engine.Score(input), 24);
        }

        [TestMethod]
        public void StrikeOnLastFrameWithoutBonusRoll()
        {
            var input = "1 2 3 4 5 5 6 3 7 1 8 0 9 0 5 3 7 2 10";
            Assert.AreEqual(engine.Score(input), 77);
        }

        [TestMethod]
        public void StrikeOnLastFrameWithBonusRoll()
        {
            var input = "1 2 3 4 5 5 6 3 7 1 8 0 9 0 5 3 7 2 10 7 3";
            Assert.AreEqual(engine.Score(input), 97);
        }

        [TestMethod]
        public void SpareOnLastFrameWithoutBonusRoll()
        {
            var input = "1 2 3 4 5 5 6 3 7 1 8 0 9 0 5 3 7 2 4 6";
            Assert.AreEqual(engine.Score(input), 87);
        }

        [TestMethod]
        public void SpareOnLastFrameWithBonusRoll()
        {
            var input = "1 2 3 4 5 5 6 3 7 1 8 0 9 0 5 3 7 2 4 6 9";
            Assert.AreEqual(engine.Score(input), 96);
        }

        [TestMethod]
        public void IncompleteFrameSets()
        {
            var input = "0 10 5 4 8";
            Assert.AreEqual(engine.Score(input), 32);   // as rule provided "assumes any remaining bowls scored 0"
        }
    }
}
