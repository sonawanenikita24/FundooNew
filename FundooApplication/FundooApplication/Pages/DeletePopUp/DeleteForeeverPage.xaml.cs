using FundooApplication.Interfaces;
using FundooApplication.Repository;
using Plugin.Toast;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FundooApplication.Pages.DeletePopUp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DeleteForeeverPage : ContentPage
	{
        /// <summary>
        /// The note key
        /// </summary>
        private string notekey;

        /// <summary>
        /// The helper is instance of firebase helper class to access database
        /// </summary>
        private NotesRepository firebase = new NotesRepository();

        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteForeeverPage"/> class.
        /// </summary>
        /// <param name="notekey">The note key.</param>
        public DeleteForeeverPage(string notekey)
        {
            this.Notekey = notekey;
            this.InitializeComponent();
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
        /// Gets or sets the firebase.
        /// </summary>
        /// <value>
        /// The firebase.
        /// </value>
        public NotesRepository Firebase
        {
            get
            {
                return this.firebase;
            }

            set
            {
                this.firebase = value;
            }
        }

        /// <summary>
        /// When overridden, allows application developers to customize behavior immediately prior to the <see cref="T:Xamarin.Forms.Page" /> becoming visible.
        /// </summary>
        /// <remarks>
        /// To be added.
        /// </remarks>
        protected async override void OnAppearing()
        {
            try
            {
                base.OnAppearing();
                var uid = DependencyService.Get<IDatabaseInterface>().GetId();
                await this.Firebase.DeleteNote(this.notekey, uid);
                CrossToastPopUp.Current.ShowToastMessage("Note is deleted");
                await Navigation.PushModalAsync(new DashBoard());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}