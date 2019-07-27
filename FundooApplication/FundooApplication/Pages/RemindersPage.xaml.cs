//--------------------------------------------------------------------------------------------------------------------
// <copyright file="RemindersPage.cs" company="BridgeLabz">
// copyright @2019 
// </copyright>
// <creater name="Nikita Sonawane"/>
//------------------------------------------------------------------------------------------------------------------
namespace FundooApplication.Pages
{
    using System;
    using Rg.Plugins.Popup.Services;
    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RemindersPage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RemindersPage"/> class.
        /// </summary>
        public RemindersPage()
        {
            this.InitializeComponent();
            mypicker.Items.Add("Does not repeat");
            mypicker.Items.Add("Daily");
            mypicker.Items.Add("Weekly");
            mypicker.Items.Add("Monthly");
            mypicker.Items.Add("Yearly");
            mypicker.Items.Add("Custom");
        }

        /// <summary>
        /// Handles the Clicked event of the Save control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private async void Save_Clicked(object sender, EventArgs e)
        {
            await PopupNavigation.Instance.PopAsync(true);
        }

        /// <summary>
        /// Handles the Clicked event of the Cancel control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private async void Cancel_Clicked(object sender, EventArgs e)
        {
            await PopupNavigation.Instance.PopAsync(true);
        }

        /// <summary>
        /// Handles the clicked event of the TimeButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void TimeButton_clicked(object sender, EventArgs e)
        {
            //// some code
        }

        /// <summary>
        /// Handles the clicked event of the PlaceButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void PlaceButton_clicked(object sender, EventArgs e)
        {
            //// code
        }

        /// <summary>
        /// Called when [back button pressed].
        /// </summary>
        /// <returns></returns>
        protected override bool OnBackButtonPressed()
        {
            DisplayAlert("Alert", "Please logout first from app", "Ok");

            ////go to Edit page with that note id
            Navigation.PushAsync(new LogoutPage());
            return base.OnBackButtonPressed();
        }
    }
}