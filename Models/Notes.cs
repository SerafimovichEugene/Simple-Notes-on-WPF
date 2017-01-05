using System.Collections.Generic;
using System.Linq;
using System.Collections.ObjectModel;
using System.IO;
using System.Data.Entity;
using System;
using System.Windows;
using System.Data.Entity.Infrastructure;

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
            bool SavedFailed;
            using (context = new NotesContext(ConnectionString))
            {
                foreach (var item in listOfNotes)
                {
                    context.MyNotes.Attach(item);
                    context.Entry(item).State = EntityState.Modified;
                }
                do
                {
                    SavedFailed = false;
                    try
                    {
                        await context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException ex)
                    {
                        SavedFailed = true;
                        ex.Entries.Single().Reload();
                        //MessageBox.Show(ex.Message);
                    }
                } while (SavedFailed);

            }


        }
        public async void DeleteNote(Guid guid)
        {
            using (context = new NotesContext(ConnectionString))
            {
                var NoteToRemove = await (from d in context.MyNotes
                                          where d.Id == guid
                                          select d).SingleAsync();
                context.MyNotes.Remove(NoteToRemove);
                listOfNotes.Remove(NoteToRemove);
                await context.SaveChangesAsync();
            }
        }
    }
}
