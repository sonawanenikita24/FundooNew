//--------------------------------------------------------------------------------------------------------------------
// <copyright file="NoteCreation.cs" company="BridgeLabz">
// copyright @2019 
// </copyright>
// <creater name="Nikita Sonawane"/>
//------------------------------------------------------------------------------------------------------------------
namespace FundooApplication.Pages
{
    using System;
    using FundooApplication.Model;
    using FundooApplication.Pages.PlusPopUp;
    using FundooApplication.Pages.PopUpPages;
    using FundooApplication.Repository;
    using Rg.Plugins.Popup.Services;
    using Xamarin.Essentials;
    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NoteCreation : ContentPage
    {
        /// <summary>
        /// The note key
        /// </summary>
        private string notekey = string.Empty;

        /// <summary>
        /// The helper is instance of firebase helper class
        /// </summary>
        private NotesRepository helper = new NotesRepository();

        /// <summary>
        /// image source
        /// </summary>
        public ImageSource profileImage;

        /// <summary>
        /// Initializes a new instance of the <see cref="NoteCreation"/> class.
        /// </summary>
        public NoteCreation()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Gets or sets the helper.
        /// </summary>
        /// <value>
        /// The helper.
        /// </value>
        public NotesRepository Helper
        {
            get
            {
                return this.helper;
            }

            set
            {
                this.helper = value;
            }
        }

        /// <summary>
        /// Gets or sets the note key.
        /// </summary>
        /// <value>
        /// The note key.
        /// </value>
        public string Notekey
        {
            get
            {
                return this.notekey;
            }

            set
            {
                this.notekey = value;
            }
        }

        /// <summary>
        /// When overridden, allows the application developer to customize behavior as the <see cref="T:Xamarin.Forms.Page" /> disappears.
        /// </summary>
        /// <remarks>
        /// To be added.
        /// </remarks>
        protected override async void OnDisappearing()
        {
            ////Location location = await Geolocation.GetLocationAsync();
            var location = await Geolocation.GetLastKnownLocationAsync();
            try
            {
                base.OnDisappearing();

                //// check if fields are empty
                if (Title.Text == null && Note.Text == null)
                {
                    await this.DisplayAlert("Alert", "Empty node Discarded", "ok");
                    await Navigation.PushAsync(new NotesPage());
                }
                else
                {
                    Note note = new Note
                    {
                        Title = Title.Text,
                        UserNote = Note.Text,
                        NoteLocation = location,
                        NoteType = TypeOfNote.NoteType.isNote
                    };

                    /*   if (note.Imageurl != null)
                       {
                             this.profileImage = note.Imageurl;
                             ImageChoosed.Source = profileImage;
                       }*/

                    await this.helper.SubmitNotes(note);
                    ////  await this.Helper.AddNote(Title.Text, Note.Text, location);

                    await this.DisplayAlert("success", "note saved", "ok");
                    //// after getting note navigate to note page
                    await Navigation.PushAsync(new NotesPage());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// ListViews the clicked.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private async void ListViewClicked(object sender, EventArgs e)
        {
            await PopupNavigation.Instance.PushAsync(new PlusPopUpPage(this.notekey));
        }

        /// <summary>
        /// Called when [pop menu button clicked].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private async void OnPopMenuButton_Clicked(object sender, EventArgs e)
        {
            try
            {
                await PopupNavigation.Instance.PushAsync(new PopUpPage(notekey));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}