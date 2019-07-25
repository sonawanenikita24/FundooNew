using FundooApplication.Interfaces;
using FundooApplication.Model;
using FundooApplication.Pages.DeletePopUp;
using FundooApplication.Repository;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FundooApplication.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class TrashUpdatePage : ContentPage
	{
        /// <summary>
        /// The note key
        /// </summary>
        private string noteKey;

        /// <summary>
        /// The firebase helper
        /// </summary>
        private NotesRepository firebaseHelper = new NotesRepository();

        /// <summary>
        /// Initializes a new instance of the <see cref="TrashUpdatePage"/> class.
        /// </summary>
        /// <param name="idValue">The identifier value.</param>
        public TrashUpdatePage(string idValue)
        {
            this.NoteKey = idValue;
            this.InitializeComponent();
            this.GetNote();
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
        /// Gets the note.
        /// </summary>
        public async void GetNote()
        {
            string uid = DependencyService.Get<IDatabaseInterface>().GetId();
            Note note = await this.FirebaseHelper.GetUserNote(this.NoteKey);
            NoteTitle.Text = note.Title;
            NoteText.Text = note.UserNote;
        }

        /// <summary>
        /// Menus the button clicked.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private async void MenuButtonClicked(object sender, EventArgs e)
        {
            await PopupNavigation.Instance.PushAsync(new DeleteAndRestorePopUpPage(this.NoteKey));
        }
    }
}