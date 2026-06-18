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
        public required string Title { get; set; }
        public required string Publisher { get; set; }
        public required string Writer { get; set; }
        public double Price { get; set; }
        public override string ToString()
        {
            return $"(Book) {Id} {Title} {Publisher} {Writer} {Price} "; 
        }
    }   
}