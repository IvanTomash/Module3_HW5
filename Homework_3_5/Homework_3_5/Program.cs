using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Homework_3_5
{
    internal sealed class Program
    {
        public static async Task Main(string[] args)
        {   
            CreateHelloWorldFiles();            
            var res = await ConcatenateAsync();          
            Console.WriteLine(res); 
        }
        

        private static void CreateHelloWorldFiles()
        {
            using(StreamWriter streamWriter = new StreamWriter("Hello.txt"))
            {
                streamWriter.WriteLine("Hello");
            }
            using (StreamWriter streamWriter = new StreamWriter("World.txt"))
            {
                streamWriter.WriteLine("World!");
            }
        }

        private static async Task<string> ReadFromHelloAsync()
        {
            string result = string.Empty;
            using(StreamReader streamReader = new StreamReader("Hello.txt"))
            {
                result = await streamReader.ReadLineAsync();
            }
            return result;
        }

        private static async Task<string> ReadFromWorldAsync()
        {
            string result = string.Empty;
            using (StreamReader streamReader = new StreamReader("World.txt"))
            {
                result = await streamReader.ReadLineAsync();
            }
            return result;
        }

        private static async Task<string> ConcatenateAsync()
        {
            string concatenatedString = string.Empty;
            var task1 = Task.Run(() => ReadFromHelloAsync());
            var task2 = Task.Run(()=> ReadFromWorldAsync());

            var results = await Task.WhenAll(task1, task2);
            
            foreach (var res in results)
            {
                concatenatedString += res.ToString() +" ";
            }
            return concatenatedString;
        }
    }
}
