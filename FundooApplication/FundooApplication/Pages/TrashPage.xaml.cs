//--------------------------------------------------------------------------------------------------------------------
// <copyright file="TrashPage.cs" company="BridgeLabz">
// copyright @2019 
// </copyright>
// <creater name="Nikita Sonawane"/>
//------------------------------------------------------------------------------------------------------------------
namespace FundooApplication.Pages
{
    using FundooApplication.Model;
    using FundooApplication.Repository;
    using System;
    using System.Collections.Generic;
    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;
    using static FundooApplication.Model.TypeOfNote;

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TrashPage : ContentPage
    {
        /// <summary>
        /// The firebase helper in instance of firebase helper class to get access of database
        /// </summary>
        private NotesRepository firebaseHelp = new NotesRepository();

        /// <summary>
        /// The label helper instance of label helper class to get labels from database
        /// </summary>
        private LabelRepository labelHelper = new LabelRepository();

        /// <summary>
        /// Initializes a new instance of the <see cref="TrashPage"/> class.
        /// </summary>
        public TrashPage()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Gets or sets the firebase helper.
        /// </summary>
        /// <value>
        /// The firebase helper.
        /// </value>
        public NotesRepository FirebaseHelp
        {
            get
            {
                return this.firebaseHelp;
            }

            set
            {
                this.firebaseHelp = value;
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
                IList<Note> trashedList = new List<Note>();

                //// get all usernotes
                var allnotes = await FirebaseHelp.GetAllUserNotes();

                if (allnotes != null)
                {
                    foreach (var item in allnotes)
                    {
                        if (item.NoteType == NoteType.isTrash)
                        {
                            trashedList.Add(item);
                        }
                    }

                    //// Display note in grid view
                    this.TrashedNoteGrid(trashedList);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Archive the note grid.
        /// </summary>
        /// <param name="notes">All notes.</param>
        private void TrashedNoteGrid(IList<Note> notes)
        {
            ////  var allLabels = await this.labelHelper.GetAllLabels();
            var index = -1;
            var productIndex = 0;
            try
            {
                //// for adding column
                TrashGridLayout.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(170) });
                TrashGridLayout.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(170) });

                int numberOfRows = 0;

                for (int row = 0; row < notes.Count; row++)
                {
                    if (row % 2 == 0)
                    {
                        TrashGridLayout.RowDefinitions.Add(new RowDefinition { Height = new GridLength(2, GridUnitType.Auto) });
                        numberOfRows++;
                    }
                }

                for (int row = 0; row < 2; row++)
                {
                    for (int column = 0; column < 2; column++)
                    {
                        Note notedata = null;
                        index++;

                        if (index < notes.Count)
                        {
                            notedata = notes[index];
                        }

                        if (productIndex >= notes.Count)
                        {
                            break;
                        }

                        productIndex += 1;

                        //// label for title
                        var labelTitle = new Label
                        {
                            Text = notedata.Title,
                            TextColor = Color.Black,
                            FontSize = 15,
                            FontAttributes = FontAttributes.Bold,
                            VerticalOptions = LayoutOptions.Center,
                            HorizontalOptions = LayoutOptions.Start
                        };

                        //// adding label for identifier
                        var labelId = new Label
                        {
                            Text = notedata.Key,
                            IsVisible = false
                        };

                        ////adding for user note
                        var labelUserNote = new Label
                        {
                            Text = notedata.UserNote,
                            VerticalOptions = LayoutOptions.Center,
                            HorizontalOptions = LayoutOptions.Start,
                            TextColor = Color.DarkGray
                        };

                        //// create stacklayout
                        StackLayout stackLayout = new StackLayout() { Spacing = 2, Margin = 2 };

                        //// add labels into stacklayout
                        stackLayout.Children.Add(labelId);
                        stackLayout.Children.Add(labelTitle);
                        stackLayout.Children.Add(labelUserNote);

                        //// craete instance 
                        var tapGestureRecognizer = new TapGestureRecognizer();

                        //// add into stacklayout
                        stackLayout.GestureRecognizers.Add(tapGestureRecognizer);

                        //// create frame and add into  stacklayout 
                        var frame = new Frame
                        {
                            BorderColor = Color.DarkGray,
                            Content = stackLayout
                        };
                        BackgroundColor = notedata.NoteColor;

                        tapGestureRecognizer.Tapped += (object sender, EventArgs e) =>
                        {
                            StackLayout layout = (StackLayout)sender;

                            //// add the tapped notes data into the list
                            IList<View> item = layout.Children;

                            //// take the id of that note
                            Label id = (Label)item[0];
                            var idValue = id.Text;

                            Navigation.PushAsync(new NavigationPage(new TrashUpdatePage(idValue)));
                        };
                        TrashGridLayout.Children.Add(frame, column, row);
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