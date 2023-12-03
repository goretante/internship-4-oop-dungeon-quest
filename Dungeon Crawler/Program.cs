
public class MainMenu
{
    public void Start()
    {

        // main menu
        Console.WriteLine("~~~ DUNGEON CRAWLER ~~~");
        Console.WriteLine("1. Započni igru");
        Console.WriteLine("2. Promijeni postavke");
        Console.WriteLine("3. Izlaz");

        // user's choice
        int choice = int.Parse(Console.ReadLine());

        // switch case for user's choice
        switch (choice)
        {
            case 1:
                // game start
                // StartGame(); - in progress
                break;
            case 2:
                // change settings
                // ChangeSettings(); - in progress
                break;
            case 3:
                // exit game
                // ExitGame(); - in progress
                break;
        }
    }
}