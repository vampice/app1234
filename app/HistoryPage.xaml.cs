namespace app
{
    public partial class HistoryPage : ContentPage
    {
        public HistoryPage()
        {
            InitializeComponent();
            PaletteHistory.Current.Changed += OnHistoryChanged;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            RefreshHistory();
        }

        private void OnHistoryChanged(object? sender, EventArgs e)
        {
            MainThread.BeginInvokeOnMainThread(RefreshHistory);
        }

        private void RefreshHistory()
        {
            HistoryLayout.Children.Clear();
            var entries = PaletteHistory.Current.Entries;
            EmptyLabel.IsVisible = entries.Count == 0;
            ClearButton.IsVisible = entries.Count > 0;

            for (int index = 0; index < entries.Count; index++)
            {
                HistoryLayout.Children.Add(CreateHistoryRow(entries[index], index + 1));
            }

            if (entries.Count == 0)
            {
                HistoryLayout.Children.Add(EmptyLabel);
            }
        }

        private static View CreateHistoryRow(PaletteHistoryEntry entry, int number)
        {
            var row = new Border
            {
                Padding = new Thickness(10, 6),
                StrokeThickness = 1,
                Stroke = new SolidColorBrush(Color.FromArgb("#DDDDDD")),
                BackgroundColor = Colors.Transparent
            };

            var layout = new HorizontalStackLayout
            {
                Spacing = 8,
                VerticalOptions = LayoutOptions.Center
            };

            layout.Children.Add(new Label
            {
                Text = $"#{number}",
                WidthRequest = 34,
                FontAttributes = FontAttributes.Bold,
                VerticalTextAlignment = TextAlignment.Center
            });

            foreach (var hex in entry.Colors)
            {
                var color = Color.FromArgb(hex);
                layout.Children.Add(new VerticalStackLayout
                {
                    Spacing = 2,
                    Children =
                    {
                        new BoxView
                        {
                            Color = color,
                            WidthRequest = 48,
                            HeightRequest = 28,
                            CornerRadius = 4
                        },
                        new Label
                        {
                            Text = hex,
                            FontSize = 9,
                            HorizontalTextAlignment = TextAlignment.Center,
                            WidthRequest = 48
                        }
                    }
                });
            }

            row.Content = layout;
            return row;
        }

        private void OnClearClicked(object? sender, EventArgs e)
        {
            PaletteHistory.Current.Clear();
        }
    }
}
