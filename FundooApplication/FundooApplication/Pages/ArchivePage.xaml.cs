//--------------------------------------------------------------------------------------------------------------------
// <copyright file="ArchivePage.cs" company="BridgeLabz">
// copyright @2019 
// </copyright>
// <creater name="Nikita Sonawane"/>
//------------------------------------------------------------------------------------------------------------------
namespace FundooApplication.Pages
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using FundooApplication.Model;
    using FundooApplication.Repository;
    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;
    using static FundooApplication.Model.TypeOfNote;

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ArchivePage : ContentPage
    {
        /// <summary>
        /// The firebase helper is instance of helper class
        /// </summary>
        private NotesRepository firebaseHelper = new NotesRepository();

        /// <summary>
        /// The label helper
        /// </summary>
        private LabelRepository labelHelper = new LabelRepository();

        /// <summary>
        /// Initializes a new instance of the <see cref="ArchivePage"/> class.
        /// </summary>
        public ArchivePage()
        {
            this.InitializeComponent();
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

                //// store notes for given user id
                var notes = await this.FirebaseHelper.GetAllUserNotes();

                if (notes != null)
                {
                    IList<Note> archiveNotes = new List<Note>();

                    foreach (var item in notes)
                    {
                        if (item.NoteType == NoteType.isArchive)
                        {
                            archiveNotes.Add(item);
                        }
                    }

                    //// calling to display archive method
                    await this.DisplayGridLayoutForArchiveAsync(archiveNotes);
                }
            }
            catch (Exception ex)
            {
                await this.DisplayAlert("Exception", ex.Message, "ok");
            }
        }

        /// <summary>
        /// Displays the grid layout for archive asynchronous.
        /// </summary>
        /// <param name="notes">The notes.</param>
        /// <returns>grid layout</returns>
        private async Task DisplayGridLayoutForArchiveAsync(IList<Note> notes)
        {
            var allLabels = await this.LabelHelper.GetAllLabels();
            var index = -1;
            var productIndex = 0;
            int rowCount = 0;

            try
            {
                ArchiveGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(170) });
                ArchiveGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(750) });

                for (int row = 0; row < notes.Count; row++)
                {
                    if (row % 2 == 0)
                    {
                        ArchiveGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(2, GridUnitType.Auto) });
                        rowCount++;
                    }
                }

                for (int row = 0; row < rowCount; row++)
                {
                    for (int col = 0; col < 2; col++)
                    {
                        Note note = null;
                        index++;

                        if (index < notes.Count)
                        {
                            note = notes[index];
                        }

                        if (productIndex >= notes.Count)
                        {
                            break;
                        }

                        productIndex += 1;

                        //// create label to display title
                        Label labelTitle = new Label()
                        {
                            Text = note.Title,
                            TextColor = Color.Black,
                            FontSize = 15,
                            FontAttributes = FontAttributes.Bold,
                            VerticalOptions = LayoutOptions.Center,
                            HorizontalOptions = LayoutOptions.Start
                        };

                        //// create label to set identifier to the note
                        Label labelId = new Label
                        {
                            Text = note.Key,
                            IsVisible = false
                        };

                        //// create label to display description of the notes
                        Label labelNoteDetails = new Label
                        {
                            Text = note.UserNote,
                            VerticalOptions = LayoutOptions.Center,
                            HorizontalOptions = LayoutOptions.Start,
                            TextColor = Color.DarkGray
                        };

                        //// create stacklayout
                        StackLayout stackLayout = new StackLayout() { Spacing = 2, Margin = 2 };

                        var gestureRecognizer = new TapGestureRecognizer();

                        //// add label into stacklayout
                        stackLayout.Children.Add(labelId);
                        stackLayout.Children.Add(labelTitle);
                        stackLayout.Children.Add(labelNoteDetails);

                        //// add gestureRecognizer into stacklayout
                        stackLayout.GestureRecognizers.Add(gestureRecognizer);

                        //// now take new frame and add stacklayout into that frame
                        var frame = new Frame
                        {
                            BorderColor = Color.Black,
                            Content = stackLayout
                        };

                        gestureRecognizer.Tapped += (object sender, EventArgs e) =>
                        {
                            StackLayout stack = (StackLayout)sender;
                            IList<View> itemList = stack.Children;
                            Label id = (Label)itemList[0];
                            var noteid = id.Text;
                            Navigation.PushAsync(new EditNote(noteid));
                        };

                        ArchiveGrid.Children.Add(frame, col, row);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Called when [back button pressed].
        /// </summary>
        /// <returns></returns>
        protected override bool OnBackButtonPressed()
        {
            DisplayAlert("Alert", "Please logout first from app", "Ok");

            ////go to Edit page with that note id
            Navigation.PushAsync(new LogoutPage());
            return base.OnBackButtonPressed();
        }
    }
}