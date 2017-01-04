using System.Collections.Generic;
using System.Linq;
using System.Collections.ObjectModel;
using System.IO;
using System.Data.Entity;
using System;
using System.Windows;

namespace Models
{
    public class Notes
    {
        private List<Note> listOfNotes;
        private static string ConnectionString;
        private static NotesContext context;
        public Notes()
        {
            ConnectionString = "Notes.sdf";
            LoadCollection();
        }
        public List<Note> ListOfNotes
        {
            get { return listOfNotes; }
        }
        private void LoadCollection()
        {
            using (context = new NotesContext(ConnectionString))
            {

                if (File.Exists("Notes.sdf"))
                {
                    var list = new List<Note>(context.MyNotes.ToList());
                    listOfNotes = new List<Note>(list);
                }

                else
                    listOfNotes = new List<Note>();
            }
        }
        public async void AddNote(Note note)
        {
            listOfNotes.Add(note);
            using (context = new NotesContext(ConnectionString))
            {
                context.MyNotes.Add(note);
                await context.SaveChangesAsync();
            }
        }
        public async void SaveNotes()
        {
            try
            {
                using (context = new NotesContext(ConnectionString))
                {
                    foreach (var item in listOfNotes)
                    {
                        context.MyNotes.Add(item);
                        context.Entry(item).State = EntityState.Modified;
                    }
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public async void DeleteNote(int index)
        {
            using (context = new NotesContext(ConnectionString))
            {
                context.MyNotes.Remove(listOfNotes[index]);
                
            }
        }
    }
}
