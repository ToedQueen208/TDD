using FluentAssertions;
using NUnit.Framework.Legacy;
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

        [Test, Description ("Testing if string is reversed")]
        [TestCase ("adasw","wsada")]
        [TestCase ("qw12er", "re21wq")]
        public void ReverseString(string input, string expected)
        {
            StringManipulator testManipulator = new StringManipulator();

            var stringAns = testManipulator.ReverseString(input);

            stringAns.Should().Be(expected);


        }
        
        [Test]
        [TestCase ("asd", false)]
        [TestCase ("Eevee", true)]
        public void isPalindrome(string input, bool expected)
        {

            StringManipulator testManipulator = new StringManipulator();

            var stringAns = testManipulator.IsPalindrome(input);

            stringAns.Should().Be(expected);
        }
    
    }

}