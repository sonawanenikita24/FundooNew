//--------------------------------------------------------------------------------------------------------------------
// <copyright file="CheckBoxes.cs" company="BridgeLabz">
// copyright @2019 
// </copyright>
// <creater name="Nikita Sonawane"/>
//------------------------------------------------------------------------------------------------------------------
namespace FundooApplication.Pages.PlusPopUp
{
    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CheckBoxes : ContentPage
    {
        /// <summary>
        /// The note key
        /// </summary>
        private string notekey;

        /// <summary>
        /// Initializes a new instance of the <see cref="CheckBoxes"/> class.
        /// </summary>
        /// <param name="noteid">The note id.</param>
        public CheckBoxes(string noteid)
        {
            this.Notekey = noteid;
            this.InitializeComponent();
        }

        /// <summary>
        /// Gets or sets the note key.
        /// </summary>
        /// <value>
        /// The note key.
        /// </value>
        public string Notekey
        {
            get
            {
                return this.notekey;
            }

            set
            {
                this.notekey = value;
            }
        }
    }
}