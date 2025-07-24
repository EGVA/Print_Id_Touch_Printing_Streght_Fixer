using System.Text.Json;
using System.Text.Json.Nodes;
using Models;

class Program
{
    static async Task Main(string[] args)
    {
        string printerList = await File.ReadAllTextAsync("F:/Arrumar-Impressora/printers.json");

        Printer[]? printers = [];

        try
        {
            printers = JsonSerializer.Deserialize<Printer[]>(printerList);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error deserializing file. ex: {ex.Message}");
        }

        if (printers != null && printers!.Length > 0)
            foreach (Printer p in printers)
            {
                Console.WriteLine($"########{p.Name}########");
                try
                {
                    await p.ChangeConfig();
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Error while setups {p.Name} ex: {e.Message}");
                }
                Console.WriteLine($"#######{p.Name}#######");

            }

        Console.ReadKey();
    }
}
