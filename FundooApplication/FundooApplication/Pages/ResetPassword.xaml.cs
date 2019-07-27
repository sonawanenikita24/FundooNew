//--------------------------------------------------------------------------------------------------------------------
// <copyright file="ResetPassword.cs" company="BridgeLabz">
// copyright @2019 
// </copyright>
// <creater name="Nikita Sonawane"/>
//------------------------------------------------------------------------------------------------------------------
namespace FundooApplication.Pages
{
    using System;
    using FundooApplication.Interfaces;
    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ResetPassword : ContentPage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ResetPassword"/> class.
        /// </summary>
        public ResetPassword()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Handles the clicked event of the Reset_button control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private async void Reset_button_clicked(object sender, EventArgs e)
        {
            //// calling reset password method
            await DependencyService.Get<IDatabaseInterface>().ResetPasswordwithFirebaseAuth(OldPassword.Text, NewPassword.Text);
            await this.DisplayAlert("Success", "Password reset", "ok");
            await Navigation.PushModalAsync(new LoginPage());
        }
    }
}