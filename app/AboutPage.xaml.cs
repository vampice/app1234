using app;

namespace CharacterRandomizer;

public partial class AppearancePage : AboutPage
{
    private readonly Random random = new();

    private readonly string[] genders =
    {
        "ชาย",
        "หญิง",
        "ไม่ระบุ"
    };

    private readonly string[] races =
    {
        "มนุษย์",
        "เอลฟ์",
        "คนแคระ",
        "ปีศาจ",
        "อสูร",
        "แวมไพร์",
        "มนุษย์สัตว์"
    };

    private readonly string[] hairs =
    {
        "ดำ",
        "ขาว",
        "น้ำตาล",
        "แดง",
        "ฟ้า",
        "เขียว",
        "ม่วง",
        "เงิน",
        "ทอง"
    };

    private readonly string[] eyes =
    {
        "ดำ",
        "น้ำตาล",
        "แดง",
        "ฟ้า",
        "เขียว",
        "ม่วง",
        "ทอง",
        "เงิน"
    };

    private readonly string[] personalities =
    {
        "ร่าเริง",
        "เย็นชา",
        "ใจดี",
        "ขี้อาย",
        "กล้าหาญ",
        "เจ้าเล่ห์",
        "จริงจัง",
        "ขี้เล่น",
        "หัวร้อน",
        "เงียบขรึม"
    };

    private readonly string[] outfits =
    {
        "ชุดนักรบ",
        "ชุดอัศวิน",
        "ชุดนักเวท",
        "ชุดนักบวช",
        "ชุดโจร",
        "ชุดขุนนาง",
        "ชุดนักผจญภัย",
        "ชุดเกราะดำ",
        "ชุดแฟนตาซี"
    };

    private readonly string[] accessories =
    {
        "ไม่มี",
        "ต่างหู",
        "สร้อยคอ",
        "แหวน",
        "กำไล",
        "ผ้าคลุม",
        "หน้ากาก",
        "มงกุฎ",
        "เข็มกลัด",
        "เครื่องประดับเวทมนตร์"
    };

    public AboutPage()
    {
        InitializeComponent();

        // ค่าเริ่มต้น
        GenderPicker.SelectedIndex = 0;
        RacePicker.SelectedIndex = 0;
        HairPicker.SelectedIndex = 0;
        EyePicker.SelectedIndex = 0;
        PersonalityPicker.SelectedIndex = 0;
        OutfitPicker.SelectedIndex = 0;
        AccessoryPicker.SelectedIndex = 0;

        HeightSlider.Value = 170;
        HeightLabel.Text = "170 cm";
    }

    private string RandomItem(string[] items)
    {
        return items[random.Next(items.Length)];
    }

    private void RandomAppearance_Clicked(object sender, EventArgs e)
    {
        // สุ่มเพศ
        GenderPicker.SelectedItem = RandomItem(genders);

        // สุ่มเผ่าพันธุ์
        RacePicker.SelectedItem = RandomItem(races);

        // สุ่มสีผม
        HairPicker.SelectedItem = RandomItem(hairs);

        // สุ่มสีตา
        EyePicker.SelectedItem = RandomItem(eyes);

        // สุ่มส่วนสูง 150 - 200
        int height = random.Next(150, 201);

        HeightSlider.Value = height;
        HeightLabel.Text = $"{height} cm";

        // สุ่มนิสัย
        PersonalityPicker.SelectedItem = RandomItem(personalities);

        // สุ่มชุด
        OutfitPicker.SelectedItem = RandomItem(outfits);

        // สุ่มเครื่องประดับ
        AccessoryPicker.SelectedItem = RandomItem(accessories);
    }

    private void HeightSlider_ValueChanged(object sender, ValueChangedEventArgs e)
    {
        int height = (int)Math.Round(e.NewValue);

        HeightLabel.Text = $"{height} cm";
    }
}