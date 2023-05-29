namespace ME_Taller1;

public partial class AboutPageME : ContentPage
{
    
    public AboutPageME()
	{
		InitializeComponent();
	}
    private async void MELearnMore_Clicked(object sender, EventArgs e)
    {
        await Launcher.Default.OpenAsync("https://aka.ms/maui");
    }
}