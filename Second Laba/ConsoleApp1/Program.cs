using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;


namespace ConsoleApp1
{
    static class Program
    {
        static string[] urls = { "https://www.google.com/", "https://github.com/", "https://www.roblox.com/" };
        public static void SynchronousRequests()
        {
            var httpClient = new HttpClient();
            Stopwatch sw = Stopwatch.StartNew();
            Console.WriteLine("Запускаю синхронные запросы.");
            foreach (var url in urls)
            {
                try
                {
                    Console.WriteLine($"Запрос {url}");
                    var response = httpClient.GetAsync(url).Result;
                    if (!response.IsSuccessStatusCode)
                    {
                        Console.WriteLine($"ERROR! Код ошибки: {response.StatusCode}.");
                        return;
                    }
                    string responseJson = response.Content.ReadAsStringAsync().Result;
                    Console.WriteLine("Ответ сервера (JSON):");
                    Console.WriteLine(responseJson);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"ERROR! {ex.Message}.");
                    return;
                }
            }
            sw.Stop();
            Console.WriteLine($"Запросы выполнены за {sw.ElapsedMilliseconds} мс\n");
        }
        public static async void AsynchronousRequests()
        {
            var httpClient = new HttpClient();
            Stopwatch sw = Stopwatch.StartNew();
            Console.WriteLine("Запускаю асинхронные запросы.");
            foreach (var url in urls)
            {
                try
                {
                    Console.WriteLine($"Запрос {url}");
                    var response = await httpClient.GetAsync(url);
                    if (!response.IsSuccessStatusCode)
                    {
                        Console.WriteLine($"ERROR! Код ошибки: {response.StatusCode}.");
                        return;
                    }
                    string responseJson = await response.Content.ReadAsStringAsync();
                    Console.WriteLine("Ответ сервера (JSON):");
                    Console.WriteLine(responseJson);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"ERROR! {ex.Message}.");
                    return;
                }
            }
            sw.Stop();
            Console.WriteLine($"Запросы выполнены за {sw.ElapsedMilliseconds} мс\n");
        }

        public static void Main()
        {
            SynchronousRequests();
            AsynchronousRequests();
            Console.ReadKey();
        }
    }
}