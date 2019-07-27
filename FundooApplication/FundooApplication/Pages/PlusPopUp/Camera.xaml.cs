//--------------------------------------------------------------------------------------------------------------------
// <copyright file="Camera.cs" company="BridgeLabz">
// copyright @2019 
// </copyright>
// <creater name="Nikita Sonawane"/>
//------------------------------------------------------------------------------------------------------------------
namespace FundooApplication.Pages.PlusPopUp
{
    using Plugin.Media.Abstractions;
    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Camera : ContentPage
    {
        /// <summary>
        /// The file
        /// </summary>
        MediaFile file;

        /// <summary>
        /// The note key
        /// </summary>
        private string notekey;

        /// <summary>
        /// Initializes a new instance of the <see cref="Camera"/> class.
        /// </summary>
        /// <param name="noteid">The note id.</param>
        public Camera(string noteid)
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