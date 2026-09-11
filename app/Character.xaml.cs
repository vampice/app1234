namespace app;

public partial class Character : ContentPage
{
    Random random = new Random();

    string[] names =
    {
        "Aster",
        "Raven",
        "Luna",
        "Noir",
        "Kael",
        "Eira",
        "Valk",
        "Aria"
    };

    string[] classes =
    {
        "Warrior",
        "Paladin",
        "Wizard",
        "Rogue",
        "Archer",
        "Dark Knight",
        "Enchanter"
    };

    string[] styles =
    {
        "สายโจมตี",
        "สายป้องกัน",
        "สายเวท",
        "สายสนับสนุน",
        "สายสมดุล"
    };

    string[] weapons =
    {
        "ดาบ",
        "ดาบใหญ่",
        "หอก",
        "ธนู",
        "คทา",
        "เคียว",
        "ดาบต้องสาป"
    };

    string[] skills =
    {
        "Power Slash",
        "Holy Strike",
        "Dark Flame",
        "Shadow Step",
        "Arcane Blast",
        "Crimson Blade",
        "Devil Contract"
    };

    public Character()
    {
        InitializeComponent();
    }

    private void Character_Clicked(object sender, EventArgs e)
    {
        NameLabel.Text = RandomItem(names);
        ClassLabel.Text = RandomItem(classes);
        StyleLabel.Text = RandomItem(styles);

        STRLabel.Text = RandomStat().ToString();
        DEXLabel.Text = RandomStat().ToString();
        ENDLabel.Text = RandomStat().ToString();
        INTLabel.Text = RandomStat().ToString();
        CHALabel.Text = RandomStat().ToString();

        WeaponLabel.Text = RandomItem(weapons);
        SkillLabel.Text = RandomItem(skills);
    }

    private string RandomItem(string[] items)
    {
        return items[random.Next(items.Length)];
    }

    private int RandomStat()
    {
        return random.Next(1, 21);
    }
}