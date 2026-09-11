using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;

namespace app
{
    public partial class MainPage : ContentPage
    {
        readonly Random rnd = new();

        Color baseSelectedColor = Colors.White;

        public MainPage()
        {
            InitializeComponent();
        }

        // อัปเดตสีที่เลือก
        void UpdateSelectedColor(Color c)
        {
            baseSelectedColor = c;

            int r = (int)(c.Red * 255);
            int g = (int)(c.Green * 255);
            int b = (int)(c.Blue * 255);

            // ถ้ามี Label SelectedHex ใน XAML
            var selectedHex = this.FindByName<Label>("SelectedHex");

            if (selectedHex != null)
            {
                selectedHex.Text = $"#{r:X2}{g:X2}{b:X2}";
            }
        }

        // กดช่องสี
        void OnSwatchTapped(object? sender, TappedEventArgs e)
        {
            if (sender is Border border &&
                border.Content is Grid grid)
            {
                foreach (var child in grid.Children)
                {
                    if (child is BoxView box)
                    {
                        UpdateSelectedColor(box.Color);
                        break;
                    }
                }
            }
        }

        // สุ่มสี 5 ช่อง
        void OnRandomizeClicked(object? sender, EventArgs e)
        {
            var swatches =
                new (BoxView box, Label label)[]
                {
                    (Swatch1, Swatch1Label),
                    (Swatch2, Swatch2Label),
                    (Swatch3, Swatch3Label),
                    (Swatch4, Swatch4Label),
                    (Swatch5, Swatch5Label)
                };
            foreach (var (box, label) in swatches)
            {
                // สุ่ม RGB
                var color = Color.FromRgb(
                    rnd.Next(0, 256),
                    rnd.Next(0, 256),
                    rnd.Next(0, 256)
                );

                // เปลี่ยนสีช่อง
                box.Color = color;

                // แสดงรหัสสี
                UpdateSwatchLabel(box, label);
            }
        }

        private void OnSaveToHistoryClicked(object? sender, EventArgs e)
        {
            PaletteHistory.Current.Add(
                new[]
                {
                    ColorToHex(Swatch1.Color),
                    ColorToHex(Swatch2.Color),
                    ColorToHex(Swatch3.Color),
                    ColorToHex(Swatch4.Color),
                    ColorToHex(Swatch5.Color)
                });
        }

        // แสดง HEX ตรงกลางช่องสี
        private void UpdateSwatchLabel(BoxView box, Label label)
        {
            int r = (int)(box.Color.Red * 255);
            int g = (int)(box.Color.Green * 255);
            int b = (int)(box.Color.Blue * 255);

            label.Text = ColorToHex(box.Color);

            // เปลี่ยนสีตัวหนังสือให้มองเห็นง่าย
            double brightness =
                (0.299 * r) +
                (0.587 * g) +
                (0.114 * b);

            if (brightness > 160)
            {
                label.TextColor = Colors.Black;
            }
            else
            {
                label.TextColor = Colors.White;
            }
        }

        private static string ColorToHex(Color color)
        {
            int r = (int)(color.Red * 255);
            int g = (int)(color.Green * 255);
            int b = (int)(color.Blue * 255);

            return $"#{r:X2}{g:X2}{b:X2}";
        }
    }
}

//hello
