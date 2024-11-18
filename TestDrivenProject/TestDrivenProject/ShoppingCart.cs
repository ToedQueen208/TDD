using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDrivenProject
{
    public class ShoppingCart
    {
        public double Discount;
        private Dictionary<string, double> items = new();

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
        public void ApplyDiscount(double discount)
        {
            if (discount < 0) discount = 0;
            if (discount > 1) discount = 1;
            Discount = discount;
        }
        public double CalculateDiscount(double originalPrice, double discountRate)
        {
            return originalPrice - (originalPrice * discountRate);
        }
    }
}
