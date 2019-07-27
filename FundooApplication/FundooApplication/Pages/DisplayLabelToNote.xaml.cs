//--------------------------------------------------------------------------------------------------------------------
// <copyright file="DisplayLabelToNote.cs" company="BridgeLabz">
// copyright @2019 
// </copyright>
// <creater name="Nikita Sonawane"/>
//------------------------------------------------------------------------------------------------------------------
namespace FundooApplication.Pages
{
    using System;
    using System.Linq;
    using FundooApplication.Interfaces;
    using FundooApplication.Repository;
    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DisplayLabelToNote : ContentPage
    {
        /// <summary>
        /// The firebase helper is instance of helper class
        /// </summary>
        private NotesRepository firebaseHelper = new NotesRepository();

        /// <summary>
        /// The value
        /// </summary>
        private string value = null;

        /// <summary>
        /// The label helper
        /// </summary>
        private LabelRepository labelHelper = new LabelRepository();

        /// <summary>
        /// Initializes a new instance of the <see cref="DisplayLabelToNote"/> class.
        /// </summary>
        public DisplayLabelToNote()
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

                var uid = DependencyService.Get<IDatabaseInterface>().GetId();

                var label = await LabelHelper.GetLabel(this.Value);

                var alllabel = await LabelHelper.GetAllLabels();
                var notes = await FirebaseHelper.GetAllUserNotes();

                var itemss = notes.Where(c => c.LabelsList.Equals(label));
                Notelist.ItemsSource = itemss;
                Notelist.IsVisible = true;
            }
            catch (Exception ex)
            {
                await this.DisplayAlert("Exception", ex.Message, "ok");
            }
        }

        /*   /// <summary>
           /// Displays the grid layout for archive asynchronous.
           /// </summary>
           /// <param name="notes">The notes.</param>
           /// <returns>grid layout</returns>
           private async Task GridForLabel(IList<Note> note)
           {
               var index = -1;
               var productIndex = 0;
               int rowCount = 0;
               try
               {
                   LabelGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(170) });
                   LabelGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(750) });
                   for (int row = 0; row < note.Count; row++)
                   {
                       if (row % 2 == 0)
                       {
                           LabelGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(2, GridUnitType.Auto) });
                           rowCount++;
                       }
                   }
                   for (int row = 0; row < rowCount; row++)
                   {
                       for (int col = 0; col < 2; col++)
                       {
                           Note notess = null;
                           index++;
                           if (index < note.Count)
                           {
                               notess = note[index];
                           }
                           if (productIndex >= note.Count)
                           {
                               break;
                           }
                           productIndex += 1;
                           //// create label to display title
                           Label labelTitle = new Label()
                           {
                               Text = notess.Title,
                               TextColor = Color.Black,
                               FontSize = 15,
                               FontAttributes = FontAttributes.Bold,
                               VerticalOptions = LayoutOptions.Center,
                               HorizontalOptions = LayoutOptions.Start
                           };
                           //// create label to set identifier to the note
                           Label labelId = new Label
                           {
                               Text = notess.Key,
                               IsVisible = false
                           };
                           //// create label to display description of the notes
                           Label labelNoteDetails = new Label
                           {
                               Text = notess.UserNote,
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
                           LabelGrid.Children.Add(frame, col, row);
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