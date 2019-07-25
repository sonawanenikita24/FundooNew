using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;
using Xamarin.Forms;
using static FundooApplication.Model.TypeOfNote;

namespace FundooApplication.Model
{
    /// <summary>
    /// Note model class containing title and note
    /// </summary>
    public class Note
    {
        /// <summary>
        /// The key is identifier for the note
        /// </summary>
        private string key;

        /// <summary>
        /// The title is title of note
        /// </summary>
        private string title;

        /// <summary>
        /// The user note is note under specific title
        /// </summary>
        private string userNote;

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public string Key
        {
            get
            {
                return this.key;
            }

            set
            {
                this.key = value;
            }
        }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>
        /// The title.
        /// </value>
        public string Title
        {
            get
            {
                return this.title;
            }

            set
            {
                this.title = value;
            }
        }

        /// <summary>
        /// Gets or sets the user note.
        /// </summary>
        /// <value>
        /// The user note.
        /// </value>
        public string UserNote
        {
            get
            {
                return this.userNote;
            }

            set
            {
                this.userNote = value;
            }
        }

        /// <summary>
        /// Gets or sets the date time.
        /// </summary>
        /// <value>
        /// The date time.
        /// </value>
        public string DateTime { get; set; }

        /// <summary>
        /// Gets or sets the color of the note.
        /// </summary>
        /// <value>
        /// The color of the note.
        /// </value>
        public Color NoteColor { get; set; }

        /// <summary>
        /// Gets or sets the type of the note.
        /// </summary>
        /// <value>
        /// The type of the note.
        /// </value>
        public NoteType NoteType { get; set; }

        /// <summary>
        /// Gets or sets the label list.
        /// </summary>
        /// <value>
        /// The labels list.
        /// </value>
        public IList<string> LabelsList { get; set; } = new List<string>();

        /// <summary>
        /// Gets or sets the collaborator list.
        /// </summary>
        /// <value>
        /// The collaborator list.
        /// </value>
        public IList<string> CollaboratosList { get; set; } = new List<string>();

        /// <summary>
        /// Gets or sets the note location.
        /// </summary>
        /// <value>
        /// The note location.
        /// </value>
        public Location NoteLocation { get; set; }

        /// <summary>
        /// Gets or sets the image url.
        /// </summary>
        /// <value>
        /// The image url.
        /// </value>
        public ImageSource Imageurl { get; set; }
    }
}
