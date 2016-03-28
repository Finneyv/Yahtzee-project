using Microsoft.VisualStudio.TestTools.UnitTesting;
using VicWebsite.Controllers;
using System.Web.Mvc;

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
            private ActionResult Act(int[] Dices)
            {
                return Controller.GameLogic(Dices);
            }

            [TestMethod]
            public void ShouldReturnYahtzeeIfAllSame()
            {
                int[] array = { 6, 6, 6, 6, 6 };
                var obj = Act(array);
                var result = obj.ToString();
                result.Equals("50");
            }
        }
    }
}
