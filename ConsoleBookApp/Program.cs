// See https://aka.ms/new-console-template for more information

using System.Data.SqlClient;
using System.Reflection.PortableExecutable;


mainMenu();

void mainMenu()
{
    Console.Clear();
    Console.WriteLine("------------------Library---------------------");
    Console.WriteLine("          .--.                   .---.     ");
    Console.WriteLine("      .---|__|           .-.     |~~~|     ");
    Console.WriteLine("   .--|===|--|_          |_|     |~~~|--.  ");
    Console.WriteLine(@"   |  |===|  |'\     .---!~|  .--|   |--|  ");
    Console.WriteLine(@"   |%%|   |  |.'\    |===| |--|%%|   |  |  ");
    Console.WriteLine(@"   |%%|   |  |\.'\   |   | |__|  |   |  |  ");
    Console.WriteLine(@"   |  |   |  | \  \  |===| |==|  |   |  |  ");
    Console.WriteLine(@"   |  |   |__|  \.'\ |   |_|__|  |~~~|__|  ");
    Console.WriteLine(@"   |  |===|--|   \.'\|===|~|--|%%|~~~|--|  ");
    Console.WriteLine(@"   ^--^---'--^    `-'`---^-^--^--^---'--' hjw");

    Console.WriteLine("Please select an option: \n 1- View all Books \n 2 - Update a Book \n 3 - Add a Book \n 4 - Delete a Book");

    string userInput = Console.ReadLine();

    if (userInput == "1")
    {
        ConsoleBookApp.CRUDFunctions.Read();
        Console.WriteLine("------------------------");
        Console.WriteLine("Press 1 to return to main menu");
        userInput = Console.ReadLine();
        if (userInput == "1") {
            mainMenu();
        }

    }
    else if (userInput == "3")
    {
        ConsoleBookApp.CRUDFunctions.Insert();
        Console.WriteLine("------------------------");
        Console.WriteLine("Press 1 to return to main menu");
        userInput = Console.ReadLine();
        if (userInput == "1")
        {
            mainMenu();
        }
    }
    else if (userInput == "4")
    {
        ConsoleBookApp.CRUDFunctions.Delete();
        Console.WriteLine("------------------------");
        Console.WriteLine("Press 1 to return to main menu");
        userInput = Console.ReadLine();
        if (userInput == "1")
        {
            mainMenu();
        }
    }
    else if (userInput == "2")
    {
        ConsoleBookApp.CRUDFunctions.Update();
        Console.WriteLine("------------------------");
        Console.WriteLine("Press 1 to return to main menu");
        userInput = Console.ReadLine();
        if (userInput == "1")
        {
            mainMenu();
        }
    }
    else
    {
        Console.WriteLine("Not a valid option!");
        Console.WriteLine("------------------------");
        Console.WriteLine("Press 1 to return to main menu");
        userInput = Console.ReadLine();
        if (userInput == "1")
        {
            mainMenu();
        }
    }

}
