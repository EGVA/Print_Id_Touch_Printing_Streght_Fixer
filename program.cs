using Models;

class Program
{
    static async Task Main(string[] args)
    {
        string printerList = await File.ReadAllTextAsync("C:/Users/ericv/OneDrive/Documentos/Arrumar-Impressora");
        Console.WriteLine(printerList);
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