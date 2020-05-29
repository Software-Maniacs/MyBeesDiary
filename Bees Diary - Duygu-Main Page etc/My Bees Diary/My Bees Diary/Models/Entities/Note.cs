using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Xamarin.Forms;

namespace My_Bees_Diary.Models.Entities
{
    /// <summary>
    /// Code for entity Note.
    /// </summary>
    [Table("Note")]
    public class Note
    {
        /// <summary>
        /// Class constructor.
        /// </summary>
        /// <remarks>
        /// When the user creates a note, its date is automatically set.
        /// </remarks>
        public Note()
        {

        }
        
        /// <summary>
        /// ID of the note in the database.
        /// </summary>
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        /// <summary>
        /// Summary of the note.
        /// </summary>
        public string Summary { get; set; }

        /// <summary>
        /// Description of the note.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// The time when the note has been created.
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Method that returns the summary of the note.
        /// </summary>
        /// <remarks>
        /// This method is used when we want a note to be displayed.
        /// </remarks>
        /// <returns>Summary of the note in a string format.</returns>
        public override string ToString()
        {
            return $"{Summary}";
        }

        /// <summary>
        /// Method that checks whether two notes are equal or not.
        /// </summary>
        /// <param name="obj">The other note.</param>
        /// <returns>Bool that indicated whether they are equal or not.</returns>
        public override bool Equals(object obj)
        {
            if (obj is Note)
            {
                var that = obj as Note;
                return this.ID == that.ID && this.Summary == that.Summary
                    && this.Description == that.Description && this.Date == that.Date;
            }

            return false;
        }
    }
}
