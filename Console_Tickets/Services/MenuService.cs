

using Console_Tickets.Models.Entitites;
using Console_Tickets.Models;
using System.Net.Sockets;

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
        var option = Console.ReadLine();


        switch (option)
        {
            case "1":
                Console.Clear();
                await OptionOneAsync();;
                Console.ReadKey();
                break;
            case "2":
                Console.Clear();
                await OptionTwoAsync();
                Console.ReadKey();
                break;
            case "3":
                Console.Clear();
                await OptionThreeAsync();
                Console.ReadKey();
                break;
            case "4":
                Console.Clear();
                await OptionFourAsync();
                Console.ReadKey();
                break;
            case "5":
                Console.Clear();
                await OptionFiveAsync();
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

    private async Task OptionOneAsync()
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
        //Console.ReadKey();
    }

    private async Task OptionTwoAsync()
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



    }
    private async Task OptionThreeAsync()
    {
        
        Console.Write("Skriv in Id på ärendet: ");
        
        if(int.TryParse(Console.ReadLine(), out int value))
        {
            var errand = await DataService.GetOneAsync(value);

            if(errand != null)
            {
                Console.WriteLine($"{errand.CustomerId}");
                Console.WriteLine($"Namn: {errand.FirstName} {errand.LastName}");
                Console.WriteLine($"Epost: {errand.Email}");
                Console.WriteLine($"Telefonnummer: {errand.PhoneNumber}");
                Console.WriteLine($"Ärende: {errand.Title}");
                Console.WriteLine($"Beskrivning: {errand.Description}");
                Console.WriteLine($"ÄrendeStatus: {errand.Status} \n");
                //Console.ReadKey();
            }
            else
            {
                Console.WriteLine($"Inget ärende med angivna Id {value} hittades.");
                //Console.ReadKey();


            }
        }
        else
        {
            Console.WriteLine("Inte ett Id nummer");
            //Console.ReadKey();

        }

    }

    private async Task OptionFourAsync()
    {
        Console.Write("Skriv in Id på ärendet du vill updatera: ");

        if (int.TryParse(Console.ReadLine(), out int value))
        {
            var errand = await DataService.GetOneAsync(value);
            if (errand != null)
            {
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

                Console.Write("Ändra status: ");
                errand.Status = Console.ReadLine() ?? "";

                await DataService.UpdateAsync(errand);
            }
            else
            {
                Console.WriteLine("Hitta inget ärende med detta Id");

            }
        }
        else
        {
            Console.WriteLine("Inget Id angivet");
        }
    }

    public async Task OptionFiveAsync()
    {
        Console.Write("Skriv in Id på Ärendet du vill ta bort: ");

        if (int.TryParse(Console.ReadLine(), out int value))
        {

            var errand = await DataService.GetOneAsync(value);
            if (errand != null)
            {
                await DataService.DeleteAsync(value);
            }
            else
            {
                Console.WriteLine("Ärende med detta Id hittades inte");
            }
        }
    }
}
