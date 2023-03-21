using Console_Tickets.Services;

MenuService menu = new MenuService();

while (true)
{
    Console.Clear();
    Console.WriteLine("1. Skapa ett ärende/felanmälan");
    Console.WriteLine("2. Visa alla ärenden");
    Console.WriteLine("3. Visa ett specifikt ärende");
    Console.WriteLine("4. Updatera ett ärende");
    Console.WriteLine("5. Ta bort ett ärende");
    Console.WriteLine("6. Lägg Till en kommentar til ett ärende");
    string value = Console.ReadLine() ?? "";

    switch (value)
    {
        case "1":
            Console.Clear();
            await menu.OptionOneAsync();
            Console.ReadKey();
            break;
        case "2":
            Console.Clear();
            await menu.OptionTwoAsync();
            Console.ReadKey();
            break;
        case "3":
            Console.Clear();
            await menu.OptionThreeAsync();
            Console.ReadKey();
            break;
        case "4":
            Console.Clear();
            await menu.OptionFourAsync();
            Console.ReadKey();
            break;
        case "5":
            Console.Clear();
            await menu.OptionFiveAsync();
            Console.ReadKey();
            break;
        case "6":
            Console.Clear();
            await menu.OptionSixAsync();
            Console.ReadKey();
            break;
        default:
            Console.Clear();
            Console.WriteLine("Inte ett alternativ");
            Console.ReadKey();
            break;
    }
    Console.WriteLine("\nTryck på valfri knapp för att fortsätta...");
    Console.ReadKey();
}
