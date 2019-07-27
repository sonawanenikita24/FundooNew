//--------------------------------------------------------------------------------------------------------------------
// <copyright file="DeleteCollaboratorPage.cs" company="BridgeLabz">
// copyright @2019 
// </copyright>
// <creater name="Nikita Sonawane"/>
//------------------------------------------------------------------------------------------------------------------
namespace FundooApplication.Pages.PopUpPages
{
    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DeleteCollaboratorPage : ContentPage
    {
        /// <summary>
        /// The value
        /// </summary>
        string value = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteCollaboratorPage"/> class.
        /// </summary>
        /// <param name="key">The key.</param>
        public DeleteCollaboratorPage(string key)
        {
            InitializeComponent();
            this.value = key;
        }
    }
}