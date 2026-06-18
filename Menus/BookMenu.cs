using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using databaseExercise.DB;
using databaseExercise.Entities;
using databaseExercise.Tools;

namespace databaseExercise.Menus
{
    public static class BookMenu
    {
        public static void Show()
        {
            var menu = new Menu
            {
                Items = new string[]
                    {
                        "(Books)",
                        "1-Add",
                        "2-List",
                        "3-Edit",
                        "4-Remove",
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
                    BookAdd();
                }
                else if (choice == 2)
                {
                    BooksList();
                }
                else if (choice == 3)
                {
                    BookUpdate();
                }
                else if (choice == 4)
                {
                    BookRemove();
                }

            }
        }

        private static void BookRemove()
        {
            BooksList();
            Console.Write("Enter Id:");
            var id = int.Parse(Console.ReadLine() ?? "");
            using (var db = new MyDB())
            {
                var book = db.Books.FirstOrDefault(m => m.Id == id);
                if (book == null)
                {
                    Console.WriteLine("Not Found!");
                }
                else
                {
                    db.Books.Remove(book);
                    db.SaveChanges();
                    Console.WriteLine("Done");
                }
            }
        }

        private static void BookUpdate()
        {
            BooksList();
            Console.Write("Enter Id:");
            var id = int.Parse(Console.ReadLine() ?? "");
            using (var db = new MyDB())
            {
                var book = db.Books.FirstOrDefault(m => m.Id == id);
                if (book == null)
                {
                    Console.WriteLine("Not Found!");
                }
                else
                {
                    Console.WriteLine(book);
                    book.Read();
                    db.SaveChanges();
                    Console.WriteLine("Done!");
                }
            }
        }

        private static void BooksList()
        {
            using (var db = new MyDB())
            {
                db
                    .Books
                    .ToList()
                    .ForEach(b => Console.WriteLine(b));
            }
        }

        private static void BookAdd()
        {
            var book = new Book();
            book.Read();
            using (var db = new MyDB())
            {
                db.Books.Add(book);
                db.SaveChanges();
                Console.WriteLine("Done!");
            }
        }
    }
}