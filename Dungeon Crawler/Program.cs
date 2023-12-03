
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

public enum Action
{
    Direct,
    Side,
    Counter,
    Unknown
}

public class Hero
{
    public string Name { get; set; }
    public int Health { get; set; }
    public int Experience { get; set; }
    public int Damage { get; set; }
    public HeroType Type { get; set; }

    public Hero(string name, int health,int experience, int damage, HeroType type)
    {
        this.Name = name;
        this.Health = health;
        this.Experience = experience;
        this.Damage = damage;
        this.Type = type;
    }


    public Action ChooseAction()
    {
        // print possible actions
        Console.WriteLine("Odaberite radnju: ");
        Console.WriteLine("1. Direktan napad");
        Console.WriteLine("2. Napad s boka");
        Console.WriteLine("3. Protunapad");

        // get user' choice
        int choice = int.Parse(Console.ReadLine());

        // return action
        switch(choice)
        {
            case 1:
                return Action.Direct;
            case 2: 
                return Action.Side;
            case 3: 
                return Action.Counter;
            default:
                return Action.Unknown;
        }
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

    public Action ChooseAction()
    {
        // generate a random number between 1 and 3
        int randomNumber = new Random().Next(1, 4);

        // select an action based on random number
        switch (randomNumber)
        {
            case 1:
                return Action.Direct;
            case 2:
                return Action.Side;
            case 3:
                return Action.Counter;
            default:
                return Action.Unknown;
        }
    }
}

public class Fight
{
    public Hero Hero { get; set; }
    public Monster Monster { get; set; }

    public Fight(Hero hero, Monster monster)
    {
        this.Hero = hero;
        this.Monster = monster;
    }

    public void Start()
    {
        // start the fight
        while (Hero.Health > 0 && Monster.Health > 0)
        {
            // get hero action
            Action heroAction = Hero.ChooseAction();

            // get monster action
            Action monsterAction = Monster.ChooseAction();

            // calculate fight result
        }
    }

    private int CalculateDamage(Action action1, Action action2)
    {
        switch (action1)
        {
            case Action.Direct:
                switch (action2)
                {
                    case Action.Direct:
                        return Hero.Damage;
                    case Action.Side:
                        return Hero.Damage / 2;
                    case Action.Counter:
                        return Hero.Damage * 2;
                    default:
                        return -1;
                }
            
            case Action.Side:
                switch (action2)
                {
                    case Action.Direct:
                        return Hero.Damage / 2;
                    case Action.Side:
                        return Hero.Damage;
                    case Action.Counter:
                        return Hero.Damage / 2;
                    default: 
                        return -2;
                }

            case Action.Counter:
                switch (action2)
                {
                    case Action.Direct:
                        return Hero.Damage * 2;
                    case Action.Side:
                        return Hero.Damage / 2;
                    case Action.Counter:
                        return Hero.Damage;
                    default:
                        return -3;
                }

            default:
                return -4;
        }
    }
}