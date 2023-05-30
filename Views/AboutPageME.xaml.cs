namespace ME_Taller1.Views;

public partial class AboutPageME : ContentPage
{
    
    public AboutPageME()
	{
		InitializeComponent();
	}
    private async void MELearnMore_Clicked(object sender, EventArgs e)
    {
        if (BindingContext is Models.AboutME about)
        {
            await Launcher.Default.OpenAsync("https://aka.ms/maui");
        }
    }
}