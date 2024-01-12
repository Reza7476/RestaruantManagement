


using RestaruantManagement;

while (true)
{
    try
    {
        int exe = Manager.Run();


        switch (exe)
        {
            case 0:
                {

                    Environment.Exit(0);
                    break;
                }
            case 1:
                {

                    var foodType = Manager.GetFoodType();
                    switch (foodType)
                    {
                        case 1:
                            {
                                var foodName = Manager.GetString("enter name of food");
                                var price = Manager.GetDouble("enter price of food");
                                Manager.CreateFood(foodName, price);
                                break;
                            }
                        case 2:
                            {
                                var foodName = Manager.GetString("enter name of food");
                                var price = Manager.GetDouble("enter price of food");
                                Manager.CreateFood(FoodType.Kabob, foodName, price);
                                break;

                            }
                        case 3:
                            {
                                var foodName = Manager.GetString("enter name of food");
                                var price = Manager.GetDouble("enter price of food");
                                Manager.CreateFood(price, foodName);

                                break;

                            }
                        default:
                            {

                                break;
                            }
                    }
                    break;
                }


            case 2:
                {

                    Manager.DisplayMenu();
                    break;
                }
            case 3:
                {
                    Manager.DisplayMenu();
                    Console.WriteLine("Choice food ");
                    var foodName = Manager.GetString("enter food name");
                    var count = Manager.GetInteger($"enter how many of {foodName} do you want");

                    Manager.CreateOrder(foodName, count);
                    break;
                }


            case 4:
                {
                    var foodName = Manager.GetString("enter food name");

                    Manager.DisplayFoodDetails(foodName);

                    var newPrice = Manager.GetDouble($"enter new price for {foodName} ");
                    Manager.EditPriceOfFood(newPrice, foodName);

                    break;
                }

            case 5:
                {

                    var orderId = Manager.GetInteger("enter number of order");
                    Manager.ShowCustomerCheck(orderId);
                    var newCount = Manager.GetInteger("enter new number");
                    Manager.EditOrderCount(newCount, orderId);

                    break;
                }

            default:
                {

                    break;
                }
        }
    }
    catch (Exception ex)
    {

        Manager.Error(ex.Message);
    }
}