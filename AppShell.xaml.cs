namespace ME_Taller1;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

        Routing.RegisterRoute(nameof(Views.NotePageME), typeof(Views.NotePageME));
    }
}
