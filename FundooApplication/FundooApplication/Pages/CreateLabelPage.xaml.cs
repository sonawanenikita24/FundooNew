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
	public partial class CreateLabelPage : ContentPage
	{
        /// <summary>
        /// The label helper is instance of Label Helper class which is use for storing label in firebase
        /// </summary>
        private LabelRepository labelHelper = new LabelRepository();

        /// <summary>
        /// The notes repository
        /// </summary>
        private NotesRepository notesRepositorys = new NotesRepository();

        /// <summary>
        /// Gets or sets the notes repository.
        /// </summary>
        /// <value>
        /// The notes repository
        /// </value>
        public NotesRepository NotesRepositorys
        {
            get
            {
                return this.notesRepositorys;
            }

            set
            {
                this.notesRepositorys = value;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateLabelPage"/> class.
        /// </summary>
        public CreateLabelPage()
        {
            this.InitializeComponent();
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

                //// getting labels from database
                var allLabel = await this.labelHelper.GetAllLabels();

                //// store all label in list
                lstLabels.ItemsSource = allLabel;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Handles the ItemSelected event of the ListLabels control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="SelectedItemChangedEventArgs"/> instance containing the event data.</param>
        private void ListLabels_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            try
            {
                var entity = (NoteLabel)e.SelectedItem;
                var key = entity.Labelkey;
                Navigation.PushAsync(new EditLabel(key));
                ////Navigation.PushAsync(new DisplayLabelToNote(key));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Handles the Clicked event of the ImageButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private async void ImageButton_Clicked(object sender, System.EventArgs e)
        {
            try
            {
                await this.labelHelper.CreateLabel(txtLabel.Text);

                //// clear the label
                txtLabel.Text = string.Empty;

                //// getting all labels 
                var alllabel = await this.labelHelper.GetAllLabels();
                lstLabels.ItemsSource = alllabel;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Label icons the clicked.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void LabeliconClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new DisplayLabelToNote());
        }
    }
}