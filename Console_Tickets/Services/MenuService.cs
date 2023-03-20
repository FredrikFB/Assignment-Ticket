
using Console_Tickets.Models;

namespace Console_Tickets.Services;

internal class MenuService
{
        
    
    public async void MainMenu()
    {


        Console.Clear();
        Console.WriteLine("1. Skapa ett ärende/felanmälan");
        Console.WriteLine("2. Visa alla ärenden");
        Console.WriteLine("3. Visa ett specifikt ärende");
        Console.WriteLine("4. Updatera ett ärende");
        Console.WriteLine("5. Ta bort ett ärende");  
        Console.WriteLine("6. Lägg Till en kommentar til ett ärende"); 
        string value = Console.ReadLine() ??"";

        switch (value)
        {
            case "1":
                Console.Clear();
                 OptionOneAsync();
                Console.ReadKey();
                break;
            case "2":
                Console.Clear();
                 OptionTwoAsync();
                Console.ReadKey();
                break;
            case "3":
                Console.Clear();
                 OptionThreeAsync();
                Console.ReadKey();
                break;
            case "4":
                Console.Clear();
                 OptionFourAsync();
                Console.ReadKey();
                break;
            case "5":
                Console.Clear();
                 OptionFiveAsync();
                Console.ReadKey();
                break;
            case "6":
                Console.Clear();
                OptionSixAsync();
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

    private static async Task OptionOneAsync()
    {
        var errand = new Errand();

        Console.WriteLine("Lägg till ett ärende");

        Console.Write("Förnamn: ");
        errand.FirstName = Console.ReadLine() ?? "";

        Console.Write("Efternamn: ");
        errand.LastName = Console.ReadLine() ?? "";

        Console.Write("Epostadress: ");
        errand.Email = Console.ReadLine() ?? "";

        Console.Write("Telefonnummer: ");
        errand.PhoneNumber = Console.ReadLine() ?? "";

        Console.Write("Ärende: ");
        errand.Title = Console.ReadLine() ?? "";

        Console.Write("Beskrivning: ");
        errand.Description = Console.ReadLine() ?? "";

        errand.Status = "Ej påbörjad";


        await DataService.CreateAsync(errand);
    }

    private static async Task OptionTwoAsync()
    {

        var errands = await DataService.GetAllAsync();

        if (errands.Any())
        {
            foreach (Errand errand in errands)
            {
                Console.WriteLine($"Id: {errand.CustomerId}");
                Console.WriteLine($"Namn: {errand.FirstName} {errand.LastName}");
                Console.WriteLine($"Epost: {errand.Email}");
                Console.WriteLine($"Telefonnummer: {errand.PhoneNumber}");
                Console.WriteLine($"Ärende: {errand.Title}");
                Console.WriteLine($"Beskrivning: {errand.Description}");
                Console.WriteLine($"ÄrendeStatus: {errand.Status} \n");
            }
        }
        else
        {
            Console.WriteLine("Finns inga ärenden");
            Console.WriteLine("");
        }



    }
    private static async Task OptionThreeAsync()
    {
        
        Console.Write("Skriv in Id på ärendet: ");
        
        if(int.TryParse(Console.ReadLine(), out int value))
        {
            var errand = await DataService.GetOneAsync(value);

            if(errand != null)
            {
                Console.WriteLine($"{errand.CustomerId}");
                Console.WriteLine($"Namn: {errand.Customer.FirstName} {errand.Customer.LastName}");
                Console.WriteLine($"Epost: {errand.Customer.Email}");
                Console.WriteLine($"Telefonnummer: {errand.Customer.PhoneNumber}");
                Console.WriteLine($"Ärende: {errand.Title}");
                Console.WriteLine($"Beskrivning: {errand.Description}");
                Console.WriteLine($"Skapat: {errand.Created}");
                Console.WriteLine($"ÄrendeStatus: {errand.Status} ");
                Console.WriteLine("");

                if (errand.Comments.Any())
                {
                    Console.WriteLine("Kommentarer: \n");
                    foreach (var _errand in errand.Comments) 
                    {
                        Console.WriteLine($"{_errand.Comment}");
                        Console.WriteLine($"{_errand.CreatedAt} \n");
                    }
                }
            }
            else
            {
                Console.WriteLine($"Inget ärende med angivna Id {value} hittades.");
                Console.WriteLine("");
            }
        }
        else
        {
            Console.WriteLine("Id nummeret finns inte");
            Console.WriteLine("");

        }

    }

    private static async Task OptionFourAsync()
    {
        Console.Write("Skriv in Id på ärendet du vill updatera: ");

        if (int.TryParse(Console.ReadLine(), out int value))
        {
            var errand = await DataService.GetOneAsync(value);
            if (errand != null)
            {
                Console.WriteLine("Lägg till ett ärende");

                Console.Write("Förnamn: ");
                errand.Customer.FirstName = Console.ReadLine() ?? "";

                Console.Write("Efternamn: ");
                errand.Customer.LastName = Console.ReadLine() ?? "";

                Console.Write("Epostadress: ");
                errand.Customer.Email = Console.ReadLine() ?? "";

                Console.Write("Telefonnummer: ");
                errand.Customer.PhoneNumber = Console.ReadLine() ?? "";

                Console.Write("Ärende: ");
                errand.Title = Console.ReadLine() ?? "";

                Console.Write("Beskrivning: ");
                errand.Description = Console.ReadLine() ?? "";

                Console.Write("Status: ");
                errand.Status = Console.ReadLine() ?? "";

                /*Console.Clear();
                Console.WriteLine("Välj status: ");
                Console.WriteLine("1: Ej Påbörjad ");
                Console.WriteLine("2: Pågående ");
                Console.WriteLine("3: Avslutad ");
                string status = Console.ReadLine() ?? "";

                do
                {
                    switch (status)
                    {
                        case "1":
                            errand.Status = "Ej Påbörjad";
                            break;
                        case "2":
                            errand.Status = "Pågående";
                            break;
                        case "3":
                            errand.Status = "Avslutad";
                            break;
                        default:
                            Console.WriteLine("Inte ett alternativ");
                            break;
                    }
                }
                while(status != "1" && status != "2" && status != "3");*/


                await DataService.UpdateAsync(errand);
            }
            else
            {
                Console.WriteLine("Hitta inget ärende med detta Id");
                Console.WriteLine("");
            }
        }
        else
        {
            Console.WriteLine("Inget Id angivet");
            Console.WriteLine("");
        }
    }

    private static async Task OptionFiveAsync()
    {
        Console.Write("Skriv in Id på Ärendet du vill ta bort: ");

        if (int.TryParse(Console.ReadLine(), out int value))
        {
            var errand = await DataService.GetOneAsync(value);
            if (errand != null)
            {
                await DataService.DeleteAsync(value);
                Console.WriteLine($"Ärendet med id {value} är Borttaget");
            }
            else
            {
                Console.WriteLine("Ärende med detta Id hittades inte");
                Console.WriteLine("");
            }
        }
    }

    private async Task OptionSixAsync()
    {
        var comment = new CommentModel();

        Console.WriteLine("Skriv in Id till ärendet du vill lägga en kommentar");
        if (int.TryParse(Console.ReadLine(), out int value))
        {
            var errand = await DataService.GetOneAsync(value);
            if (errand != null)
            {
                Console.WriteLine("Skriv in din Kommentar");
                comment.Comment = Console.ReadLine() ?? "";
                comment.CommentId = value;
                await DataService.AddCommentAsync(comment);
            }
            else 
                Console.WriteLine("Hitta inget ärende med deatta id"); 

        }
        else
            Console.WriteLine("Inget Id Angivet");

    }
}
