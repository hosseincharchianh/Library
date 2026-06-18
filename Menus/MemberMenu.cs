using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

            }
        }
    }
}