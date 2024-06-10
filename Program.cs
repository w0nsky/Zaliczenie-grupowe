using restaurant;
using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        Menu menu = new Menu();
        Cart cart = new Cart();
        string file_path = @"C:\c#\jedzenie.json";
        Console.ForegroundColor = ConsoleColor.Green;
        if (File.Exists(file_path))
        {
            menu.LoadCollectionFromJson(file_path);
        }

        bool running2 = true;
        while (running2)
        {
            Console.WriteLine("Kto korzysta z systemu:");
            Console.WriteLine("1. Klient");
            Console.WriteLine("2. Pracownik");
            Console.WriteLine("3. Wyjdz");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    bool runningClient = true;
                    Console.Clear();
                    while (runningClient)
                    {
                        
                        Console.WriteLine("1. Menu");
                        Console.WriteLine("2. Wyświelt zamówienie");
                        Console.WriteLine("3. Dodaj do zamówienia");
                        Console.WriteLine("4. Usuń z zamówienia");
                        Console.WriteLine("5. Rachunek");
                        Console.WriteLine("6. Wyjdź");
                        string choice2 = Console.ReadLine();
                        switch (choice2)
                        {
                            case "1":
                                Console.Clear(); 
                                menu.DisplayMenu();
                                break;
                            case "2":
                                Console.Clear(); 
                                cart.DisplayCart();
                                break;
                            case "3":
                                Console.Clear(); 
                                do
                                {
                                    menu.DisplayMenu();
                                    Console.WriteLine("Podaj numer dania które chcesz dodać");
                                    try
                                    {
                                        int addIndex = Convert.ToInt16(Console.ReadLine());
                                        Food foodToAdd = menu.returnFoodItem(addIndex - 1);
                                        cart.AddItem(foodToAdd);
                                    }
                                    catch (Exception e)
                                    {
                                        Console.WriteLine($"Błąd o treści {e}");
                                    }

                                    Console.WriteLine("Czy chcesz dalej kontynnuować dodawanie dań do zamówienia (t/n)");
                                } while (Console.ReadLine() == "t");
                                break;
                            case "4":
                                Console.Clear(); 
                                do
                                {
                                    Console.WriteLine("Wpisz numer dania które chcesz usunąć z zamówienia:");
                                    cart.DisplayCart();
                                    try
                                    {
                                        int removeIndex = Convert.ToInt16(Console.ReadLine());
                                        cart.RemoveItem(removeIndex - 1);
                                    }
                                    catch (Exception e)
                                    {
                                        Console.WriteLine($"Błąd o treści {e}");
                                    }
                                    finally
                                    {
                                        Console.WriteLine("Czy chcesz dalej kontynnuować usuwanie dań z zamówienia (t/n)");
                                    }
                                } while (Console.ReadLine() == "t");
                                break;
                            case "5":
                                Console.Clear();
                                cart.DisplayReceipt();
                                break;
                            case "6":
                                runningClient = false;
                                break;
                            default:
                                Console.WriteLine("Błędne dane, spróbuj jeszcze raz.");
                                break;
                        }
                    }
                    break;
                case "2":
                    Console.Clear();
                    bool runningEmployee = true;
                    while (runningEmployee)
                    {
                        Console.WriteLine("1. Menu");
                        Console.WriteLine("2. Dodaj pozycję do menu");
                        Console.WriteLine("3. Zmień pozycję w menu");
                        Console.WriteLine("4. Wyjscie");
                        string choice2 = Console.ReadLine();
                        switch (choice2)
                        {
                            case "1":
                                Console.Clear();
                                menu.DisplayMenu();
                                break;
                            case "2":
                                Console.Clear();
                                menu.AddManuallyItem();
                                menu.SaveCollectionToJson(file_path);
                                break;
                            case "3":
                                Console.Clear(); 
                                menu.changeFoodItem(file_path);
                                break;
                            case "4":
                                runningEmployee = false;
                                break;
                            default:
                                Console.WriteLine("Błędne dane, spróbuj jeszcze raz.");
                                break;
                        }
                    }
                    break;
                case "3":
                    running2 = false;
                    break;
                default:
                    Console.WriteLine("Brak takiej opcji, spróbuj jeszcze raz.");
                    break;
            }
        }
    }
}
