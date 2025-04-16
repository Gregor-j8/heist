// See https://aka.ms/new-console-template for more information
List<Robber> Bankrobbers = new List<Robber>()
{
    new Robber {
        Name = "Rob Robber",
        SkillLevel = 50,
        CourageFactor = 1.0M
    },
    new Robber {
        Name = "Mister thiefman",
        SkillLevel = 70,
        CourageFactor = 1.4M
    },
    new Robber {
        Name = "Joe Heist",
        SkillLevel = 80,
        CourageFactor = 1.0M
    }
};

void main()
{
    bool run = true;
    while (run == true)
    {
        Console.WriteLine("Plan your heist");
        Console.WriteLine(@"
    1. Add team members
    2. All teammates
    3. Teammate info 
    4. team Length
    5. Attempt heist 
    6. leave
    ");
        int PlanHeist = int.Parse(Console.ReadLine());
        switch (PlanHeist)
        {
            case 1:
                addTeammate();
                break;
            case 2:
                viewAllTeammates();
                break;
            case 3:
                viewTeammate();
                break;
            case 4:
                teamLength();
                break;
            case 5:
                Heist();
                break;
            case 6:
                run = false;
                break;
        }
    }
}

void addTeammate()
{
    Console.WriteLine("Enter the name of your new teammate");

    string newName = Console.ReadLine();
    if (string.IsNullOrEmpty(newName))
    {
        main();
    }

    Console.WriteLine("Enter the skill level of your new teammate");
    int newSkillLevel = int.Parse(Console.ReadLine());

    Console.WriteLine("Enter the courage factor (decimal 0 - 2.0)");
    decimal newCourageFactor = decimal.Parse(Console.ReadLine());

    Robber newRobber = new Robber()
    {
        Name = newName,
        SkillLevel = newSkillLevel,
        CourageFactor = newCourageFactor

    };
    Bankrobbers.Add(newRobber);
    return;
}

void viewAllTeammates()
{
    foreach (Robber robber in Bankrobbers)
    {
        Console.WriteLine($"Name: {robber.Name} Skill level {robber.SkillLevel} courage {robber.CourageFactor}");
    }
    Console.WriteLine("press enter to continue");
    Console.ReadLine();
    return;
}
;
void teamLength()
{
    Console.WriteLine($"you have {Bankrobbers.Count} in your team");
    Console.WriteLine("press enter to continue");
    Console.ReadLine();
    return;
}
;

void viewTeammate()
{
    Console.WriteLine("\nTeam Members:");
    for (int i = 0; i < Bankrobbers.Count; i++)
    {
        Console.WriteLine($"[{i}] {Bankrobbers[i].Name}");
    }

    Console.Write("\nEnter a teammate's name or number: ");
    string input = Console.ReadLine();

    Robber selectedTeammate = null;

    if (int.TryParse(input, out int index))
    {
        if (index >= 0 && index < Bankrobbers.Count)
        {
            selectedTeammate = Bankrobbers[index];
        }
        else
        {
            Console.WriteLine("Invalid number. No teammate at that index.");
        }
    }
    else
    {
        selectedTeammate = Bankrobbers.FirstOrDefault(
            r => r.Name?.Equals(input, StringComparison.OrdinalIgnoreCase) == true);

        if (selectedTeammate == null)
        {
            Console.WriteLine("Teammate not found by name.");
        }
    }

    if (selectedTeammate != null)
    {
        Console.WriteLine($"\nName: {selectedTeammate.Name}");
        Console.WriteLine($"Skill Level: {selectedTeammate.SkillLevel}");
        Console.WriteLine($"Courage Factor: {selectedTeammate.CourageFactor}");
    }

    Console.WriteLine("\nPress Enter to return to menu...");
    Console.ReadLine();
    return;
}

void Heist()
{
    Console.WriteLine("enter your bank level");
    int level = int.Parse(Console.ReadLine());
    Console.WriteLine("How many time would you like to rob the bank");
    int bankAttempts = int.Parse(Console.ReadLine());
    int skillLevel = 0;
    int bank = level;
    for (int attempt = 1; attempt <= bankAttempts; attempt++)
    {
        foreach (Robber robber in Bankrobbers)
        {
            if (robber.SkillLevel * robber.CourageFactor >= bank)
            {
                skillLevel += robber.SkillLevel;
            }
            else
            {
                Console.WriteLine($"{robber.Name} ran away");
            }
            ;
        }
    ;
        Random random = new Random();
        int heistLuck = random.Next(-10, 11);
        int bankPower = bank + heistLuck;
        if (skillLevel >= bankPower)
        {
            Console.WriteLine("Congrats you robbed the bank");
            Console.WriteLine($"heist skill level {skillLevel}");
            Console.WriteLine($"bank power level {bankPower}");
            skillLevel = 0;
        }
        else
        {
            Console.WriteLine("you didnt rob the bank");
            Console.WriteLine($"heist skill level {skillLevel}");
            Console.WriteLine($"bank power level {bankPower}");
            skillLevel = 0;
        }
    }
}

main();