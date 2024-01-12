namespace RestaruantManagement;
public class CustomerOrder
{

    public CustomerOrder(int id, string foodName, double price, int count)
    {
        Id = id.ToString();
        FoodName = foodName;
        Price = price;
        Count = count;
        OrderDate = DateTime.Now;
        TotalPrice = SetTotalPrice();
        Paid = false;
    }

    public string Id { get; private set; }
    public string FoodName { get; private set; }
    public double Price { get; private set; }
    public int Count { get; private set; }
    public double TotalPrice { get; private set; }
    public bool Paid { get; private set; }




    public DateTime OrderDate { get; private set; }

    public void PayOrderPrice()
    {
        Paid = true;
    }

    public void EditCount(int count)
    {
        if (count < 1)
        {
            throw new Exception("count can not be less than zero");
        }
        Count = count;
        TotalPrice = Count * Price;
    }

    public double SetTotalPrice()
    {
        double value = Count * Price;
        return value;
    }




    public void ShowCheck()
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine($"--------\n" +
            $" \tnumber: {Id} name of order: {FoodName} count: {Count} total price: {TotalPrice}\n--------- ");
        Console.ResetColor();
    }

}
