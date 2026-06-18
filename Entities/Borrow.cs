using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using databaseExercise.Entities.Base;

namespace databaseExercise.Entities
{
    public class Borrow : SqlThing
    {
        public Book? Book { get; set; }
        public Member? Member { get; set; }

        public DateTime BorrowTime { get; set; }
        public DateTime? ReturnTime { get; set; }
        public override string ToString()
        {
            return $"(Borrow) {Id} {Book} to {Member} {BorrowTime}";
        }
    }
}