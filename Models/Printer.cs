using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using Arrumar_Impressora.Models;

namespace Models
{
    public class Printer
    {
        public string? Session { get; set; }
        public required string Name { get; set; }
        public required string Ip { get; set; }

        public Printer(string name, string ip)
        {
            Name = name;
            Ip = ip;
        }

        async Task<HttpStatusCode?> LoginPrinter(Printer printer)
        {
            HttpClient client = new HttpClient()
            {
                BaseAddress = new Uri(Ip)
            };

            using StringContent jsonContent = new(JsonSerializer.Serialize(new
            {
                user = "admin",
                password = "admin"
            }),
            Encoding.UTF8,
            "application/json");

            using HttpResponseMessage response = await client.PostAsync(
            "api/v1/login",
            jsonContent);

            response.EnsureSuccessStatusCode();

            var jsonResponse = await response.Content.ReadAsStreamAsync();
            Token? token = await JsonSerializer.DeserializeAsync<Token>(jsonResponse);

            Console.WriteLine($"Session: {token?.session}");

            Session = token?.session;

            return response.StatusCode;
        }

        async Task ChangeConfig()
        {
            // Setups HttpClient for connection
            HttpClient client = new HttpClient () {
                BaseAddress = new Uri(Ip)
            };

            // Object to be parsed and send printers config.
            DriverConfig driver = new DriverConfig() 
            {
                print_qual = 0, // Sets maximum printers quality 0 = max, 1, 2.
                printhead_time = 180 // Sets printhead, makes the printing blackier, with more contrast. 180 is the maximum.
            };
            // thats objects is just for the json parsing returns the right format that printers read.
            DriverConfigObj driver_config = new DriverConfigObj()  
            {
                driver_config = driver
            };

            var json = JsonSerializer.Serialize(driver_config);
            Console.WriteLine(json.ToString());
            using StringContent jsonContent = new(json,
                Encoding.UTF8,
                "application/json");

            client.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", Session);

            using HttpResponseMessage response = await client.PostAsync(
              "api/v1/configuration",
              jsonContent
              );

            response.EnsureSuccessStatusCode();

            Console.WriteLine($"{await response.Content.ReadAsStringAsync()}");
        }


    }

}