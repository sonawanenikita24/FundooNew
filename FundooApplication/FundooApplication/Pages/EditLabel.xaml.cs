using Firebase.Database;
using FundooApplication.Interfaces;
using FundooApplication.Model;
using FundooApplication.Repository;
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
	public partial class EditLabel : ContentPage
	{
        /// <summary>
        /// The label helper
        /// </summary>
        private LabelRepository labelHelper = new LabelRepository();

        /// <summary>
        /// The key lab
        /// </summary>
        private string keyLab = string.Empty;

        /// <summary>
        /// The firebase
        /// </summary>
        private FirebaseClient firebase = new FirebaseClient("https://user-9206e.firebaseio.com/");

        /// <summary>
        /// Initializes a new instance of the <see cref="EditLabel"/> class.
        /// </summary>
        /// <param name="value">The value.</param>
        public EditLabel(string value)
        {
            this.keyLab = value;
            this.UpdateLabel();
            this.InitializeComponent();
        }

        /// <summary>
        /// Gets or sets the label helper.
        /// </summary>
        /// <value>
        /// The label helper.
        /// </value>
        public LabelRepository LabelHelper
        {
            get
            {
                return this.labelHelper;
            }

            set
            {
                this.labelHelper = value;
            }
        }

        /// <summary>
        /// Gets or sets the firebase.
        /// </summary>
        /// <value>
        /// The firebase.
        /// </value>
        public FirebaseClient Firebase
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
        /// Updates the label.
        /// </summary>
        public async void UpdateLabel()
        {
            var userid = DependencyService.Get<IDatabaseInterface>().GetId();
            NoteLabel noteLabel = await this.LabelHelper.GetLabel(this.keyLab);
            txtLabel.Text = noteLabel.Noteslabel;
        }

        /// <summary>
        /// Labels the edits.
        /// </summary>
        public void LabelEdits()
        {
            var userid = DependencyService.Get<IDatabaseInterface>().GetId();

            NoteLabel labelNotes = new NoteLabel()
            {
                Noteslabel = txtLabel.Text
            };
            this.LabelHelper.UpdateLabel(labelNotes, this.keyLab);
        }

        /// <summary>
        /// When overridden, allows application developers to customize behavior immediately prior to the <see cref="T:Xamarin.Forms.Page" /> becoming visible.
        /// </summary>
        /// <remarks>
        /// To be added.
        /// </remarks>
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            var alllabels = await this.LabelHelper.GetAllLabels();
            lstLabels.ItemsSource = alllabels;
        }

        /// <summary>
        /// Application developers can override this method to provide behavior when the back button is pressed.
        /// </summary>
        /// <returns>
        /// return back to previous page 
        /// </returns>
        /// <remarks>
        /// To be added.
        /// </remarks>
        protected override bool OnBackButtonPressed()
        {
            return base.OnBackButtonPressed();
        }

        /// <summary>
        /// Handles the Clicked event of the Deleted labels control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void Deletedlabels_Clicked(object sender, EventArgs e)
        {
            this.LabelEdits();
            Navigation.RemovePage(this);
        }

        /// <summary>
        /// Handles the Clicked event of the ImageButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void ImageButton_Clicked(object sender, EventArgs e)
        {
            this.LabelEdits();
            Navigation.RemovePage(this);
        }

        /// <summary>
        /// Handles the Clicked event of the Delete labels control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void Deletelabels_Clicked(object sender, EventArgs e)
        {
            var userid = DependencyService.Get<IDatabaseInterface>().GetId();
            txtLabel.Text = null;
            this.LabelHelper.DeleteLabel(this.keyLab);
            Navigation.RemovePage(this);
        }
    }
}