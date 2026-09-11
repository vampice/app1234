namespace app
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(AboutPage), typeof(AboutPage));
        }

        private async void OnHomeClicked(object? sender, EventArgs e)
        {
            FlyoutIsPresented = false;
            await GoToAsync(nameof(MainPage));
        }

        private async void OnAboutClicked(object? sender, EventArgs e)
        {
            FlyoutIsPresented = false;
            await GoToAsync(nameof(AboutPage));
        }

        private async void Character_Clicked(object sender, EventArgs e)
        {
            FlyoutIsPresented = false;
            await GoToAsync(nameof(Character));
        }
    }
}
