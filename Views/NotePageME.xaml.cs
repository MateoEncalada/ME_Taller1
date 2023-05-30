namespace ME_Taller1.Views;

[QueryProperty(nameof(ItemId), nameof(ItemId))]
public partial class NotePageME : ContentPage
{
    public string ItemId
    {
        set { LoadNote(value); }
    }
    string _fileName = Path.Combine(FileSystem.AppDataDirectory, "notes.txt");
    public NotePageME()
	{
		InitializeComponent();

        string appDataPath = FileSystem.AppDataDirectory;
        string randomFileName = $"{Path.GetRandomFileName()}.notes.txt";

        LoadNote(Path.Combine(appDataPath, randomFileName));

        if (File.Exists(_fileName))
            METextEditor.Text = File.ReadAllText(_fileName);
    }
    private async void SaveButton_Clicked(object sender, EventArgs e)
    {
        if (BindingContext is Models.NotesME note)
            File.WriteAllText(note.Filename, METextEditor.Text);

        await Shell.Current.GoToAsync("..");
    }

    private async void DeleteButton_Clicked(object sender, EventArgs e)
    {
        if (BindingContext is Models.NotesME note)
        {
            // Delete the file.
            if (File.Exists(note.Filename))
                File.Delete(note.Filename);
        }

        await Shell.Current.GoToAsync("..");
    }
    /*
    private void SaveButton_Clicked(object sender, EventArgs e)
    {
        File.WriteAllText(_fileName, METextEditor.Text);
    }

    private void DeleteButton_Clicked(object sender, EventArgs e)
    {
        if (File.Exists(_fileName))
            File.Delete(_fileName);

        METextEditor.Text = string.Empty;
    }*/
    private void LoadNote(string fileName)
    {
        Models.NotesME noteModel = new Models.NotesME();
        noteModel.Filename = fileName;

        if (File.Exists(fileName))
        {
            noteModel.Date = File.GetCreationTime(fileName);
            noteModel.Text = File.ReadAllText(fileName);
        }

        BindingContext = noteModel;
    }
}