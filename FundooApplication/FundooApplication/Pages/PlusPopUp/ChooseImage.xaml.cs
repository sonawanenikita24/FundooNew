//--------------------------------------------------------------------------------------------------------------------
// <copyright file="ChooseImage.cs" company="BridgeLabz">
// copyright @2019 
// </copyright>
// <creater name="Nikita Sonawane"/>
//------------------------------------------------------------------------------------------------------------------
namespace FundooApplication.Pages.PlusPopUp
{
    using System;
    using System.Diagnostics;
    using System.IO;
    using FundooApplication.Repository;
    using Plugin.Media;
    using Plugin.Media.Abstractions;
    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ChooseImage : ContentPage
    {
        /// <summary>
        /// The file
        /// </summary>
        MediaFile file;

        /// <summary>
        /// The notes is instance of note repository
        /// </summary>
        NotesRepository notes = new NotesRepository();

        /// <summary>
        /// The note key
        /// </summary>
        private string notekey;

        /// <summary>
        /// Initializes a new instance of the <see cref="ChooseImage"/> class.
        /// </summary>
        /// <param name="noteId">The note identifier.</param>
        public ChooseImage(string noteId)
        {
            this.Notekey = noteId;
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

        /// <summary>
        /// When overridden, allows application developers to customize behavior immediately prior to the <see cref="T:Xamarin.Forms.Page" /> becoming visible.
        /// </summary>
        /// <remarks>
        /// To be added.
        /// </remarks>
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await CrossMedia.Current.Initialize();
            try
            {
                file = await Plugin.Media.CrossMedia.Current.PickPhotoAsync(new Plugin.Media.Abstractions.PickMediaOptions
                {
                    PhotoSize = Plugin.Media.Abstractions.PhotoSize.Medium
                });
                if (file == null)
                {
                    return;
                }

                imgChoosed.Source = ImageSource.FromStream(() =>
                {
                    var imageStram = file.GetStream();
                    return imageStram;
                });

                var storage = await notes.UploadFile(file.GetStream(), Path.GetFileName(file.Path));
                string imageurl = storage;
                await notes.GetimageSouce(Notekey, imageurl);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
    }
}