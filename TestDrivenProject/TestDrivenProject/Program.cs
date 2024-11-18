namespace TestDrivenProject
{
    internal class Program
    {

    
        static void Main(string[] args)
        {
            ShoppingCart cart = new ShoppingCart();
            cart.AddItem("test", double.MaxValue + 1);
            cart.AddItem("test1", double.MaxValue + 324.545345);
            Console.WriteLine(cart.CalculateTotal());
        }
    }
}
