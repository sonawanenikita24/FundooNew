using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FundooApplication.Pages.PopUpPages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CopyPage : ContentPage
	{
        /// <summary>
        /// The note key is use as identifier
        /// </summary>
        private string notekey;

        /// <summary>
        /// Initializes a new instance of the <see cref="CopyPage"/> class.
        /// </summary>
        /// <param name="noteId">The note identifier.</param>
        public CopyPage(string noteId)
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
        /// When overridden, allows the application developer to customize behavior as the <see cref="T:Xamarin.Forms.Page" /> disappears.
        /// </summary>
        /// <remarks>
        /// To be added.
        /// </remarks>
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            //// var duplicateNote = FirebaseHelper.GetUserNote(notekey);
        }
    }
}