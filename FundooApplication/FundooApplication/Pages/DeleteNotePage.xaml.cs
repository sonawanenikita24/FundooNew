//--------------------------------------------------------------------------------------------------------------------
// <copyright file="DeleteNotePage.cs" company="BridgeLabz">
// copyright @2019 
// </copyright>
// <creater name="Nikita Sonawane"/>
//------------------------------------------------------------------------------------------------------------------
namespace FundooApplication.Pages
{
    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DeleteNotePage : ContentPage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteNotePage"/> class.
        /// </summary>
        public DeleteNotePage()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// When overridden, allows application developers to customize behavior immediately prior to the <see cref="T:Xamarin.Forms.Page" /> becoming visible.
        /// </summary>
        /// <remarks>
        /// To be added.
        /// </remarks>
        protected override void OnAppearing()
        {
            base.OnAppearing();
            Navigation.PushModalAsync(new NotesPage(), false);
        }
    }
}