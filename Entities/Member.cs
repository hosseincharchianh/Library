using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using databaseExercise.Entities.Base;

namespace databaseExercise.Entities
{
    public class Member : SqlThing
    {
        public string? Fullname { get; set; }
        public string? Address { get; set; }
        public string? PhoneNumber { get; set; }
        public override string ToString()
        {
            return $"(Member) {Id} {Fullname} {Address} ";
        }

        public void Read()
        {
            Console.Write("Fullname :");
            Fullname = Console.ReadLine() ?? "";
            Console.Write("Address :");
            Address = Console.ReadLine() ?? "";
            Console.Write("PhoneNumber :");
            PhoneNumber = Console.ReadLine() ?? "";
        }
    }
}