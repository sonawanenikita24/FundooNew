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
	public partial class SearchNote : ContentPage
	{
        /// <summary>
        /// The suggestion is list of notes
        /// </summary>
        public List<Note> suggestion;

        /// <summary>
        /// The notes
        /// </summary>
        private List<Note> notes;

        /// <summary>
        /// The identifier
        /// </summary>
        private string keyid;

        /// <summary>
        /// The firebase help
        /// </summary>
        private NotesRepository firebaseHelp = new NotesRepository();

        /// <summary>
        /// Initializes a new instance of the <see cref="SearchNote"/> class.
        /// </summary>
        public SearchNote()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Gets or sets the key identifier.
        /// </summary>
        /// <value>
        /// The key identifier.
        /// </value>
        public string KeyId
        {
            get
            {
                return this.keyid;
            }

            set
            {
                this.keyid = value;
            }
        }

        /// <summary>
        /// Gets or sets the notes.
        /// </summary>
        /// <value>
        /// The notes.
        /// </value>
        public List<Note> Notes
        {
            get
            {
                return this.notes;
            }

            set
            {
                this.notes = value;
            }
        }

        /// <summary>
        /// Gets or sets the firebase help.
        /// </summary>
        /// <value>
        /// The firebase help.
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
        /// Handles the TextChanged event of the SearchBar control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="TextChangedEventArgs"/> instance containing the event data.</param>
        private async void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                var Keyword = SearchNotes.Text;
                Notes = await FirebaseHelp.GetAllUserNotes();
                if (Keyword.Length >= 1)
                {
                    var suggestion = Notes.Where(c => c.Title.ToLower().Contains(Keyword.ToLower()));
                    Notelist.ItemsSource = suggestion;
                    Notelist.IsVisible = true;
                    //// NoteGridForOthers(suggestion);
                }
                else
                {
                    Notelist.IsVisible = false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Handles the Tapped event of the NoteListItem control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="ItemTappedEventArgs"/> instance containing the event data.</param>
        private void NoteListItem_Tapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item as string == null)
            {
                return;
            }
            else
            {
                Notelist.ItemsSource = Notes.Where(c => c.Equals(e.Item as string));
                Notelist.IsVisible = true;
                SearchNotes.Text = e.Item as string;
            }
        }

        /// <summary>
        /// Notes the grid for others.
        /// </summary>
        /// <param name="otherList">The other list.</param>
        /*private async void NoteGridForOthers(List<Note> notelist)
        {
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
                for (int rowindex = 0; rowindex < notelist.Count; rowindex++)
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
        }*/
    }
}