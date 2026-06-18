using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using databaseExercise.DB;
using databaseExercise.Entities;
using databaseExercise.Tools;

namespace databaseExercise.Menus
{
    public static class MemberMenu
    {
        public static void Show()
        {
            var menu = new Menu
            {
                Items = new string[]
                    {
                        "(Members)",
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
                    MemberAdd();
                }
                else if (choice == 2)
                {
                    MembersList();
                }
                else if (choice == 3)
                {
                    MemberUpdate();
                }
                else if (choice == 4)
                {
                    MemberRemove();
                }

            }
        }

        private static void MemberRemove()
        {
            MembersList();
            Console.Write("Enter Id:");
            var id = int.Parse(Console.ReadLine() ?? "");
            using (var db = new MyDB())
            {
                var Member = db.Members.FirstOrDefault(m => m.Id == id);
                if (Member == null)
                {
                    Console.WriteLine("Not Found!");
                }
                else
                {
                    db.Members.Remove(Member);
                    db.SaveChanges();
                    Console.WriteLine("Done");
                }
            }
        }

        private static void MemberUpdate()
        {
            MembersList();
            Console.Write("Enter Id:");
            var id = int.Parse(Console.ReadLine() ?? "");
            using (var db = new MyDB())
            {
                var member = db.Members.FirstOrDefault(m => m.Id == id);
                if (member == null)
                {
                    Console.WriteLine("Not Found!");
                }
                else
                {
                    Console.WriteLine(member);
                    member.Read();
                    db.SaveChanges();
                    Console.WriteLine("Done!");
                }
            }
        }

        public static void MembersList()
        {
            using (var db = new MyDB())
            {
                db
                    .Members
                    .ToList()
                    .ForEach(b => Console.WriteLine(b));
            }
        }

        private static void MemberAdd()
        {
            var member = new Member();
            member.Read();
            using (var db = new MyDB())
            {
                db.Members.Add(member);
                db.SaveChanges();
                Console.WriteLine("Done!");
            }
        }
    }
}
