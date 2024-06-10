using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace restaurant
{
    class Menu
    {
            public List<Food> Items { get; set; } = new List<Food>();     
            public void AddItem(Food item)
            {
                Items.Add(item);
            } 
            public void AddManuallyItem()
            {
                Console.Clear();
                Console.WriteLine("Wybierz typ jedzenia:");
                Console.WriteLine("1. Danie główne");
                Console.WriteLine("2. Deser");
                Console.WriteLine("3. Napój");
                int choice = Convert.ToInt32(Console.ReadLine());
            try
            {
                Console.WriteLine("Podaj nazwę ");
                string foodName = Console.ReadLine();
                Console.WriteLine("Podaj cenę");
                double foodPrice = Convert.ToDouble(Console.ReadLine());


                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Podaj nazwę dodatku");
                        string sideDish = Console.ReadLine();
                        MainCourse mainCourse = new MainCourse(foodName, foodPrice, sideDish);
                        Items.Add(mainCourse);
                        break;
                    case 2:
                        Console.WriteLine("Czy deser jest bez cukru? (t/n)");
                        bool isSugarFree = Console.ReadLine().ToLower() == "t";
                        Dessert dessert = new Dessert(foodName, foodPrice, isSugarFree);
                        Items.Add(dessert);
                        break;
                    case 3:
                        Console.WriteLine("Czy napój jest alkoholowy? (t/n)");
                        bool isAlcoholic = Console.ReadLine().ToLower() == "t";
                        Drink drink = new Drink(foodName, foodPrice, isAlcoholic);
                        Items.Add(drink);
                        break;
                    default:
                        Console.WriteLine("Niepoprawny wybór");
                        break;
                }
                }
            catch (Exception e)
            {
                Console.WriteLine($"Błąd:{e}");
            }

                Console.WriteLine("Dodano jedzenie");
                        Console.ReadKey();
            }
            public void RemoveItem() {
                Console.Clear();
                DisplayMenu();
                Console.WriteLine("Podaj numer");
                try
                {
                    int item = Convert.ToInt16(Console.ReadLine());
                    Items.RemoveAt(item - 1);
                }catch(Exception ex)
                {
                    Console.WriteLine($"Błąd: {ex}");
                }
            }
            public void DisplayMenu()
            {
                Console.WriteLine("Menu:");
                int i = 0;
                foreach(Food item in Items)
                {
                    i++;
                    Console.WriteLine($"{i}.{item}");
                }
            }
            public Food returnFoodItem(int index)
            {
                return Items[index];
            }
            
            public void changeFoodItem(string filePath) {
            Console.Clear() ;
                DisplayMenu();
                Console.WriteLine("Którą pozycję chcesz zmienić :");
                int index = Convert.ToInt16(Console.ReadLine());
                try
                {
                    var food = Items[index - 1];
                    Console.WriteLine($"Wybrałeś danie {food.Name}");
                    Console.WriteLine("Jak ma się nazywać danie");
                    food.Name = Console.ReadLine();
                    Console.WriteLine("Jaka ma być cena dania");
                    food.Price = Convert.ToDouble(Console.ReadLine());
                    if (food is MainCourse mainCourse)
                    {
                        Console.WriteLine("Podaj nową nazwę dodatku");
                        mainCourse.SideDish = Console.ReadLine();
                    }
                    else if (food is Dessert dessert)
                    {
                        Console.WriteLine("Czy deser jest bez cukru? (t/n)");
                        dessert.IsSugarFree = Console.ReadLine().ToLower() == "t";
                    }
                    else if (food is Drink drink)
                    {
                        Console.WriteLine("Czy napój jest alkoholowy? (t/n)");
                        drink.IsAlcoholic = Console.ReadLine().ToLower() == "t";
                    }
                Console.WriteLine("Pomyślnie zmieniono danie !");
                }catch(Exception e)
                {
                    Console.WriteLine($"Błąd:{e}");
                }
                SaveCollectionToJson(filePath);
            }

            // Zapis
            public void SaveCollectionToJson(string fileName)
            {
                string jsonString = JsonSerializer.Serialize(Items);
                File.WriteAllText(fileName, jsonString);
                Console.WriteLine("Kolekcja zapisana do pliku JSON.");
            }

            //Odczyt
            public void LoadCollectionFromJson(string fileName)
            {
                if (File.Exists(fileName))
                {
                    string jsonString = File.ReadAllText(fileName);
                    Items = JsonSerializer.Deserialize<List<Food>>(jsonString);
                    Console.WriteLine("Menu wczytane z pliku JSON.");
                }
                else
                {
                    Console.WriteLine("Plik JSON nie istnieje.");
                }
            }

    }
}
