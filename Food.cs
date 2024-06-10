using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace restaurant
{
    class Food
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public Food()
        {
            string Name = "Brak nazwy";
            double Price = 0;
        }
        public Food(string name, double price)
        {
            Name = name;
            Price = price;
        }
        public override string ToString()
        {
            return $"{Name}, Price: {Price} zł";
        }
    }
    class MainCourse : Food
    {
        public string SideDish { get; set; }

        public MainCourse(string name, double price, string sideDish)
            : base(name, price)
        {
            SideDish = sideDish;
        }

        public override string ToString()
        {
            return $"{Name} with {SideDish}, Price: {Price} zł";
        }
    }

    class Dessert : Food
    {
        public bool IsSugarFree { get; set; }

        public Dessert(string name, double price, bool isSugarFree)
            : base(name, price)
        {
            IsSugarFree = isSugarFree;
        }

        public override string ToString()
        {
            return $"{Name} (Sugar-Free: {IsSugarFree}), Price: {Price} zł";
        }
    }

    class Drink : Food
    {
        public bool IsAlcoholic { get; set; }

        public Drink(string name, double price, bool isAlcoholic)
            : base(name, price)
        {
            IsAlcoholic = isAlcoholic;
        }

        public override string ToString()
        {
            return $"{Name} (Alcoholic: {IsAlcoholic}), Price: {Price} zł";
        }
    }
}
