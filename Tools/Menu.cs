using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace databaseExercise.Tools
{
    public class Menu
    {
        public required string[] Items { get; set; }
        public int Show()
        {
            Items
                .ToList()
                .ForEach(m => Console.WriteLine(m));
            Console.Write("Choice:");
            return int.Parse(Console.ReadLine() ?? "0");

        }
    }
}