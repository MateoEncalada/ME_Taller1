using CommunityToolkit.Mvvm.Input;
using ME_Taller1.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace ME_Taller1.ViewModels
{
    internal class NotesViewModelME: IQueryAttributable
    {
        public ObservableCollection<ViewModels.NoteViewModelME> AllNotes { get; }
        public ICommand NewCommand { get; }
        public ICommand SelectNoteCommand { get; }

        public NotesViewModelME()
        {
            AllNotes = new ObservableCollection<ViewModels.NoteViewModelME>(Models.NotesME.LoadAll().Select(n => new NoteViewModelME(n)));
            NewCommand = new AsyncRelayCommand(NewNoteAsync);
            SelectNoteCommand = new AsyncRelayCommand<ViewModels.NoteViewModelME>(SelectNoteAsync);
        }

        private async Task NewNoteAsync()
        {
            await Shell.Current.GoToAsync(nameof(Views.NotePageME));
        }

        private async Task SelectNoteAsync(ViewModels.NoteViewModelME note)
        {
            if (note != null)
                await Shell.Current.GoToAsync($"{nameof(Views.NotePageME)}?load={note.Identifier}");
        }

        void IQueryAttributable.ApplyQueryAttributes(IDictionary<string, object> query)
        {
            if (query.ContainsKey("deleted"))
            {
                string noteId = query["deleted"].ToString();
                NoteViewModelME matchedNote = AllNotes.Where((n) => n.Identifier == noteId).FirstOrDefault();

                // If note exists, delete it
                if (matchedNote != null)
                    AllNotes.Remove(matchedNote);
            }
            else if (query.ContainsKey("saved"))
            {
                string noteId = query["saved"].ToString();
                NoteViewModelME matchedNote = AllNotes.Where((n) => n.Identifier == noteId).FirstOrDefault();

                // If note is found, update it
                if (matchedNote != null)
                    matchedNote.Reload();

                // If note isn't found, it's new; add it.
                else
                    AllNotes.Add(new NoteViewModelME(NotesME.Load(noteId)));
            }
        }
    }
}
