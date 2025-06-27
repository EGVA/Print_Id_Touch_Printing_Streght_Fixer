using Models;

class Program
{
    static async Task Main(string[] args)
    {
        string printerList = await File.ReadAllTextAsync("E:/Arrumar-Impressora/printers.json");
        
        Printer[] printers = [];
        foreach (Printer p in printers)
        {
            try
            {
                await p.ChangeConfig();
            }
            catch (Exception e )
            {
                Console.WriteLine($"Error while setups {p.Name} ex: {e.Message}");
            }
        }
    }
}