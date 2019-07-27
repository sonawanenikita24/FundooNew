//--------------------------------------------------------------------------------------------------------------------
// <copyright file="DeletePage.cs" company="BridgeLabz">
// copyright @2019 
// </copyright>
// <creater name="Nikita Sonawane"/>
//------------------------------------------------------------------------------------------------------------------
namespace FundooApplication.Pages.PopUpPages
{
    using System;
    using FundooApplication.Model;
    using FundooApplication.Repository;
    using Plugin.Toast;
    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;
    using static FundooApplication.Model.TypeOfNote;

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DeletePage : ContentPage
    {
        /// <summary>
        /// current note type
        /// </summary>
        private NoteType currentNoteType;

        /// <summary>
        /// note key
        /// </summary>
        private string noteKey;

        /// <summary>
        /// instance of firebase helper class to access database
        /// </summary>
        private NotesRepository firebaseHelper = new NotesRepository();

        /// <summary>
        /// Initializes a new instance of the <see cref="DeletePage"/> class.
        /// </summary>
        /// <param name="noteId">The note identifier.</param>
        public DeletePage(string noteId)
        {
            this.InitializeComponent();
            this.NoteKey = noteId;
            MoveNoteToTrash(NoteKey);
        }

        /// <summary>
        /// Gets or sets the firebase helper.
        /// </summary>
        /// <value>
        /// The firebase helper.
        /// </value>
        public NotesRepository FirebaseHelper
        {
            get
            {
                return this.firebaseHelper;
            }

            set
            {
                this.firebaseHelper = value;
            }
        }

        /// <summary>
        /// Gets or sets the type of the current note.
        /// </summary>
        /// <value>
        /// The type of the current note.
        /// </value>
        public NoteType CurrentNoteType
        {
            get
            {
                return this.currentNoteType;
            }

            set
            {
                this.currentNoteType = value;
            }
        }

        /// <summary>
        /// Gets or sets the note key.
        /// </summary>
        /// <value>
        /// The note key.
        /// </value>
        public string NoteKey
        {
            get
            {
                return this.noteKey;
            }

            set
            {
                this.noteKey = value;
            }
        }

        /// <summary>
        /// Moves the note to trash.
        /// </summary>
        /// <param name="noteKey">The note key.</param>
        private async void MoveNoteToTrash(string noteKey)
        {
            try
            {
                Note note = await this.FirebaseHelper.GetUserNote(this.NoteKey);
                note.NoteType = NoteType.isTrash;
                this.CurrentNoteType = NoteType.isTrash;
                await this.FirebaseHelper.UpdateUserNote(note, this.NoteKey);
                CrossToastPopUp.Current.ShowToastMessage("Note is moved to trash");
                await Navigation.PushModalAsync(new DashBoard());
                ////await PopupNavigation.Instance.PopAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}