namespace ME_Taller1.Views;

public partial class AllNotesPageME : ContentPage
{
	public AllNotesPageME()
    {
        InitializeComponent();
    }

    private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
        notesCollection.SelectedItem = null;
    }
}