//--------------------------------------------------------------------------------------------------------------------
// <copyright file="EditNote.cs" company="BridgeLabz">
// copyright @2019 
// </copyright>
// <creater name="Nikita Sonawane"/>
//------------------------------------------------------------------------------------------------------------------
namespace FundooApplication.Pages
{
    using System;
    using System.Collections.Generic;
    using FundooApplication.Interfaces;
    using FundooApplication.Model;
    using FundooApplication.Pages.PlusPopUp;
    using FundooApplication.Pages.PopUpPages;
    using FundooApplication.Repository;
    using FundooApplication.ViewModels;
    using Rg.Plugins.Popup.Services;
    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;
    using static FundooApplication.Model.TypeOfNote;
    using Plugin.Toast;

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditNote : ContentPage
    {
        /// <summary>
        /// The helper
        /// </summary>
        private NotesRepository firebaseHelperVar = new NotesRepository();

        /// <summary>
        /// The note background color
        /// </summary>
        private Xamarin.Forms.Color noteBackgroundColor = Color.White;

        /// <summary>
        /// The current note type
        /// </summary>
        private NoteType currentNotetype;

        /// <summary>
        /// The list
        /// </summary>
        private IList<string> list = new List<string>();

        /// <summary>
        /// The list
        /// </summary>
        private IList<string> list1 = new List<string>();

        /// <summary>
        /// The note key
        /// </summary>
        private string noteKey = string.Empty;

        /// <summary>
        /// Initializes a new instance of the <see cref="EditNote"/> class.
        /// </summary>
        /// <param name="idValue">The identifier value.</param>
        public EditNote(string idValue)
        {
            this.NoteKey = idValue;
            this.EditNoteData();
            this.InitializeComponent();
        }

        /// <summary>
        /// Gets or sets the color notes.
        /// </summary>
        /// <value>
        /// The color notes.
        /// </value>
        public Color ColorNotes { get; set; }

        /// <summary>
        /// Gets or sets the firebase helper variable.
        /// </summary>
        /// <value>
        /// The firebase helper variable.
        /// </value>
        public NotesRepository FirebaseHelperVar
        {
            get
            {
                return this.firebaseHelperVar;
            }

            set
            {
                this.firebaseHelperVar = value;
            }
        }

        /// <summary>
        /// Gets or sets the color of the note background.
        /// </summary>
        /// <value>
        /// The color of the note background.
        /// </value>
        public Color NoteBackgroundColor
        {
            get
            {
                return this.noteBackgroundColor;
            }

            set
            {
                this.noteBackgroundColor = value;
            }
        }

        /// <summary>
        /// Gets or sets the current note type.
        /// </summary>
        /// <value>
        /// The current note type.
        /// </value>
        public NoteType CurrentNotetype
        {
            get
            {
                return this.currentNotetype;
            }

            set
            {
                this.currentNotetype = value;
            }
        }

        /// <summary>
        /// Gets or sets the list.
        /// </summary>
        /// <value>
        /// The list.
        /// </value>
        public IList<string> Lists
        {
            get
            {
                return this.list;
            }

            set
            {
                this.list = value;
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
        /// Gets or sets the list1.
        /// </summary>
        /// <value>
        /// The list1.
        /// </value>
        public IList<string> List1
        {
            get
            {
                return this.list1;
            }

            set
            {
                this.list1 = value;
            }
        }

        /// <summary>
        /// Edit the note data.
        /// </summary>
        public async void EditNoteData()
        {
            try
            {
                //// get the note data
                var note = await this.FirebaseHelperVar.GetUserNote(this.NoteKey);
                TitleText.Text = note.Title;
                NoteText.Text = note.UserNote;

                Lists = note.LabelsList;
                List1 = note.CollaboratosList;

                this.CurrentNotetype = note.NoteType;
                this.BackgroundColor = Color.FromHex(FrameColorSetter.GetHexColor(note));
                ToolbarItems.Clear();

                if (note.NoteType == NoteType.isNote)
                {
                    ToolbarItems.Add(this.PinnedNote);
                    ToolbarItems.Add(this.ReminderNote);
                    ToolbarItems.Add(this.ArchiveNote);
                }

                else if (note.NoteType == NoteType.isArchive)
                {
                    ToolbarItems.Add(this.PinnedNote);
                    ToolbarItems.Add(this.ReminderNote);
                    ToolbarItems.Add(this.UnArchiveNote);
                }
                else if (note.NoteType == NoteType.ispin)
                {
                    ToolbarItems.Add(this.UnPinNote);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// add labels inside the frame 
        /// </summary>
        /// <param name="list">The list.</param>
        public async void LableFrames(IList<string> list)
        {
            var userid = DependencyService.Get<IDatabaseInterface>().GetId();
            LabelRepository firebasedata = new LabelRepository();
            var alllabels = await firebasedata.GetAllLabels();

            ////display labels
            foreach (NoteLabel model in alllabels)
            {
                foreach (var labelId in list)
                {
                    if (model.Labelkey.Equals(labelId))
                    {
                        ////add label name to Label text
                        var labelName = new Label
                        {
                            Text = model.Noteslabel,
                            HorizontalOptions = LayoutOptions.Start,
                            VerticalOptions = LayoutOptions.Start,
                            FontSize = 11
                        };

                        ////add new label frame inside the note
                        var labelFrame = new Frame
                        {
                            CornerRadius = 28,
                            HeightRequest = 14,
                            Content = labelName,
                            BorderColor = Color.Gray,
                            BackgroundColor = this.BackgroundColor
                        };
                        Note note = await this.FirebaseHelperVar.GetNoteByNoteId(NoteKey, userid);

                        note.NoteColor = this.noteBackgroundColor;
                        layout.Children.Add(labelFrame);

                        var labelimage = new TapGestureRecognizer();
                        labelimage.Tapped += TapLabel_tapped;
                        labelFrame.GestureRecognizers.Add(labelimage);
                    }
                }
            }
        }

        /*  /// <summary>
          /// add labels inside the frame 
          /// </summary>
          /// <param name="list">The list.</param>
          public async void CollaboratorsFrame(IList<string> list)
          {
              var userid = DependencyService.Get<IDatabaseInterface>().GetId();
              CollaboratorRepository firebasedata = new CollaboratorRepository();
              var alllabels = await firebasedata.GetAllcollaborators();

              ////display labels
              foreach (CollaboratorMadel model in alllabels)
              {
                  foreach (var collboratorid in list)
                  {
                      if (model.CKey.Equals(collboratorid))
                      {
                          var imagebutton = new ImageButton()
                          {
                              Source = "Accountphoto.png",
                              VerticalOptions = LayoutOptions.Start,
                              HorizontalOptions = LayoutOptions.Start
                          };

                          ////add new label frame inside the note
                          var labelFrame = new Frame
                          {

                              Content = imagebutton,
                              BorderColor = Color.Gray,
                              BackgroundColor = this.BackgroundColor
                          };

                          Note note = await this.FirebaseHelperVar.GetNoteByNoteId(NoteKey, userid);

                          note.NoteColor = this.noteBackgroundColor;
                          layout1.Children.Add(labelFrame);

                          var tapimage = new TapGestureRecognizer();

                          tapimage.Tapped += Tapimage_Tapped;

                          imagebutton.GestureRecognizers.Add(tapimage);
                      }
                  }
              }
          }*/

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

                var note = await this.FirebaseHelperVar.GetUserNote(this.NoteKey);
                var list = note.LabelsList;
                this.LableFrames(list);
                // var lists = note.CollaboratosList;
                //  this.CollaboratorsFrame(lists);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


        /// <summary>
        /// When overridden, allows the application developer to customize behavior as the <see cref="T:Xamarin.Forms.Page" /> disappears.
        /// </summary>
        /// <remarks>
        /// To be added.
        /// </remarks>
        protected async override void OnDisappearing()
        {
            try
            {
                //// create note instance with updated value
                Note note = await this.FirebaseHelperVar.GetUserNote(this.NoteKey);

                Note notes = new Note()
                {
                    Title = TitleText.Text,
                    UserNote = NoteText.Text,
                    NoteType = note.NoteType
                };

                //// calling updated function to update edited note in database
                await this.FirebaseHelperVar.UpdateUserNote(notes, this.NoteKey);
                //// go back to note page
                base.OnDisappearing();
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
        /// To be added.
        /// </returns>
        /// <remarks>
        /// To be added.
        /// </remarks>
        protected override bool OnBackButtonPressed()
        {
            if (Device.RuntimePlatform.Equals(Device.Android))
            {
                var uid = DependencyService.Get<IDatabaseInterface>().GetId();

                Note note = new Note()
                {
                    Title = TitleText.Text,
                    UserNote = NoteText.Text,
                    LabelsList = Lists
                };

                var result = this.FirebaseHelperVar.UpdateUserNote(note, this.NoteKey);
                return base.OnBackButtonPressed();
            }
            else
            {
                return false;
            }
        }



        /// <summary>
        /// Called when [pin note clicked].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private async void OnPinNoteClicked(object sender, EventArgs e)
        {
            try
            {
                Note note = await this.FirebaseHelperVar.GetUserNote(this.NoteKey);
                note.NoteType = NoteType.ispin;
                this.CurrentNotetype = note.NoteType;
                await this.FirebaseHelperVar.UpdateUserNote(note, this.NoteKey);
                await this.DisplayAlert("success", "Note is pinned", "ok");
                await Navigation.PushAsync(new NotesPage());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Called when [reminder note changed].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void OnReminderNoteChanged(object sender, EventArgs e)
        {
            try
            {
                Navigation.PushModalAsync(new RemindersPage());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Called when [archive note changed].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private async void OnArchiveNoteChanged(object sender, EventArgs e)
        {
            try
            {
                Note note = await this.FirebaseHelperVar.GetUserNote(this.NoteKey);
                note.NoteType = NoteType.isArchive;
                this.CurrentNotetype = note.NoteType;
                await this.FirebaseHelperVar.UpdateUserNote(note, this.NoteKey);
                await this.DisplayAlert("success", "Note is Archived", "ok");
                await Navigation.PushAsync(new NotesPage());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Called when [un archived note changed].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private async void OnUnArchivedNoteChanged(object sender, EventArgs e)
        {
            try
            {
                Note note = await this.FirebaseHelperVar.GetUserNote(this.NoteKey);
                note.NoteType = NoteType.isNote;
                this.CurrentNotetype = NoteType.isNote;
                await this.FirebaseHelperVar.UpdateUserNote(note, this.NoteKey);
                CrossToastPopUp.Current.ShowToastMessage("Note is UnArchived");
                await Navigation.PushModalAsync(new NotesPage());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Called when /[unpinned note].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private async void OnUnpinnedNote(object sender, EventArgs e)
        {
            try
            {
                Note note = await this.FirebaseHelperVar.GetUserNote(this.NoteKey);
                note.NoteType = NoteType.isNote;
                this.CurrentNotetype = note.NoteType;
                await this.FirebaseHelperVar.UpdateUserNote(note, this.NoteKey);
                await this.DisplayAlert("success", "Note is unpin ", "ok");
                ////  await Navigation.PushAsync(new NotePage());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Called when /[pop menu button clicked].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private async void OnPopMenuButton_Clicked(object sender, EventArgs e)
        {
            try
            {
                await PopupNavigation.Instance.PushAsync(new PopUpPage(this.NoteKey));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// ListViews the clicked.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private async void ListViewClicked(object sender, EventArgs e)
        {
            await PopupNavigation.Instance.PushAsync(new PlusPopUpPage(this.NoteKey));
        }

        /// <summary>
        /// Handles the tapped event of the TapLabel control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void TapLabel_tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new DeleteCollaboratorPage(this.NoteKey));
        }



        /// <summary>
        /// Handles the Tapped event of the Tapimage control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void Tapimage_Tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new DeleteCollaboratorPage(this.NoteKey));
        }

        private void Aque_Clicked(object sender, EventArgs e)
        {

        }
    }
}