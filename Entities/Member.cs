using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using databaseExercise.Entities.Base;

namespace databaseExercise.Entities
{
    public class Member :SqlThing
    {
        public required string  Fullname { get; set; }
        public string?  Address { get; set; }
        public override string ToString()
        {
            return $"(Member) {Id} {Fullname} {Address} ";
        }
    }
}