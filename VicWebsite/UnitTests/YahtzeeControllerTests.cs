using Microsoft.VisualStudio.TestTools.UnitTesting;
using VicWebsite.Controllers;
using System.Web.Mvc;
using System.Linq;

namespace VicWebsiteTests
{
    namespace YahtzeeControllerTests
    {
        public abstract class BaseTests
        {
            protected YahtzeeController Controller;

            [TestInitialize]
            public void Arrange()
            {
                Controller = new YahtzeeController() { };
            }
        }

        [TestClass]
        public class GameLogic : BaseTests
        {
            private ActionResult Act(int[] Dices, string Catagory)
            {
                return Controller.GameLogic(Dices, Catagory);
            }

            [TestMethod]
            public void ShouldReturnYahtzeeIfAllSame()
            {
                int[] array = { 6, 6, 6, 6, 6 };
                var obj = Act(array, "Yahtzee");
                var result = obj.ToString();
                result.Equals("50");
            }

            [TestMethod]
            public void ShouldReturnChanceIfCatagoryIsEmpty()
            {
                var array = Enumerable.Range(1, 6).ToArray();
                var obj = Act(array, "");
                var result = obj.ToString();
                result.Equals(array.Sum().ToString());
            }

            [TestMethod]
            public void ShouldReturn15IfCatagoryIsSmallStraight()
            {
                int[] array = { 1, 2, 3, 4, 5 };
                var obj = Act(array, "Small Straight");
                var result = obj.ToString();
                result.Equals("15");
            }

            [TestMethod]
            public void ShouldReturn0IfConditionIsNotMet()
            {
                int[] array = { 6, 6, 6, 6, 6 };
                var obj = Act(array, "Small Straight");
                var result = obj.ToString();
                result.Equals('0');
            }

            [TestMethod]
            public void ShouldReturnSumIfThreeOfAKind()
            {
                int[] array = { 6, 6, 6, 1, 2};
                var obj = Act(array, "Three of a kind");
                var result = obj.ToString();
                result.Equals("18");
            }

            [TestMethod]
            public void ShouldReturnSumIfFourOfAKind()
            {
                int[] array = { 6, 6, 6, 6, 4 };
                var obj = Act(array, "Four of a kind");
                var result = obj.ToString();
                result.Equals("24");
            }

            [TestMethod]
            public void ShouldReturnSumIfFullHouse()
            {
                int[] array = { 6, 6, 6, 2, 2 };
                var obj = Act(array, "Full House");
                var result = obj.ToString();
                result.Equals("22");
            }
        }
    }
}
