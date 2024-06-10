using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace restaurant
{
    class Cart
    {
        public List<Food> cartItems = new List<Food>();
        public void AddItem(Food item)
        {
            cartItems.Add(item);
            Console.WriteLine(item.Name + " dodano do koszyka.");
        }
        public void RemoveItem(int index)
        {
            Console.WriteLine(cartItems[index].Name + " usunięte z koszyka.");
            cartItems.RemoveAt(index);
        }
        public void DisplayCart()
        {
            Console.WriteLine("Koszyk:");
            if (cartItems.Count == 0)
            {
                Console.WriteLine("Twój koszk jest pusty.");
            }
            else
            {
                int i = 0;
                foreach (Food item in cartItems)
                {
                    i++;
                    Console.WriteLine($"{i}.{item}");
                }
            }
        }
        public void DisplayReceipt()
        {
            DisplayCart();
            double suma = 0;
            foreach (Food item in cartItems)
            {
                suma += item.Price;
            }
            Console.WriteLine($"Cena do zapłaty {suma} zł");
        }
    }
}
