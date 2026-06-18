using databaseExercise.Menus;
using databaseExercise.Tools;

Console.Clear();

var menu = new Menu
{
    Items = new string[]
    {
        "1-Books",
        "2-Members",
        "3-Borrows",
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
    else if (choice==1)
    {
        BookMenu.Show();
    }
    else if(choice==2)
    {
        MemberMenu.Show();
    }
    else if (choice==3)
    {
        BorrowMenu.Show();
    }
}