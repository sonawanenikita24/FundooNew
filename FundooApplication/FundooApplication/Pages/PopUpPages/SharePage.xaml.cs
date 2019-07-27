//--------------------------------------------------------------------------------------------------------------------
// <copyright file="SharePage.cs" company="BridgeLabz">
// copyright @2019 
// </copyright>
// <creater name="Nikita Sonawane"/>
//------------------------------------------------------------------------------------------------------------------
namespace FundooApplication.Pages.PopUpPages
{
    using System.Threading.Tasks;
    using FundooApplication.Model;
    using FundooApplication.Repository;
    using Xamarin.Essentials;
    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SharePage : ContentPage
    {
        /// <summary>
        /// The note key
        /// </summary>
        private string notekey;

        /// <summary>
        /// The firebase helper
        /// </summary>
        private NotesRepository firebasehelper = new NotesRepository();

        /// <summary>
        /// Initializes a new instance of the <see cref="SharePage"/> class.
        /// </summary>
        /// <param name="noteId">The note identifier.</param>
        public SharePage(string noteId)
        {
            this.InitializeComponent();
            this.Notekey = noteId;
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
        /// Gets or sets the firebase helper.
        /// </summary>
        /// <value>
        /// The firebase helper.
        /// </value>
        public NotesRepository Firebasehelper
        {
            get
            {
                return this.firebasehelper;
            }

            set
            {
                this.firebasehelper = value;
            }
        }

        /// <summary>
        /// Shares the text.
        /// </summary>
        /// <param name="note">The note.</param>
        /// <returns>share note with another</returns>
        public async Task ShareText(Note note)
        {
            ////var notes = await this.Firebasehelper.GetUserNote(this.Notekey);

            await Share.RequestAsync(new ShareTextRequest
            {
                Text = note.Title,
                Subject = note.UserNote
            });
        }

        /// <summary>
        /// When overridden, allows application developers to customize behavior immediately prior to the <see cref="T:Xamarin.Forms.Page" /> becoming visible.
        /// </summary>
        /// <remarks>
        /// To be added.
        /// </remarks>
        protected async override void OnAppearing()
        {
            var notes = await this.Firebasehelper.GetUserNote(this.Notekey);
            base.OnAppearing();
            await this.ShareText(notes);
        }

        /// <summary>
        /// Application developers can override this method to provide behavior when the back button is pressed.
        /// </summary>
        /// <returns>
        /// return to base page 
        /// </returns>
        /// <remarks>
        /// To be added.
        /// </remarks>
        protected override bool OnBackButtonPressed()
        {
            return base.OnBackButtonPressed();
        }
    }
}