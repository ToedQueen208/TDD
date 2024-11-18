using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDrivenProject
{
    public class ShoppingCart
    {
        private Dictionary<string, double> items = new();

        public ShoppingCart()
        {
            items.Add("Bueno", 0.00);
        }

        public void AddItem(string name, double price)
        {
            if (price < 0) price = 0;
            items.Add(name, price);
        }
        public Dictionary<string, double> GetItems()
        {
            return items;
        }
        public double CalculateTotal()
        {
            double total = 0;
            foreach (var entry in items)
            {
                total += entry.Value;
            }
            return total;
        }
    }
}
