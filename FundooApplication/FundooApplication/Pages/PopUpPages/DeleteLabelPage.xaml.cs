//--------------------------------------------------------------------------------------------------------------------
// <copyright file="DeleteLabelPage.cs" company="BridgeLabz">
// copyright @2019 
// </copyright>
// <creater name="Nikita Sonawane"/>
//------------------------------------------------------------------------------------------------------------------
namespace FundooApplication.Pages.PopUpPages
{
    using System;
    using FundooApplication.Interfaces;
    using FundooApplication.Model;
    using FundooApplication.Repository;
    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DeleteLabelPage : ContentPage
    {
        /// <summary>
        /// The user id
        /// </summary>
        private string uid = DependencyService.Get<IDatabaseInterface>().GetId();

        /// <summary>
        /// firebase helper
        /// </summary>
        private NotesRepository notesRepository = new NotesRepository();

        /// <summary>
        /// The note key
        /// </summary>
        private string noteKey = string.Empty;

        /// <summary>
        /// The firebase data label helper
        /// </summary>
        private LabelRepository firebasedata = new LabelRepository();

        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteLabelPage"/> class.
        /// </summary>
        /// <param name="labelkeys">The label keys.</param>
        public DeleteLabelPage(string labelkeys)
        {
            this.NoteKey = labelkeys;
            this.InitializeComponent();
        }

        /// <summary>
        /// Gets or sets the user id.
        /// </summary>
        /// <value>
        /// The user id.
        /// </value>
        public string Uid
        {
            get
            {
                return this.uid;
            }

            set
            {
                this.uid = value;
            }
        }

        /// <summary>
        /// Gets or sets the firebase data.
        /// </summary>
        /// <value>
        /// The firebase data.
        /// </value>
        public LabelRepository Firebasedata
        {
            get
            {
                return this.firebasedata;
            }

            set
            {
                this.firebasedata = value;
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
                var alllabels = await this.Firebasedata.GetAllLabels();
                lstLabels.ItemsSource = alllabels;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Application developers can override this method to provide behavior when the back button is pressed.
        /// </summary>
        /// <returns>
        /// to main page
        /// </returns>
        /// <remarks>
        /// To be added.
        /// </remarks>
        protected override bool OnBackButtonPressed()
        {
            return base.OnBackButtonPressed();
        }

        /// <summary>
        /// Handles the 1 event of the CheckBox_CheckChanged control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void CheckBox_CheckChanged_1(object sender, EventArgs e)
        {
            //// string status = ((Plugin.InputKit.Shared.Controls.CheckBox)sender).Text;

            var checkbox = (Plugin.InputKit.Shared.Controls.CheckBox)sender;

            if (checkbox.IsChecked)
            {
                checkbox.Color = Color.Black;
            }
        }

        /// <summary>
        /// Handles the ItemSelected event of the List Label control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="SelectedItemChangedEventArgs"/> instance containing the event data.</param>
        private async void LstLabel_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var entity = (NoteLabel)e.SelectedItem;
            var key = entity.Labelkey;

            //// get note by note id
            var getnote = await this.NotesRepository.GetNoteByNoteId(this.NoteKey, Uid);
            getnote.LabelsList.Add(key);
            getnote.LabelsList.Remove(key);
            Note note = new Note()
            {
                Title = getnote.Title,
                UserNote = getnote.UserNote,
                NoteColor = getnote.NoteColor
            };

            this.Firebasedata.DeleteLabelsFromNotes(note, this.NoteKey);
            //// this.Firebasedata.UpdateLabelsToNotes(note, this.NoteKey);
            await Navigation.PushAsync(new EditNote(this.NoteKey));
        }
    }
}