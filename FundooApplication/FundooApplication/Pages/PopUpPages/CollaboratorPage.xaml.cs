//--------------------------------------------------------------------------------------------------------------------
// <copyright file="CollaboratorPage.cs" company="BridgeLabz">
// copyright @2019 
// </copyright>
// <creater name="Nikita Sonawane"/>
//------------------------------------------------------------------------------------------------------------------
namespace FundooApplication.Pages.PopUpPages
{
    using System.Collections.ObjectModel;
    using Firebase.Database;
    using Firebase.Database.Query;
    using FundooApplication.Interfaces;
    using FundooApplication.Model;
    using FundooApplication.Repository;
    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CollaboratorPage : ContentPage
    {
        /// <summary>
        /// The notes repository instance of note repository
        /// </summary>
        public NotesRepository notesRepository = new NotesRepository();

        /// <summary>
        /// The identifier
        /// </summary>
        public string id = null;

        /// <summary>
        /// The value
        /// </summary>
        public string value = null;

        /// <summary>
        /// The tap gesture is instance of gesture recognizer 
        /// </summary>
        public TapGestureRecognizer tapgester = new TapGestureRecognizer();

        /// <summary>
        /// The source is observable collection of string
        /// </summary>
        public ObservableCollection<string> source = new ObservableCollection<string>();

        /// <summary>
        /// The firebase is instance of firebase client to store path of database
        /// </summary>
        public FirebaseClient firebase = new FirebaseClient("https://fundooapplication-f0d55.firebaseio.com/");

        /// <summary>
        /// Initializes a new instance of the <see cref="CollaboratorPage"/> class.
        /// </summary>
        /// <param name="key">The key.</param>
        public CollaboratorPage(string key)
        {
            InitializeComponent();

            txtMail.ItemsSource = source;
            Data();

            this.value = key;

            //// when save button  clicked
            var savenote = new TapGestureRecognizer();
            savenote.Tapped += Savenote_Tapped;
            savebtn.GestureRecognizers.Add(savenote);

            this.Tapgesterrec();
        }

        /// <summary>
        /// Tap gesture recognizer this instance.
        /// </summary>
        public void Tapgesterrec()
        {
            tapgester.Tapped += Tapgester_Tapped;
            exit.GestureRecognizers.Add(tapgester);
        }

        /// <summary>
        /// for getting user detail from database
        /// </summary>
        public async void Data()
        {
            var users = await firebase.Child("User").OnceAsync<RegisterUser>();

            string uid = DependencyService.Get<IDatabaseInterface>().GetId();

            foreach (var items in users)
            {
                if (items.ToString() != uid)
                {
                    var email = await firebase.Child("Users").Child(items.Key).Child("User Information").OnceAsync<RegisterUser>();
                    foreach (var item in email)
                    {
                        var emailDetails = item.Object.UserName;
                        //// var emailId = item.Key;
                        source.Add(emailDetails);
                    }
                }
            }
        }

        /// <summary>
        /// Handles the Tapped event of the tap gesture recognizer control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void Tapgester_Tapped(object sender, System.EventArgs e)
        {
            DisplayAlert("hello", "exit", "ok");
            txtMail.Text = string.Empty;
            Navigation.PushModalAsync(new EditNote(this.value));
        }

        /// <summary>
        /// Handles the Tapped event of the Save note control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void Savenote_Tapped(object sender, System.EventArgs e)
        {
            DisplayAlert("hello", "thisnote", "ok");
        }

        /// <summary>
        /// Handles the Clicked event of the Save button control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private async void Savebtn_Clicked(object sender, System.EventArgs e)
        {
            var users = await firebase.Child("Users").OnceAsync<RegisterUser>();

            string uid = DependencyService.Get<IDatabaseInterface>().GetId();

            foreach (var items in users)
            {
                if (items.ToString() != uid)
                {
                    var email = await firebase.Child("Users").Child(items.Key).Child("User Information").OnceAsync<RegisterUser>();
                    foreach (var item in email)
                    {
                        var emailDetails = item.Object.UserName;

                        id = items.Key;
                        if (txtMail.Text == emailDetails)
                        {
                            Note notes = await notesRepository.GetNoteByNoteId(this.value, uid);

                            notes = new Note()
                            {
                                Title = notes.Title,
                                UserNote = notes.UserNote,
                                NoteColor = notes.NoteColor,
                                NoteType = notes.NoteType
                            };

                            await firebase.Child("Users").Child(this.id).Child("UserNotes").Child(value).PutAsync(new Note()
                            {
                                Title = notes.Title,
                                UserNote = notes.UserNote,
                                NoteColor = notes.NoteColor,
                                NoteType = notes.NoteType

                            });
                            await firebase.Child("Users").Child(uid).Child("UserNotes").Child(value).PutAsync(new Note()
                            {
                                Title = notes.Title,
                                UserNote = notes.UserNote,
                                NoteColor = notes.NoteColor,
                                NoteType = notes.NoteType
                            });
                            ////source.Add(emailDetails);
                        }
                    }
                }
            }

            await Navigation.PushModalAsync(new NavigationPage(new EditNote(this.value)));
        }
    }
}