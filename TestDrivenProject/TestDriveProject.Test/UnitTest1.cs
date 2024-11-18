using FluentAssertions;
using NUnit.Framework.Legacy;
using System.Diagnostics;
using TestDrivenProject;

namespace TestDriveProject.Test

{
    public class Tests
    {


        [Test]
        public void RotateEastWhenNorth()
        {
            Compass testCompass = new Compass(Point.NORTH);

            var testPoint = testCompass.Rotate(Point.NORTH, Direction.RIGHT);

            Console.WriteLine(testCompass.Point.ToString());

            testPoint.Should().Be(Point.EAST);
        }


        [Test, Description("Multiple right tests")]
        [TestCase(Point.NORTH, Direction.RIGHT, Point.EAST)]
        [TestCase(Point.EAST, Direction.RIGHT, Point.SOUTH)]
        [TestCase(Point.SOUTH, Direction.RIGHT, Point.WEST)]
        [TestCase(Point.WEST, Direction.RIGHT, Point.NORTH)]

        public void RotateRight(Point point, Direction direction, Point expectedPoint)
        {
            Compass testCompass = new Compass(point);

            testCompass.Point = testCompass.Rotate(point, direction);

            Assert.Multiple(() =>
            {
                ClassicAssert.AreEqual(testCompass.Point, expectedPoint);
            });
        }


        [Test, Description("Multiple left tests")]
        [TestCase(Point.NORTH, Direction.LEFT, Point.WEST)]
        [TestCase(Point.EAST, Direction.LEFT, Point.NORTH)]
        [TestCase(Point.SOUTH, Direction.LEFT, Point.EAST)]
        [TestCase(Point.WEST, Direction.LEFT, Point.SOUTH)]

        public void RotateLeft(Point point, Direction direction, Point expectedPoint)
        {
            Compass testCompass = new Compass(point);

            testCompass.Point = testCompass.Rotate(point, direction);

            Assert.Multiple(() =>
            {
                ClassicAssert.AreEqual(testCompass.Point, expectedPoint);
            });
        }

        [Test, Description("Testing if string is reversed")]
        [TestCase("adasw", "wsada")]
        [TestCase("qw12er", "re21wq")]
        public void ReverseString(string input, string expected)
        {
            StringManipulator testManipulator = new StringManipulator();

            var stringAns = testManipulator.ReverseString(input);

            stringAns.Should().Be(expected);


        }

        [Test]
        [TestCase("asd", false)]
        [TestCase("Eevee", true)]
        public void isPalindrome(string input, bool expected)
        {

            StringManipulator testManipulator = new StringManipulator();

            var stringAns = testManipulator.IsPalindrome(input);

            stringAns.Should().Be(expected);
        }

        [Test]
        //[Test, Description("Testing Longest Word")]
        [TestCase("what is the longest word here", "longest")]
        [TestCase("this is the jobs", "this jobs")]
        [TestCase("aaaaaaaaaaaaaaaaaaaaaaaa aaaaaaaa", "aaaaaaaaaaaaaaaaaaaaaaaa")]
        [TestCase("123 45 !! jf kj .", "123")]
        [TestCase("there words biggg        bad", "there words biggg")]
        [TestCase("alll word same leng", "alll word same leng")]

        public void FindLongestWord(string input, string expected)
        {
            string[] parts = expected.Split(' ');
            WordAnalyser analyser = new WordAnalyser();
            List<string> ans = analyser.FindLongestWords(input);

            ans.Count().Should().Be(parts.Count());
            for (int i = 0; i < parts.Count(); i++) {
                ans[i].Should().Be(parts[i]);
            }
        }

        [Test]
        [TestCase("aaaaaaa", 'a', 7)]
        [TestCase("Hello how m  any h in here hehe", "h", 6)]
        public void FindLetterFrequency(string input, char c, int expected)
        {
            WordAnalyser analyser = new WordAnalyser();

            Dictionary<char, int> ans = analyser.CalculateLetterFrequency(input);

            //  ans.Count().Should().Be();
            ans[c].Should().Be(expected);
        }

        [Test]
        [TestCase("test", 20.65, "test", 20.65)]
        [TestCase("anotheritem", -10.0, "anotheritem", 0)]
        [TestCase("yetanotheritem", 50, "yetanotheritem", 50.0)]
        public void AddItem(string item, double price, string expectedName, double exprectedPrice)
        {
            ShoppingCart cart = new ShoppingCart();

            cart.AddItem(item, price);
            Dictionary<string, double> ans = cart.GetItems();

            ans[expectedName].Should().Be(exprectedPrice);
        }

        [Test]
        public void CalculateTotal()
        {
            ShoppingCart cart = new ShoppingCart();

            cart.AddItem("testitem1", 10.5);
            double total = cart.CalculateTotal();
            total.Should().Be(10.5);

            cart.AddItem("testitem2", -10);
            total = cart.CalculateTotal();
            total.Should().Be(10.5);

            cart.AddItem("testitem3", 2.0);
            total = cart.CalculateTotal();
            total.Should().Be(12.5);

            cart.AddItem("testitem4", 10.0);
            total = cart.CalculateTotal();
            total.Should().Be(22.5);

            cart.AddItem("testitem5", 3.0);
            total = cart.CalculateTotal();
            total.Should().Be(25.5);
        }

        [Test]
        [TestCase(0.546, 0.546)]
        [TestCase(-0.1, 0.0)]
        [TestCase(0.0, 0.0)]
        [TestCase(1.5, 1.0)]
        public void ApplyDiscount(double discount, double expected)
        {
            ShoppingCart cart = new ShoppingCart();
            cart.ApplyDiscount(discount);
            cart.Discount.Should().Be(expected);
        }

        [Test]
        [TestCase(100, 0.1, 90)]
        [TestCase(50, 0.05, 47.5)]
        [TestCase(0.0, 0.0, 0.0)]
        [TestCase(1.5, 1.0, 0.0)]
        public void CalculateDiscount(double originalPrice, double discountRate, double expectedPrice)
        {
            ShoppingCart cart = new ShoppingCart();
            double newPrice = cart.CalculateDiscount(originalPrice, discountRate);
            newPrice.Should().Be(expectedPrice);
        }

        [Test]
        public void CalculateItemDiscount()
        {
            ShoppingCart cart = new ShoppingCart();
            cart.AddItem("testitem", 12.0);
            cart.ApplyDiscount(0.5);
            Dictionary<string, double> items = cart.GetItems();
            cart.CalculateDiscount(items["testitem"], cart.Discount).Should().Be(6.0);
        }
    }

}