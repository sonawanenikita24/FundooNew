//--------------------------------------------------------------------------------------------------------------------
// <copyright file="SettingPage.cs" company="BridgeLabz">
// copyright @2019 
// </copyright>
// <creater name="Nikita Sonawane"/>
//------------------------------------------------------------------------------------------------------------------
namespace FundooApplication.Pages
{
    using FundooApplication.ViewModels;
    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SettingPage : ContentPage
    {
        /// <summary>
        /// The view model of main page
        /// </summary>
        MainPageModel vm;

        /// <summary>
        /// Initializes a new instance of the <see cref="SettingPage"/> class.
        /// </summary>
        public SettingPage()
        {
            InitializeComponent();
            vm = new MainPageModel();
            this.BindingContext = vm;
        }
    }
}