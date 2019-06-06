using System;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace JsonDeserializer
{
    class Program
    {
        static void Main(string[] args)
        {
            string argument = args[0];
            string filepath = args[1];
            if (argument == "-f")
            {
                JObject parsedJSON = JObject.Parse(File.ReadAllText(@filepath));

                JArray jsonArray = (JArray)parsedJSON["items"];
                foreach (JToken item in jsonArray)
                {
                    Console.WriteLine(item["name"]);
                }
            }
        }
    }
}