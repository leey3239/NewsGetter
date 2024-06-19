using Microsoft.Extensions.Configuration;
using System;

namespace ConsoleApp7
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var config = new ConfigurationBuilder().AddJsonFile("Base.json").Build();
            string baseApi = config["BaseApi"] ?? string.Empty;
            string apiKey = config["ApiKey"] ?? string.Empty;
            GrabData data = new(baseApi, apiKey);
            Console.WriteLine("NEWS\n1 General\n2 Forex\n3 Crypto\n4 Merger");
            string type;
            switch (Convert.ToInt16(Console.ReadLine()))
            {
                case 1:
                    type = "general";
                    break;
                case 2:
                    type = "forex";
                    break;
                case 3:
                    type = "crypto";
                    break;
                case 4:
                    type = "merger";
                    break;
                default:
                    type = "general";
                    break;
            }
            Console.WriteLine($"Loading News of type {type}");
            var News = await data.GetNews(type);
            Console.WriteLine("1 Full\n2 Headline");
            string? input = Console.ReadLine();
            if (input == "1")
            {
                foreach (var d in News)
                {
                    Console.WriteLine($"{d.Category}, {d.Headline}\nSummary: {d.Summary}\nSource: {d.Source}, {d.Url}\n");
                    
                }
            }
            else
            {
                foreach (var d in News)
                {
                    Console.WriteLine($"{d.Headline}\n");
                    
                }
            }
            
        }
    }
}