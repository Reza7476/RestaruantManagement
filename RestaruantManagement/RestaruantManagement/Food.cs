namespace RestaruantManagement;
public abstract class Food
{
    public Food(string name, double price, FoodType food)
    {
        Name = name;
        Price = price;
        FoodType = food;
    }

    public string Name { get; set; }
    public double Price { get; set; }
    public FoodType FoodType { get; set; }

    public abstract void EditPrice(double price);
    public abstract void DisplayDetails();
}
public class FastFood : Food
{
    public FastFood(string name, double price) : base(name, price, FoodType.fastfood) { }

    public override void DisplayDetails()
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine($"--------\n" +
            $" \t name: {Name} price: {Price} \n--------- ");
        Console.ResetColor();
    }

    public override void EditPrice(double price)
    {
        if (price < 0)
        {
            throw new Exception("price can not be less than zero");
        }
        Price = price;
    }
}

public class Kabob : Food
{
    public Kabob(string name, double price) : base(name, price, FoodType.Kabob) { }

    public override void DisplayDetails()
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine($"--------\n" +
            $" \t name: {Name} price: {Price} \n--------- ");
        Console.ResetColor();
    }

    public override void EditPrice(double price)
    {
        if (price < 0)
        {
            throw new Exception("price can not be less than zero");
        }
        Price = price;
    }
}

public class Stew : Food
{
    public Stew(string name, double price) : base(name, price, FoodType.stew) { }

    public override void DisplayDetails()
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine($"--------\n" +
            $" \t name: {Name} price: {Price} \n--------- ");
        Console.ResetColor();
    }

    public override void EditPrice(double price)
    {

        if (price < 0)
        {
            throw new Exception("price can not be less than zero");
        }
        Price = Price;
    }
}



public enum FoodType
{
    fastfood,
    Kabob,
    stew
}