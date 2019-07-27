//--------------------------------------------------------------------------------------------------------------------
// <copyright file="CreateCollaborator.cs" company="BridgeLabz">
// copyright @2019 
// </copyright>
// <creater name="Nikita Sonawane"/>
//------------------------------------------------------------------------------------------------------------------
namespace FundooApplication.Pages
{
    using System;
    using System.Collections.ObjectModel;
    using Firebase.Database;
    using FundooApplication.Model;
    using FundooApplication.Repository;
    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CreateCollaborator : ContentPage
    {
        /// <summary>
        /// The value
        /// </summary>
        private string value = null;

        /// <summary>
        /// The notes repository instance of note repository
        /// </summary>
        private NotesRepository notesRepository = new NotesRepository();

        /// <summary>
        /// The sources
        /// </summary>
        private ObservableCollection<string> sources = new ObservableCollection<string>();

        /// <summary>
        /// The identifier
        /// </summary>
        private string id1 = null;

        /// <summary>
        /// The firebase
        /// </summary>
        public FirebaseClient firebase = new FirebaseClient("https://user-9206e.firebaseio.com/");

        /// <summary>
        /// The label helper is instance of Label Helper class which is use for storing label in firebase
        /// </summary>
        private CollaboratorRepository repo = new CollaboratorRepository();

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>
        /// The value.
        /// </value>
        public string Value
        {
            get
            {
                return this.value;
            }

            set
            {
                this.value = value;
            }
        }

        /// <summary>
        /// Gets or sets the notes repository.
        /// </summary>
        /// <value>
        /// The notes repository.
        /// </value>
        public NotesRepository NotesRepository
        {
            get
            {
                return this.notesRepository;
            }

            set
            {
                this.notesRepository = value;
            }
        }

        /// <summary>
        /// Gets or sets the sources.
        /// </summary>
        /// <value>
        /// The sources.
        /// </value>
        public ObservableCollection<string> Sources
        {
            get
            {
                return this.sources;
            }

            set
            {
                this.sources = value;
            }
        }

        /// <summary>
        /// Gets or sets the id1.
        /// </summary>
        /// <value>
        /// The id1.
        /// </value>
        public string Id1
        {
            get
            {
                return this.id1;
            }

            set
            {
                this.id1 = value;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateCollaborator"/> class.
        /// </summary>
        /// <param name="key">The key.</param>
        public CreateCollaborator(string key)
        {
            InitializeComponent();
            this.Value = key;
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
                var allLabel = await this.repo.GetAllcollaborators();

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
                var entity = (CollaboratorMadel)e.SelectedItem;
                var key = entity.CKey;
                // Navigation.PushAsync(new EditCollaborators(key));
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
                await this.repo.CreateCollaborator(txtLabel.Text);

                //// clear the label
                txtLabel.Text = string.Empty;

                //// getting all labels 
                var alllabel = await this.repo.GetAllcollaborators();
                lstLabels.ItemsSource = alllabel;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}