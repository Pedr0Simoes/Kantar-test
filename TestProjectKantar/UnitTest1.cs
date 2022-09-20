using Kantar.Developer.Coding.Test;
namespace TestProjectKantar
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        /* VerifyInputStringFormat Tests */
        [Test]
        public void TestVerifyInputStringFormat1()
        {
            bool result = Kantar.Developer.Coding.Test.TestClass.VerifyInputStringFormat(null);
            Assert.That(result, Is.EqualTo(false));
        }

        [Test]
        public void TestVerifyInputStringFormat2()
        {
            bool result = Kantar.Developer.Coding.Test.TestClass.VerifyInputStringFormat("shoppingbasket ");
            Assert.That(result, Is.EqualTo(false));
        }

        [Test]
        public void TestVerifyInputStringFormat3()
        {
            bool result = Kantar.Developer.Coding.Test.TestClass.VerifyInputStringFormat("shoppingbasket");
            Assert.That(result, Is.EqualTo(false));
        }

        [Test]
        public void TestVerifyInputStringFormat4()
        {
            bool result = Kantar.Developer.Coding.Test.TestClass.VerifyInputStringFormat("shoppingbasketapples");
            Assert.That(result, Is.EqualTo(false));
        }

        [Test]
        public void TestVerifyInputStringFormat5()
        {
            bool result = Kantar.Developer.Coding.Test.TestClass.VerifyInputStringFormat("");
            Assert.That(result, Is.EqualTo(false));
        }

        [Test]
        public void TestVerifyInputStringFormat6()
        {
            bool result = Kantar.Developer.Coding.Test.TestClass.VerifyInputStringFormat(" shoppingbasket apples");
            Assert.That(result, Is.EqualTo(true));
        }

        [Test]
        public void TestVerifyInputStringFormat7()
        {
            bool result = Kantar.Developer.Coding.Test.TestClass.VerifyInputStringFormat("shoppingbasket apples     milk  ");
            Assert.That(result, Is.EqualTo(true));
        }

        [Test]
        public void TestVerifyInputStringFormat8()
        {
            bool result = Kantar.Developer.Coding.Test.TestClass.VerifyInputStringFormat("apples shoppingbasket milk");
            Assert.That(result, Is.EqualTo(false));
        }

        [Test]
        public void TestVerifyInputStringFormat9()
        {
            bool result = Kantar.Developer.Coding.Test.TestClass.VerifyInputStringFormat("  ");
            Assert.That(result, Is.EqualTo(false));
        }

        [Test]
        public void TestVerifyInputStringFormat10()
        {
            bool result = Kantar.Developer.Coding.Test.TestClass.VerifyInputStringFormat("SHOPPINGBASKET APPLES");
            Assert.That(result, Is.EqualTo(true));
        }

        [Test]
        public void TestVerifyInputStringFormat11()
        {
            bool result = Kantar.Developer.Coding.Test.TestClass.VerifyInputStringFormat("SHOPPINGBASKET milk");
            Assert.That(result, Is.EqualTo(true));
        }

        [Test]
        public void TestVerifyInputStringFormat12()
        {
            bool result = Kantar.Developer.Coding.Test.TestClass.VerifyInputStringFormat("shoppingbasket APPLES");
            Assert.That(result, Is.EqualTo(true));
        }

        [Test]
        public void TestVerifyInputStringFormat13()
        {
            bool result = Kantar.Developer.Coding.Test.TestClass.VerifyInputStringFormat("shoppingbasket 324254");
            Assert.That(result, Is.EqualTo(false));
        }

        [Test]
        public void TestVerifyInputStringFormat14()
        {
            bool result = Kantar.Developer.Coding.Test.TestClass.VerifyInputStringFormat("shoppingbasket !@#");
            Assert.That(result, Is.EqualTo(false));
        }

        [Test]
        public void TestVerifyInputStringFormat15()
        {
            bool result = Kantar.Developer.Coding.Test.TestClass.VerifyInputStringFormat("SHOPPINGbasket ApPlES");
            Assert.That(result, Is.EqualTo(true));
        }

        /* IsInPromotion Tests */
        [Test]
        public void TestIsInPromotion1()
        {
            DateTime todaysDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            DateTime startPromotionDate = todaysDate.AddDays(1);
            DateTime endPromotionDate = todaysDate.AddDays(7);
            bool result = Kantar.Developer.Coding.Test.TestClass.VerifyIsInPromotion(startPromotionDate, endPromotionDate);
            Assert.That(result, Is.EqualTo(false));
        }

        [Test]
        public void TestIsInPromotion2()
        {
            DateTime todaysDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            DateTime startPromotionDate = todaysDate.AddDays(-7);
            DateTime endPromotionDate = todaysDate.AddDays(-1);
            bool result = Kantar.Developer.Coding.Test.TestClass.VerifyIsInPromotion(startPromotionDate, endPromotionDate);
            Assert.That(result, Is.EqualTo(false));
        }

        [Test]
        public void TestIsInPromotion3()
        {
            DateTime todaysDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            DateTime startPromotionDate = todaysDate;
            DateTime endPromotionDate = todaysDate.AddDays(7);
            bool result = Kantar.Developer.Coding.Test.TestClass.VerifyIsInPromotion(startPromotionDate, endPromotionDate);
            Assert.That(result, Is.EqualTo(true));
        }

        [Test]
        public void TestIsInPromotion4()
        {
            DateTime todaysDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            DateTime startPromotionDate = todaysDate.AddDays(-7);
            DateTime endPromotionDate = todaysDate;
            bool result = Kantar.Developer.Coding.Test.TestClass.VerifyIsInPromotion(startPromotionDate, endPromotionDate);
            Assert.That(result, Is.EqualTo(true));
        }

        /* ConvertUserInput Tests */
        [Test]
        public void TestConvertUserInput1()
        {
            string? test = null;
            string[] result = Kantar.Developer.Coding.Test.TestClass.ConvertUserInput(test);
            Assert.That(result.Length, Is.EqualTo(0));
        }

        [Test]
        public void TestConvertUserInput2()
        {
            string[] result = Kantar.Developer.Coding.Test.TestClass.ConvertUserInput("");
            Assert.That(result.Length, Is.EqualTo(1));
            Assert.That(result[0], Is.EqualTo(""));
        }

        [Test]
        public void TestConvertUserInput3()
        {
            string[] result = Kantar.Developer.Coding.Test.TestClass.ConvertUserInput("soup soup bread bread  ");
            Assert.That(result.Length, Is.EqualTo(4));
            Assert.That(result[0], Is.EqualTo("soup"));
            Assert.That(result[1], Is.EqualTo("soup"));
            Assert.That(result[2], Is.EqualTo("breadMultiBuyPromo"));
            Assert.That(result[3], Is.EqualTo("bread"));
        }

        [Test]
        public void TestConvertUserInput4()
        {
            string[] result = Kantar.Developer.Coding.Test.TestClass.ConvertUserInput("    bread soup bread soup");
            Assert.That(result.Length, Is.EqualTo(4));
            Assert.That(result[0], Is.EqualTo("breadMultiBuyPromo"));
            Assert.That(result[1], Is.EqualTo("soup"));
            Assert.That(result[2], Is.EqualTo("bread"));
            Assert.That(result[3], Is.EqualTo("soup"));
        }

        [Test]
        public void TestConvertUserInput5()
        {
            string[] result = Kantar.Developer.Coding.Test.TestClass.ConvertUserInput("bread soup bread soup soup");
            Assert.That(result.Length, Is.EqualTo(5));
            Assert.That(result[0], Is.EqualTo("breadMultiBuyPromo"));
            Assert.That(result[1], Is.EqualTo("soup"));
            Assert.That(result[2], Is.EqualTo("bread"));
            Assert.That(result[3], Is.EqualTo("soup"));
            Assert.That(result[4], Is.EqualTo("soup"));
        }

        [Test]
        public void TestConvertUserInput6()
        {
            string[] result = Kantar.Developer.Coding.Test.TestClass.ConvertUserInput("bread soup soup soup soup bread");
            Assert.That(result.Length, Is.EqualTo(6));
            Assert.That(result[0], Is.EqualTo("breadMultiBuyPromo"));
            Assert.That(result[1], Is.EqualTo("soup"));
            Assert.That(result[2], Is.EqualTo("soup"));
            Assert.That(result[3], Is.EqualTo("soup"));
            Assert.That(result[4], Is.EqualTo("soup"));
            Assert.That(result[5], Is.EqualTo("breadMultiBuyPromo"));
        }

        [Test]
        public void TestConvertUserInput7()
        {
            string[] result = Kantar.Developer.Coding.Test.TestClass.ConvertUserInput("bread soup soup soup soup bread milk apples");
            Assert.That(result.Length, Is.EqualTo(8));
            Assert.That(result[0], Is.EqualTo("breadMultiBuyPromo"));
            Assert.That(result[1], Is.EqualTo("soup"));
            Assert.That(result[2], Is.EqualTo("soup"));
            Assert.That(result[3], Is.EqualTo("soup"));
            Assert.That(result[4], Is.EqualTo("soup"));
            Assert.That(result[5], Is.EqualTo("breadMultiBuyPromo"));
            Assert.That(result[6], Is.EqualTo("milk"));
            Assert.That(result[7], Is.EqualTo("apples"));
        }

        [Test]
        public void TestConvertUserInput8()
        {
            string[] result = Kantar.Developer.Coding.Test.TestClass.ConvertUserInput("    ");
            Assert.That(result.Length, Is.EqualTo(1));
            Assert.That(result[0], Is.EqualTo(""));
        }

        [Test]
        public void TestConvertUserInput9()
        {
            string[] result = Kantar.Developer.Coding.Test.TestClass.ConvertUserInput("124 @#$");
            Assert.That(result.Length, Is.EqualTo(2));
            Assert.That(result[0], Is.EqualTo("124"));
            Assert.That(result[1], Is.EqualTo("@#$"));
        }

        /* MarketCashier Tests */

        [Test]
        public void TestMarketCashier1()
        {
            string[] input = { "" };
            List<string> result = Kantar.Developer.Coding.Test.TestClass.MarketCashier(input);
            Assert.That(result[0], Is.EqualTo("Whoops! something went wrong, can't find item with the name "));

        }

        [Test]
        public void TestMarketCashier3()
        {
            string[] input = { "djkfjdfhjk" };
            List<string> result = Kantar.Developer.Coding.Test.TestClass.MarketCashier(input);
            Assert.That(result[0], Is.EqualTo("Whoops! something went wrong, can't find item with the name djkfjdfhjk"));
        }

        [Test]
        public void TestMarketCashier4()
        {
            string[] input = { "bread" };
            List<string> result = Kantar.Developer.Coding.Test.TestClass.MarketCashier(input);
            Assert.That(result[0], Is.EqualTo("Subtotal: €0,80"));
            Assert.That(result[1], Is.EqualTo("(No offers available)"));
            Assert.That(result[2], Is.EqualTo("Total price: €0,80"));
        }

        [Test]
        public void TestMarketCashier5()
        {
            string[] input = { "milk" };
            List<string> result = Kantar.Developer.Coding.Test.TestClass.MarketCashier(input);
            Assert.That(result[0], Is.EqualTo("Subtotal: €1,30"));
            Assert.That(result[1], Is.EqualTo("(No offers available)"));
            Assert.That(result[2], Is.EqualTo("Total price: €1,30"));
        }

        [Test]
        public void TestMarketCashier6()
        {
            string[] input = { "soup" };
            List<string> result = Kantar.Developer.Coding.Test.TestClass.MarketCashier(input);
            Assert.That(result[0], Is.EqualTo("Subtotal: €0,65"));
            Assert.That(result[1], Is.EqualTo("(No offers available)"));
            Assert.That(result[2], Is.EqualTo("Total price: €0,65"));
        }

        [Test]
        public void TestMarketCashier7()
        {
            string[] input = { "apples" };
            List<string> result = Kantar.Developer.Coding.Test.TestClass.MarketCashier(input);
            Assert.That(result[0], Is.EqualTo("Subtotal: €1,00"));
            Assert.That(result[1], Is.EqualTo("Apples 10% off: -€0,10"));
            Assert.That(result[2], Is.EqualTo("Total price: €0,90"));
        }

        [Test]
        public void TestMarketCashier8()
        {
            string[] input = { "apples", "apples" };
            List<string> result = Kantar.Developer.Coding.Test.TestClass.MarketCashier(input);
            Assert.That(result[0], Is.EqualTo("Subtotal: €2,00"));
            Assert.That(result[1], Is.EqualTo("Apples 10% off: -€0,20"));
            Assert.That(result[2], Is.EqualTo("Total price: €1,80"));
        }

        [Test]
        public void TestMarketCashier9()
        {
            string[] input = { "bread", "milk", "soup", "apples" };
            List<string> result = Kantar.Developer.Coding.Test.TestClass.MarketCashier(input);
            Assert.That(result[0], Is.EqualTo("Subtotal: €3,75"));
            Assert.That(result[1], Is.EqualTo("Apples 10% off: -€0,10"));
            Assert.That(result[2], Is.EqualTo("Total price: €3,65"));
        }


        [Test]
        public void TestMarketCashier10()
        {
            string[] input = { "soup", "soup", "breadMultiBuyPromo", "apples" };
            List<string> result = Kantar.Developer.Coding.Test.TestClass.MarketCashier(input);
            Assert.That(result[0], Is.EqualTo("Subtotal: €3,10"));
            Assert.That(result[1], Is.EqualTo("Apples 10% off: -€0,10"));
            Assert.That(result[2], Is.EqualTo("Bread 50% off: -€0,40"));
            Assert.That(result[3], Is.EqualTo("Total price: €2,60"));
        }

        [Test]
        public void TestMarketCashier11()
        {
            string[] input = { "soup", "bread" };
            List<string> result = Kantar.Developer.Coding.Test.TestClass.MarketCashier(input);
            Assert.That(result[0], Is.EqualTo("Subtotal: €1,45"));
            Assert.That(result[1], Is.EqualTo("(No offers available)"));
            Assert.That(result[2], Is.EqualTo("Total price: €1,45"));
        }

        [Test]
        public void TestMarketCashier12()
        {
            string[] input = { "soup", "soup", "breadMultiBuyPromo", "bread" };
            List<string> result = Kantar.Developer.Coding.Test.TestClass.MarketCashier(input);
            Assert.That(result[0], Is.EqualTo("Subtotal: €2,90"));
            Assert.That(result[1], Is.EqualTo("Bread 50% off: -€0,40"));
            Assert.That(result[2], Is.EqualTo("Total price: €2,50"));
        }

        [Test]
        public void TestMarketCashier13()
        {
            string[] input = { "soup", "soup", "soup", "breadMultiBuyPromo", "bread" };
            List<string> result = Kantar.Developer.Coding.Test.TestClass.MarketCashier(input);
            Assert.That(result[0], Is.EqualTo("Subtotal: €3,55"));
            Assert.That(result[1], Is.EqualTo("Bread 50% off: -€0,40"));
            Assert.That(result[2], Is.EqualTo("Total price: €3,15"));
        }

        [Test]
        public void TestMarketCashier14()
        {
            string[] input = { "soup", "soup", "soup", "soup", "soup", "soup", "breadMultiBuyPromo" };
            List<string> result = Kantar.Developer.Coding.Test.TestClass.MarketCashier(input);
            Assert.That(result[0], Is.EqualTo("Subtotal: €4,70"));
            Assert.That(result[1], Is.EqualTo("Bread 50% off: -€0,40"));
            Assert.That(result[2], Is.EqualTo("Total price: €4,30"));
        }

        [Test]
        public void TestMarketCashier15()
        {
            string[] input = { "soup", "soup", "apples", "bread" };
            List<string> result = Kantar.Developer.Coding.Test.TestClass.MarketCashier(input);
            Assert.That(result[0], Is.EqualTo("Subtotal: €3,10"));
            Assert.That(result[1], Is.EqualTo("Apples 10% off: -€0,10"));
            Assert.That(result[2], Is.EqualTo("Total price: €3,00"));
        }

        [Test]
        public void TestMarketCashier16()
        {
            string[] input = { "123" };
            List<string> result = Kantar.Developer.Coding.Test.TestClass.MarketCashier(input);
            Assert.That(result[0], Is.EqualTo("Whoops! something went wrong, can't find item with the name 123"));
        }

        [Test]
        public void TestMarketCashier17()
        {
            string[] input = { "&¨$" };
            List<string> result = Kantar.Developer.Coding.Test.TestClass.MarketCashier(input);
            Assert.That(result[0], Is.EqualTo("Whoops! something went wrong, can't find item with the name &¨$"));
        }

        [Test]
        public void TestMarketCashier18()
        {
            string[] input = { "bread", "milk", "213", "apples" };
            List<string> result = Kantar.Developer.Coding.Test.TestClass.MarketCashier(input);
            Assert.That(result[0], Is.EqualTo("Whoops! something went wrong, can't find item with the name 213"));
        }

        [Test]
        public void TestMarketCashier19()
        {
            string[] input = { "bread", "milk", "$*&", "apples" };
            List<string> result = Kantar.Developer.Coding.Test.TestClass.MarketCashier(input);
            Assert.That(result[0], Is.EqualTo("Whoops! something went wrong, can't find item with the name $*&"));
        }

        [Test]
        public void TestMarketCashier20()
        {
            string[] input = { "bread", "milk", "apples", "213" };
            List<string> result = Kantar.Developer.Coding.Test.TestClass.MarketCashier(input);
            Assert.That(result[0], Is.EqualTo("Whoops! something went wrong, can't find item with the name 213"));
        }

        [Test]
        public void TestMarketCashier21()
        {
            string[] input = { "bread", "milk", "apples", "$*&" };
            List<string> result = Kantar.Developer.Coding.Test.TestClass.MarketCashier(input);
            Assert.That(result[0], Is.EqualTo("Whoops! something went wrong, can't find item with the name $*&"));
        }

        [Test]
        public void TestMarketCashier22()
        {
            string[] input = { "213", "bread", "milk", "apples" };
            List<string> result = Kantar.Developer.Coding.Test.TestClass.MarketCashier(input);
            Assert.That(result[0], Is.EqualTo("Whoops! something went wrong, can't find item with the name 213"));
        }

        [Test]
        public void TestMarketCashier23()
        {
            string[] input = { "$*&", "bread", "milk", "apples",  };
            List<string> result = Kantar.Developer.Coding.Test.TestClass.MarketCashier(input);
            Assert.That(result[0], Is.EqualTo("Whoops! something went wrong, can't find item with the name $*&"));
        }
    }
}