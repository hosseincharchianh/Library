using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using databaseExercise.DB;
using databaseExercise.Entities;
using databaseExercise.Tools;
using Microsoft.EntityFrameworkCore;

namespace databaseExercise.Menus
{
    public static class BorrowMenu
    {
        public static void Show()
        {
            var menu = new Menu
            {
                Items = new string[]
                    {
                        "(Borrows)",
                        "1-Add",
                        "2-List",
                        "3-borrow return",
                        "0-Exit",
                    }
            };
            while (true)
            {
                var choice = menu.Show();
                if (choice == 0)
                {
                    break;
                }
                else if (choice == 1)
                {
                    BorrowAdd();
                }
                else if (choice == 2)
                {
                    BorrowsList();
                }
                else if (choice == 3)
                {
                    BorrowReturn();
                }

            }
        }

        private static void BorrowReturn()
        {
            BorrowsList();
            Console.Write("Enter Id:");
            var id = int.Parse(Console.ReadLine() ?? "");
            using (var db = new MyDB())
            {
                var borrow = db.Borrows.FirstOrDefault(m => m.Id == id);
                if (borrow == null)
                {
                    Console.WriteLine("Not Found!");
                }
                else
                {
                    Console.WriteLine(borrow);
                    borrow.ReturnTime=DateTime.Now;
                    db.SaveChanges();
                    Console.WriteLine("Done!");
                }
            }
        }

        private static void BorrowsList()
        {
            using (var db = new MyDB())
            {
                db
                    .Borrows
                    .Include(b => b.Member)
                    .Include(b => b.Book)
                    .Where(b => b.ReturnTime == null)
                    .ToList()
                    .ForEach(b => Console.WriteLine(b));
            }
        }

        private static void BorrowAdd()
        {
            BookMenu.BooksList();
            Console.Write("Enter Book Id:");
            var bookId = int.Parse(Console.ReadLine() ?? "");
            MemberMenu.MembersList();
            Console.Write("Enter Member Id:");
            var memberId = int.Parse(Console.ReadLine() ?? "");
            using (var db = new MyDB())
            {
                var book = db.Books.FirstOrDefault(b => b.Id == bookId);
                if (book == null)
                {
                    Console.WriteLine("Book Not Found");
                    return;
                }
                var member = db.Members.FirstOrDefault(m => m.Id == memberId);
                if (member == null)
                {
                    Console.WriteLine("Member Not found!");
                    return;
                }
                var borrow = new Borrow();
                borrow.Book = book;
                borrow.Member = member;
                borrow.BorrowTime = DateTime.Now;
                db.Borrows.Add(borrow);
                db.SaveChanges();
                Console.WriteLine("Done!");
            }
        }
    }
}