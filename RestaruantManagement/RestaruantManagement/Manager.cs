using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaruantManagement;
public abstract class Manager
{
    private static List<Food> foods = new();

    private static List<CustomerOrder> orders = new();

    public static void CreateOrder(string foodName, int count)
    {
        int Id = CreateId(orders);

        var food = foods.Where(f => f.Name == foodName).FirstOrDefault();

        if (food != null)
        {
            if (food != null)
            {
                CustomerOrder order = new(Id, foodName, food.Price, count);
                orders.Add(order);
            }
            var getOrderCheck = orders
                .Where(o => o.Id == Id.ToString() && o.Paid == false).FirstOrDefault();
            if (getOrderCheck != null)
            {
                getOrderCheck.ShowCheck();

            }
        }
        else
        {
            throw new Exception($"{foodName} is finished");
        }



    }

    public static int CreateId<T>(List<T> list)
    {
        int value = 1;
        if (list is List<CustomerOrder>)
        {
            if (list.Count > 0)
                value = list.Count + 1;
        }
        else if (list is List<FastFood>)
        {
            if (list.Count > 0)
                value = list.Count + 1;
        }
        else if (list is List<Kabob>)
        {
            if (list.Count > 0)
                value = list.Count + 1;
        }
        else if (list is List<Stew>)
        {
            if (list.Count > 0)
                value = list.Count + 1;
        }
        return value;
    }



    public static void CreateFood(string name, double price)
    {
        FastFood fastFood = new(name, price);
        foods.Add(fastFood);
        Success();
    }

    public static void CreateFood(FoodType foodType, string name, double price)
    {
        Kabob kabob = new(name, price);
        foods.Add(kabob);
        Success();
    }

    public static void CreateFood(double price, string name)
    {
        Stew stew = new(name, price);
        foods.Add(stew);
        Success();
    }



    public static int GetFoodType()
    {
        Console.WriteLine($" Choice type of food\n" +
            $"\t 1: FastFood\n" +
            $"\t 2: Kabob\n" +
            $"\t 3: stew");
        var foodType = int.Parse(Console.ReadLine()!);
        return foodType;
    }

    public static string GetString(string message)
    {
        Console.WriteLine(message);
        var name = Console.ReadLine()!;
        return name;

    }


    public static void DisplayMenu()
    {

        var fastFood = foods.Where(f => f is FastFood).ToList();
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("FastFood");
        Console.ResetColor();
        Console.ForegroundColor = ConsoleColor.Blue;
        foreach (var food in fastFood)
        {
            Console.WriteLine($"\t {food.Name}   {food.Price}");
        }
        Console.ResetColor();

        var kabob = foods.Where(k => k is Kabob).ToList();
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("Kabob");
        Console.ResetColor();
        Console.ForegroundColor = ConsoleColor.Blue;
        foreach (var food in kabob)
        {
            Console.WriteLine($"\t {food.Name}   {food.Price}");
        }
        Console.ResetColor();

        var stew = foods.Where(s => s is Stew).ToList();
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("Stew");
        Console.ResetColor();
        Console.ForegroundColor = ConsoleColor.Blue;
        foreach (var food in stew)
        {
            Console.WriteLine($"\t {food.Name}   {food.Price}");
        }
        Console.ResetColor();
    }


    public static int GetInteger(string message)
    {
        Console.WriteLine(message);
        var value = int.Parse(Console.ReadLine()!);
        return value;
    }
    public static double GetDouble(string message)
    {
        Console.WriteLine(message);
        var value = double.Parse(Console.ReadLine()!);
        return value;
    }

    public static void Error(string message)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(message);
        Console.ResetColor();
    }

    public static void DisplayFoodDetails(string foodName)
    {
        var food = foods.Find(_ => _.Name == foodName);
        if (food != null)
        {
            food.DisplayDetails();
        }
        else
        {
            throw new Exception("food not found");
        }
    }
    public static void EditPriceOfFood(double newPrice, string foodName)
    {
        var food = foods.Find(_ => _.Name == foodName);
        if (food != null)
        {
            food.EditPrice(newPrice);
            food.DisplayDetails();
        }
        else
        {
            throw new Exception("food not found");
        }
    }

    public static void ShowCustomerCheck(int id)
    {
        var order = orders.Find(_ => _.Id == id.ToString());
        if (order != null)
        {
            order.ShowCheck();
        }
    }

    public static void EditOrderCount(int newCount, int id)
    {
        var order = orders.Find(_ => _.Id == id.ToString());
        if (order != null)
        {
            order.EditCount(newCount);
            order.ShowCheck();
        }

    }

    public static void Success()
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"------------\nSuccess\n------------");
        Console.ResetColor();
    }
    public static int Run()
    {
        Console.WriteLine($"1: Create Food\n" +
            $"2: Display Menu\n" +
            $"3: Add Order\n" +
            $"4: Edit Price of food\n" +
            $"5: Edit Count of customer's order\n" +
            $"0: Exit");
        var value = int.Parse(Console.ReadLine()!);
        return value;
    }

}
