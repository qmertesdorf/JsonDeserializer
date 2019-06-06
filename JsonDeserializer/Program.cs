using System;
using System.IO;
using Newtonsoft.Json.Linq;

namespace JsonDeserializer
{
    class Program
    {
        static void Main(string[] args)
        {
            string argument = args[0];
            string filepath = args[1];

            if (argument != "-f" || !File.Exists(filepath))
            {
                //In the case where user did not pass in the "-f" argument or the entered filepath does not exist, exit application
                //User-facing error message would go here
                Environment.Exit(1);
            }
            JObject parsedJSON = JObject.Parse(File.ReadAllText(@filepath));
            JArray jsonArray = (JArray)parsedJSON["items"];
            foreach (JToken item in jsonArray)
            {
                Console.WriteLine(item["name"]);
            }
        }
    }
}