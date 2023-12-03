
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

public enum HeroType
{
    Gladiator,
    Enchanter,
    Marksman
}

public class Hero
{
    public string Name { get; set; }
    public int Health { get; set; }
    public int Damage { get; set; }
    public HeroType Type { get; set; }

    public Hero(string name, int health, int damage, HeroType type)
    {
        this.Name = name;
        this.Health = health;
        this.Damage = damage;
        this.Type = type;
    }
}

public class Monster
{
    public string Name { get; set; }
    public int Health { get; set; }
    public int Damage { get; set; }
    public int Experience { get; set; }

    public Monster(string name, int health, int damage, int experience)
    {
        this.Name = name;
        this.Health = health;
        this.Damage = damage;
        this.Experience = experience;
    }
}