using System;


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
                Console.WriteLine("Argument is: " + argument);
                Console.WriteLine("Filepath is: " + filepath);
            }
        }
    }
}
