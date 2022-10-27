bool orderAgain = true;

Dictionary<string, decimal> tacoBellMenu = new Dictionary<string, decimal>()
{
    { "Soft Taco", 1.69m},
    { "Crunchy Taco", 1.69m },
    { "Nacho Cheese Doritos Locos Taco", 2.59m },
    { "Spicy Potato Soft Taco", 1.00m },
    { "Nachos BellGrande", 5.19m },
    { "Chicken Quesadilla", 4.99m },
    { "Black Bean Quesarito", 3.99m },
    { "Mexican Pizza", 4.99m }
};

Console.WriteLine("Welcome to Taco Bell! It's 2AM and we are about to close, so the only things we aren't out of for the night are: ");
Console.WriteLine();

foreach (KeyValuePair<string, decimal> item in tacoBellMenu)
{
    Console.WriteLine(item.Key + " - " + item.Value);
}

List<string> customerOrder = new List<string>();

do {
    Console.WriteLine();
    Console.WriteLine("What item would you like?");
    string userInput = Console.ReadLine();

    while (!tacoBellMenu.ContainsKey(userInput))
    {
        Console.WriteLine();
            Console.WriteLine("That's not on the menu tonight.");
            Console.WriteLine("Please choose a different item that is currently available: ");
            foreach (KeyValuePair<string, decimal> item in tacoBellMenu)
            {
                Console.WriteLine(item.Key + " - " + item.Value);
            }
            userInput = Console.ReadLine();
            
    }
    customerOrder.Add(userInput);

    Console.WriteLine();
    Console.WriteLine("Got it. Would you like to add to your order (y/n)?");
    string answer = Console.ReadLine();

    if (answer.ToLower() == "n")
    {
        orderAgain = false;
    }
} while (orderAgain);

Console.WriteLine();
Console.WriteLine("You ordered: ");

decimal total = 0;
for (int i = 0; i < customerOrder.Count; i++)
{
        IEnumerable<KeyValuePair<string, decimal>> filteredOrder = tacoBellMenu.Where(x => x.Key.Contains(customerOrder[i]));
        foreach (KeyValuePair<string, decimal> item in filteredOrder)
        {
        Console.WriteLine(item.Key + " - " + item.Value);
        total += item.Value;
        }
}

Console.WriteLine();
Console.WriteLine($"Your total is ${total}");
Console.WriteLine();
Console.WriteLine("Your food will be right out!");