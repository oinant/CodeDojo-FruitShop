using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace FruitShop.Tests
{
    [TestClass]
    public class CashierTests  
    {
        [TestMethod]
        public void WhenInputApples_ThenOutput100()
        {
            var cashier = new Cashier();
            cashier.Enter("Apples").ShouldBe(100);
        }

        [TestMethod]
        public void ApplesThenCherries_Output175()
        {
            var cashier = new Cashier();
            cashier.Enter("Apples").ShouldBe(100);
            cashier.Enter("Cherries").ShouldBe(175);
        }

        [TestMethod]
        public void ApplesThenCherriesThenCherries_Output230_withDiscount()
        {
            var cashier = new Cashier();
            var result = cashier.Enter("Apples");
            result = cashier.Enter("Cherries");
            result = cashier.Enter("Cherries");
            result.ShouldBe(230);

        }

        [TestMethod]
        public void Test2()
        {
            var cashier = new Cashier();
            cashier.Enter("Cherries");
            cashier.Enter("Apples");
            cashier.Enter("Cherries");
            cashier.Enter("Bananas");
            cashier.Enter("Cherries");
            cashier.Enter("Cherries");
            var result = cashier.Enter("Apples");
            
            result.ShouldBe(410);
        }

        [TestMethod]
        public void TestFreeBananas()
        {
            var cashier = new Cashier();
            cashier.Enter("Cherries");
            cashier.Enter("Cherries");
            cashier.Enter("Bananas");
            var result = cashier.Enter("Bananas");
            result.ShouldBe(280);
        }


        [TestMethod]
        public void TestFreeBananas2()
        {
            var cashier = new Cashier();
            cashier.Enter("Cherries");
            cashier.Enter("Cherries");
            cashier.Enter("Cherries");
            cashier.Enter("Bananas");
            cashier.Enter("Apples");
            cashier.Enter("Apples");
            var result = cashier.Enter("Bananas");
            result.ShouldBe(355);
        }
        
        [TestMethod]
        public void WhenInputApples_ThenOutput100_Localisation()
        {
            var cashier = new Cashier();
            cashier.Enter("Apples").ShouldBe(100);
            cashier.Enter("Pommes").ShouldBe(200);
            cashier.Enter("Mele").ShouldBe(300);
        }

        [TestMethod]
        public void WhenInputApples_ThenOutput100_LocalisationFull()
        {
            var cashier = new Cashier();
            cashier.Enter("Cherries").ShouldBe(75);
            cashier.Enter("Pommes").ShouldBe(175);
            cashier.Enter("Cherries").ShouldBe(230);
            cashier.Enter("Bananas").ShouldBe(380);
            cashier.Enter("Apples").ShouldBe(280);
            cashier.Enter("Mele").ShouldBe(380);
        }

        [TestMethod]
        public void LocalizedPromotions()
        {
            var cashier = new Cashier();
            cashier.Enter("Mele").ShouldBe(100);
            cashier.Enter("Pommes").ShouldBe(200);
            cashier.Enter("Pommes").ShouldBe(300);
            cashier.Enter("Apples").ShouldBe(300);
            cashier.Enter("Pommes").ShouldBe(100);
            cashier.Enter("Mele").ShouldBe(100);
            cashier.Enter("Cherries").ShouldBe(175);
            cashier.Enter("Cherries").ShouldBe(230);

        }

        [TestMethod]
        public void TestCSV()
        {
            var cashier = new Cashier();
            cashier.Enter("Mele, Pommes, Pommes, Apples, Pommes, Mele, Cherries, Cherries, Bananas").ShouldBe(380);
        }

        [TestMethod]
        public void Test_HotDeal1()
        {
            var cashier = new Cashier();
            cashier.Enter("Mele, Pommes, Pommes, Mele").ShouldBe(200);
            cashier.Enter("Bananas").ShouldBe(150);
            cashier.Enter("Mele, Pommes, Pommes, Apples, Mele").ShouldBe(150);
        }

        [TestMethod]
        public void Test_HotDeal2()
        {
            var cashier = new Cashier();
            cashier.Enter("Mele, Pommes, Apples, Pommes, Mele").ShouldBe(100);
            cashier.Enter("Bananas").ShouldBe(250);
        }
    }
}
