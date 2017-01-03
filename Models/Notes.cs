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
                    //IQueryable<TextNote> query = from b in context.MyTextNotes.OfType<TextNote>()
                    //                             select b;
                    List<TextNote> list = new List<TextNote>(context.MyTextNotes.ToList()); 
                    listOfNotes = new List<Note>(list);
                }
                    
                else
                    listOfNotes = new List<Note>();
                int x = 0;
            }
        }

        public void GetNotes()
        {

        }
        public void AddNote(Note note)
        {
            listOfNotes.Add(note);
        }
        public void SaveNotes()
        {
            //try
            //{
                using (context = new NotesContext(ConnectionString))
                {
                    foreach (var item in listOfNotes)
                    {
                        context.MyTextNotes.Add(item as TextNote);
                        context.Entry(item as TextNote).State = EntityState.Modified;
                    }
                    context.SaveChanges();
                }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }
    }
}
