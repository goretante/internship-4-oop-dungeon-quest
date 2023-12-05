
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

    public static Hero CreateHero()
    {
        Console.WriteLine("Unesite ime heroja: ");
        string name = Console.ReadLine();

        Console.WriteLine("Odaberite vrstu heroja:\n1 - Gladiator\n2 - Enchanter\n3 - Marksman");
        int choice = int.Parse(Console.ReadLine());

        HeroType heroType;
        switch (choice)
        {
            case 1:
                heroType = HeroType.Gladiator;
                break;
            case 2:
                heroType = HeroType.Enchanter;
                break;
            case 3:
                heroType = HeroType.Marksman;
                break;
            default:
                // default type is Gladiator
                heroType = HeroType.Gladiator;
                break;
        }
    }

    public void LevelUp()
    {
        // xp is 0 after levelup
        Experience = 0;

        // increasing level
        Level++;

        // increasing damage and health
        Health += 15;
        Damage += 5;

        // print message
        Console.WriteLine($"{Name} je dostigao novi nivo! Novi nivo: {Level}");
        Console.WriteLine($"Zdravlje je povećano na {Health}, šteta je povećana na {Damage}.");
    }
}

public class Gladiator : Hero
{
    public int RageTreshold { get; set; }
    public Gladiator(string name, int health, int experience, int damage, HeroType type) : base(name, health, experience, damage, type)
    {
        RageTreshold = (int)(health * 0.3);
    }

    public void RageAttack()
    {
        if (Health >= RageTreshold)
        {
            Health -= (int)(Health * 0.15);

            int doubleDamage = Damage * 2;
            Console.WriteLine($"{Name} napada iz bijesa i nanosi duplu štetu ({doubleDamage})!");
        }
        else
        {
            Console.WriteLine($"{Name} nema dovoljno zdravlja za napad iz bijesa");
        }
    }
}

public class Enchanter : Hero
{
    public int Mana { get; set; }
    public int MaxMana { get; set; }

    public Enchanter(string name, int health, int experience, int damage, HeroType type) : base(name, health, experience, damage, type)
    {
        Mana = MaxMana = 50;
    }

    public void UseMana(int amount)
    {
        if (Mana >= amount)
        {
            Mana -= amount;
            Console.WriteLine($"{Name} koristi {amount} poena mane za napad!");
        }
        else
        {
            Console.WriteLine($"{Name} nema dovoljno mane za napad.");
        }
    }

    public void RestoreMana()
    {
        Mana = MaxMana;
        Console.WriteLine($"{Name} obnavlja manu nakon bitke.");
    }
}

public class Marksman : Hero
{
    public double CriticalChance { get; set; }
    public double StunChance { get; set; }

    public Marksman(string name, int health, int experience, int damage, HeroType type) : base(name, health, experience, damage, type)
    {
        CriticalChance = 0.1;
        StunChance = 0.05;
    }

    public void AttackWithCritical()
    {
        double randomValue = new Random().NextDouble();

        if (randomValue < CriticalChance)
        {
            int doubleDamage = Damage * 2;
            Console.WriteLine($"{Name} izvodi kritični udarac i nanosi duplu štetu ({doubleDamage})!");
        }
        else
        {
            Console.WriteLine($"{Name} izvodi običan napad.");
        }
    }

    public bool ApplyStun()
    {
        double randomValue = new Random().NextDouble();

        if (randomValue < StunChance)
        {
            Console.WriteLine($"{Name} omamljuje protivnika! Protivnik gubi rundu.");
            return true;
        }

        return false;
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

public class Goblin : Monster
{
    public double SideAttackProbability { get; set; }
    public Goblin(string name, int health, int damage, int experience) : base(name, health, damage, experience)
    {
        SideAttackProbability = 0.6;
    }

    double randomValue = new Random().NextDouble();

    public void SneakyAttack()
    {
        if (randomValue <= SideAttackProbability)
        {
            int sneakDamage = Damage * 2;
            Console.WriteLine($"{Name} izvodi podmukli napad sa strane i nanosi duplu štetu ({sneakDamage})!");
        }
    }
}

public class Brute : Monster
{
    public double HeavyAttackProbability { get; set; }
    public Brute(string name, int health, int damage, int experience) : base(name, health, damage, experience)
    {
        HeavyAttackProbability = 0.2;
    }

    public void PerformHeavyAttack()
    {
        double randomValue = new Random().NextDouble();
        if (randomValue < HeavyAttackProbability)
        {
            int heavyDamage = Damage * 3;
            Console.WriteLine($"{Name} izvodi snažan napad i nanosi trostruku štetu ({heavyDamage})!");
        }
    }
}

public class Witch : Monster
{
    public int GingerbreadCount { get; private set; }
    public Witch(string name, int health, int damage, int experience) : base(name, health, damage, experience)
    {
        GingerbreadCount = 3;
    }

    public void CastGingerbreadSpell()
    {
        if (GingerbreadCount > 0)
        {
            Console.WriteLine($"{Name} baca čarobni đumbus!");

        }
    }
}

public class Participant
{
   
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
                        return 0;
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
                        return 0;
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
                        return 0;
                }

            default:
                return 0;
        }
    }
}