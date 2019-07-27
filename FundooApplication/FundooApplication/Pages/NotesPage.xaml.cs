//--------------------------------------------------------------------------------------------------------------------
// <copyright file="NotesPage.cs" company="BridgeLabz">
// copyright @2019 
// </copyright>
// <creater name="Nikita Sonawane"/>
//------------------------------------------------------------------------------------------------------------------
namespace FundooApplication.Pages
{
    using System;
    using System.Collections.Generic;
    using FundooApplication.Model;
    using FundooApplication.Repository;
    using FundooApplication.ViewModels;
    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;
    using static FundooApplication.Model.TypeOfNote;

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NotesPage : ContentPage
    {
        /// <summary>
        /// The x,y
        /// </summary>
        public double X, Y;

        /// <summary>
        /// Gets or sets the color notes.
        /// </summary>
        /// <value>
        /// The color notes.
        /// </value>
        public Color ColorNotes { get; set; }

        /// <summary>
        /// The note back ground color
        /// </summary>
        public Color noteBackGroundColor;

        /// <summary>
        /// image source
        /// </summary>
        public ImageSource profileImage;

        /// <summary>
        /// The helper is instance of firebase helper class to add data into the database
        /// </summary>
        private NotesRepository helper = new NotesRepository();

        /// <summary>
        /// The label helper is instance of helper class 
        /// </summary>
        private LabelRepository labelHelper = new LabelRepository();

        /// <summary>
        /// The collaborators repo
        /// </summary>
        private CollaboratorRepository collaboratorsRepo = new CollaboratorRepository();

        /// <summary>
        /// Initializes a new instance of the <see cref="NotesPage"/> class.
        /// </summary>
        public NotesPage()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Gets or sets the helper.
        /// </summary>
        /// <value>
        /// The helper.
        /// </value>
        public NotesRepository Helper
        {
            get
            {
                return this.helper;
            }

            set
            {
                this.helper = value;
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
        /// Gets or sets the collaborators repo.
        /// </summary>
        /// <value>
        /// The collaborators repo.
        /// </value>
        public CollaboratorRepository CollaboratorRepo
        {
            get
            {
                return this.collaboratorsRepo;
            }

            set
            {
                this.collaboratorsRepo = value;
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

                IList<Note> pinnedList = new List<Note>();
                IList<Note> otherList = new List<Note>();

                //// getting all notes
                var notes = await this.Helper.GetAllUserNotes();

                if (notes != null)
                {
                    //// for pinned notes
                    foreach (var item in notes)
                    {
                        if (item.NoteType == NoteType.ispin)
                        {
                            pinnedList.Add(item);
                        }
                    }

                    this.NoteGridPinned(pinnedList);

                    //// other type note
                    foreach (var item in notes)
                    {
                        if (item.NoteType == NoteType.isNote)
                        {
                            otherList.Add(item);
                        }
                    }

                    //// count total notes 
                    Pinned.Text = "PINNED : " + pinnedList.Count;
                    OTHERS.Text = "OTHERS : " + otherList.Count;

                    //// store in grid
                    this.NoteGridForOthers(otherList);
                }

                ////Get user profile image 
                UserRepository userRepository = new UserRepository();
                RegisterUser user = await userRepository.GetRegisterUserById();
                if (user.Imageurl != null)
                {
                    this.profileImage = user.Imageurl;
                    profile.IconImageSource = profileImage;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// handle the event of create note tapped.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void CreateNoteTapped(object sender, EventArgs e)
        {
            try
            {
                //// navigate to note create page
                Navigation.PushModalAsync(new NoteCreation());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        /// <summary>
        /// Notes the grid for others.
        /// </summary>
        /// <param name="otherList">The other list.</param>
        private async void NoteGridForOthers(IList<Note> otherList)
        {
            var allLabels = await this.LabelHelper.GetAllLabels();
            var allCollaboratos = await this.CollaboratorRepo.GetAllcollaborators();
            var index = -1;

            try
            {
                //// for arranging two notes in one single row
                OthersGridLayout.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(170) });
                OthersGridLayout.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(170) });
                OthersGridLayout.Margin = 5;
                //// to count rows
                int rows = 0;

                //// when notes are added in single row then create new row definitions
                for (int rowindex = 0; rowindex < otherList.Count; rowindex++)
                {
                    if (rowindex % 2 == 0)
                    {
                        //// add row
                        OthersGridLayout.RowDefinitions.Add(new RowDefinition { Height = new GridLength(2, GridUnitType.Auto) });

                        //// increment row count
                        rows++;
                    }
                }

                for (int rowindex = 0; rowindex < rows; rowindex++)
                {
                    for (int colindex = 0; colindex < 2; colindex++)
                    {
                        Note notedata = null;
                        index++;

                        if (index < otherList.Count)
                        {
                            notedata = otherList[index];
                        }

                        //// add new label to the title 
                        var labelTitle = new Label
                        {
                            Text = notedata.Title,
                            TextColor = Color.Black,
                            FontAttributes = FontAttributes.Bold,
                            FontSize = 15,
                            VerticalOptions = LayoutOptions.Center,
                            HorizontalOptions = LayoutOptions.Start,
                        };

                        //// create new label to set identifier
                        var labelId = new Label
                        {
                            Text = notedata.Key,
                            IsVisible = false
                        };

                        //// create the label to display the detail of note 
                        var labelUserNote = new Label
                        {
                            Text = notedata.UserNote,
                            TextColor = Color.Black,
                            VerticalOptions = LayoutOptions.Start,
                            HorizontalOptions = LayoutOptions.Start,
                        };



                        //// add stacklayout
                        StackLayout stackLayout = new StackLayout()
                        {
                            Spacing = 2,
                            Margin = 2,
                            BackgroundColor = notedata.NoteColor
                        };

                        //// add labels into stacklayout
                        stackLayout.Children.Add(labelId);
                        stackLayout.Children.Add(labelTitle);
                        stackLayout.Children.Add(labelUserNote);

                        //// create instance
                        var tapGestureRecognizer = new TapGestureRecognizer();

                        //// adding instance of recognizer into stacklayout
                        stackLayout.GestureRecognizers.Add(tapGestureRecognizer);

                        //// create frame
                        var frame = new Frame
                        {
                            BorderColor = Color.DarkGray,
                            Content = stackLayout,
                            BackgroundColor = notedata.NoteColor
                        };
                        //BackgroundColor=FrameColorSetter.GetColor(notedata, frame);

                        //// add label into note
                        foreach (NoteLabel model in allLabels)
                        {
                            IList<string> lists = notedata.LabelsList;
                            foreach (var labelsid in lists)
                            {
                                if (model.Labelkey.Equals(labelsid))
                                {
                                    var labelName = new Label
                                    {
                                        Text = model.Noteslabel,
                                        HorizontalOptions = LayoutOptions.Center,
                                        VerticalOptions = LayoutOptions.Start,
                                        FontSize = 11
                                    };
                                    var labelFrame = new Frame
                                    {
                                        CornerRadius = 28,
                                        HeightRequest = 14,
                                        Content = labelName,
                                        BorderColor = Color.Gray,
                                        BackgroundColor = Color.FromHex(FrameColorSetter.GetHexColor(notedata))
                                    };
                                    ////labelFrame.BackgroundColor = Color.White;
                                    stackLayout.Children.Add(labelFrame);
                                }
                            }
                        }

                        /*   foreach (CollaboratorMadel model in allCollaboratos)
                           {
                               IList<string> lists = notedata.CollaboratosList;
                               foreach (var collboratorid in lists)
                               {
                                   if (model.CKey.Equals(collboratorid))
                                   {
                                       var imagebutton = new ImageButton()
                                       {
                                           Source = "Accountphoto.png",
                                           VerticalOptions = LayoutOptions.Start,
                                           HorizontalOptions = LayoutOptions.Start
                                       };
                                       var labelFrame1 = new Frame
                                       {
                                           Content = imagebutton,
                                           BorderColor = Color.Gray,
                                           BackgroundColor = Color.FromHex(FrameColorSetter.GetHexColor(notedata))
                                       };
                                       ////labelFrame1.BackgroundColor = Color.White;
                                       stackLayout.Children.Add(labelFrame1);
                                   }
                               }
                           }*/

                        //// clicked event for note which is display onto another new page
                        tapGestureRecognizer.Tapped += (object sender, EventArgs e) =>
                        {
                            StackLayout layout = (StackLayout)sender;

                            ////Add the tapped notes into list
                            IList<View> item = layout.Children;

                            //// taking id of the note
                            Label labelid = (Label)item[0];
                            var idValue = labelid.Text;

                            //// move to the edit page with given id
                            Navigation.PushAsync(new EditNote(idValue));
                        };

                        OthersGridLayout.Children.Add(frame, colindex, rowindex);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Note in the grid fir pinned note.
        /// </summary>
        /// <param name="pinnedList">The pinned list.</param>
        private void NoteGridPinned(IList<Note> pinnedList)
        {
            var index = -1;
            try
            {
                PinnedGridLayout.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(170) });
                PinnedGridLayout.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(170) });
                PinnedGridLayout.Margin = 5;
                ////to count Number of rows
                int numberOfRows = 0;

                ////when two notes in single row create new row definition
                for (int rowIndex = 0; rowIndex < pinnedList.Count; rowIndex++)
                {
                    if (rowIndex % 2 == 0)
                    {
                        PinnedGridLayout.RowDefinitions.Add(new RowDefinition { Height = new GridLength(2, GridUnitType.Auto) });

                        ////When added increment the number of rows
                        numberOfRows++;
                    }
                }

                ////Set the note data into the  model note instance 
                for (int rowIndex = 0; rowIndex < numberOfRows; rowIndex++)
                {
                    for (int columnIndex = 0; columnIndex < 2; columnIndex++)
                    {
                        Note noteData = null;
                        index++;
                        if (index < pinnedList.Count)
                        {
                            noteData = pinnedList[index];
                        }

                        ////Create label to display the Title onto the page
                        var labelTitle = new Label
                        {
                            Text = noteData.Title,
                            TextColor = Color.Black,
                            FontSize = 12,
                            FontAttributes = FontAttributes.Bold,
                            VerticalOptions = LayoutOptions.Center,
                            HorizontalOptions = LayoutOptions.Start
                        };

                        ////Create label to set the identifier of the note
                        var labelId = new Label
                        {
                            Text = noteData.Key,
                            IsVisible = false
                        };

                        ////Create label to display the Content of the note onto the page
                        var labelUserNote = new Label
                        {
                            Text = noteData.UserNote,
                            VerticalOptions = LayoutOptions.Center,
                            HorizontalOptions = LayoutOptions.Start
                        };

                        ////Stacklayout 
                        StackLayout stackLayout = new StackLayout() { Spacing = 2, Margin = 2, BackgroundColor = noteData.NoteColor };

                        ////add labels to the stacklayout
                        stackLayout.Children.Add(labelId);
                        stackLayout.Children.Add(labelTitle);
                        stackLayout.Children.Add(labelUserNote);
                        ////Create instance of Tap Gesture REcognizer
                        var tapGestureRecognizer = new TapGestureRecognizer();

                        ////Add gesture recognizer to the stacklayout
                        stackLayout.GestureRecognizers.Add(tapGestureRecognizer);

                        ////create the frame and add the stacklayout to that frame
                        var frame = new Frame
                        {
                            BorderColor = Color.DarkGray,
                            Content = stackLayout,
                            BackgroundColor = noteData.NoteColor
                        };
                        // FrameColorSetter.GetColor(noteData, frame);

                        ////When tapped onto the note it moves to the new page which display that note
                        tapGestureRecognizer.Tapped += (object sender, EventArgs e) =>
                        {
                            StackLayout layout = (StackLayout)sender;

                            ////Add the Tapped notes data into the list
                            IList<View> item = layout.Children;

                            ////Take the id of that note
                            Label id = (Label)item[0];
                            var idValue = id.Text;

                            ////go to Edit page with that note id
                            Navigation.PushAsync(new EditNote(idValue));
                        };

                        ////Add the notes to the gridlayout
                        PinnedGridLayout.Children.Add(frame, columnIndex, rowIndex);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Handles the Clicked event of the SearchNote control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private async void SearchNote_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SearchNote());
        }

        /// <summary>
        /// Profiles the clicked.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private async void ProfileClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new GalleryPermission());
        }

        /// <summary>
        /// Called when [pan updated].
        /// </summary> 
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="PanUpdatedEventArgs"/> instance containing the event data.</param>
        void OnPanUpdated(object sender, PanUpdatedEventArgs e)
        {
            switch (e.StatusType)
            {
                case GestureStatus.Running:
                    //// Translate and ensure we don't pan beyond the wrapped user interface element bounds.
                    Content.TranslationX = Math.Max(Math.Min(0, this.X + e.TotalX), -Math.Abs(Content.Width - App.ScreenWidth));
                    Content.TranslationY = Math.Max(Math.Min(0, this.Y + e.TotalY), -Math.Abs(Content.Height - App.ScreenHeight));
                    break;

                case GestureStatus.Completed:
                    //// Store the translation applied during the pan
                    this.X = Content.TranslationX;
                    this.Y = Content.TranslationY;
                    break;
            }
        }

        protected override bool OnBackButtonPressed()
        {
            DisplayAlert("Alert", "Please logout first from app", "Ok");

            ////go to Edit page with that note id
            Navigation.PushAsync(new LogoutPage());
            return base.OnBackButtonPressed();
        }
    }
}