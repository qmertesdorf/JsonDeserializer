using System;
using System.IO;
using Newtonsoft.Json.Linq;
using Microsoft.Extensions.Configuration;

namespace JsonDeserializer
{
    class Program
    {
        static void Main(string[] args)
        {
            //Read data from appsettings.json
            IConfiguration config = ReadConfig();

            //Determine which given file path is valid (if any)
            string filepath = DetermineFilePath(config, args);

            if (filepath == null)
            {
                //In the case where user did not pass in the "-f" argument or there is no valid filepath, exit application
                //User-facing error message would go here
                Console.WriteLine("Invalid arguments supplied to application.");
                Environment.Exit(1);
            }
            

            JObject parsedJSON = JObject.Parse(File.ReadAllText(@filepath));
            JArray jsonArray = (JArray)parsedJSON["items"];
            foreach (JToken item in jsonArray)
            {
                Console.WriteLine(item["name"]);
            }
        }
        static private IConfiguration ReadConfig()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");
            IConfiguration config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", true, true)
                .Build();
            return config;
        }
        static private string DetermineFilePath(IConfiguration config, string[] args)
        {
            if (args.Length == 2 && File.Exists(args[1]) && args[0] == "-f")
            {
                return args[1];
            } else if (config["filepath"] != null && File.Exists(config["filepath"]))
            {
                return config["filepath"];
            }
            else
            {
                return null;
            }
        }
    }
}