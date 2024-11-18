using TestDrivenProject;
using TestDriveProject;
namespace TestDriveProject.Test

{
    public class Tests
    {
   

        [Test]
        public void RotateEastWhenNorth()
        {
            Compass testCompass = new Compass();

            var testPoint = testCompass.Rotate(Point.NORTH, Direction.RIGHT);
            
            Console.WriteLine(testCompass.Point.ToString()) ;
            Assert.Equals(Point.EAST, testPoint);
            //Point.EAST, testCompass.Point);
    
        }
    }
}