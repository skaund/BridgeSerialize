using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BridgeSerialize
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            ContentSerialize<List<Race>> contentSerialize = new RacesSerialize();

            var races = await contentSerialize.GetRacesAsync(@"C:\Users\danya\OneDrive\Рабочий стол\test1\hello.txt");
            contentSerialize.TypeSerialize = new XMLSerializeRaces(races);
            contentSerialize.Serialize(@"C:\Users\danya\OneDrive\Рабочий стол\test1\hello.xml");

            contentSerialize.TypeSerialize = new JsonSerializeRaces(races);
            contentSerialize.Serialize(@"C:\Users\danya\OneDrive\Рабочий стол\test1\hello.json");

            Console.WriteLine("Серилизация с использованием паттерна проектирование Bridge успешно выполнена!");
        }
    }
}
