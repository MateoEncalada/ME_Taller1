using ME_Taller1.Models;
using ME_Taller1.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ME_Taller1.Models
{
    internal class AllNotes
    {
        public ObservableCollection<NotesME> ME_Taller1 { get; set; } = new ObservableCollection<NotesME>();

        public AllNotes() =>
            LoadNotes();

        public void LoadNotes()
        {
            ME_Taller1.Clear();

            // Get the folder where the notes are stored.
            string appDataPath = FileSystem.AppDataDirectory;

            // Use Linq extensions to load the *.notes.txt files.
            IEnumerable<NotesME> notes = Directory

                                        // Select the file names from the directory
                                        .EnumerateFiles(appDataPath, "*.notes.txt")

                                        // Each file name is used to create a new Note
                                        .Select(filename => new NotesME()
                                        {
                                            Filename = filename,
                                            Text = File.ReadAllText(filename),
                                            Date = File.GetCreationTime(filename)
                                        })

                                        // With the final collection of notes, order them by date
                                        .OrderBy(note => note.Date);

            // Add each note into the ObservableCollection
            foreach (NotesME note in notes)
                ME_Taller1.Add(note);
        }
    }
}
