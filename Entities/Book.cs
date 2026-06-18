using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using databaseExercise.Entities.Base;

namespace databaseExercise.Entities
{
    public class Book : SqlThing
    {
        public  string? Title { get; set; }
        public  string? Publisher { get; set; }
        public  string? Writer { get; set; }
        public double Price { get; set; }
        public override string ToString()
        {
            return $"(Book) {Id} {Title} {Publisher} {Writer} {Price} "; 
        }

        public void Read()
        {
            Console.Write("Title :");
            Title=Console.ReadLine()??"";
            Console.Write("Publisher :");
            Publisher=Console.ReadLine()??"";
            Console.Write("Writer :");
            Writer=Console.ReadLine()??"";
            Console.Write("Price :");
            Price=double.Parse(Console.ReadLine()??"");
        }
    }   
}