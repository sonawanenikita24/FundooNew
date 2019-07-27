//--------------------------------------------------------------------------------------------------------------------
// <copyright file="ForgotPassword.cs" company="BridgeLabz">
// copyright @2019 
// </copyright>
// <creater name="Nikita Sonawane"/>
//------------------------------------------------------------------------------------------------------------------
namespace FundooApplication.Pages
{
    using System;
    using System.Text.RegularExpressions;
    using FundooApplication.Interfaces;
    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ForgotPassword : ContentPage
    {
        /// <summary>
        /// The gmail pattern
        /// </summary>
        private string gmailPattern = @"^[a-zA-Z][a-zA-Z0-9]+" + "@gmail.com";

        /// <summary>
        /// Initializes a new instance of the <see cref="ForgotPassword"/> class.
        /// </summary>
        public ForgotPassword()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Check the field are empty or not.
        /// </summary>
        /// <returns>return true if field are not empty</returns>
        public bool CheckedField()
        {
            if (UserName.Text == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// Handles the clicked event of the Back_button control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void Back_button_clicked(object sender, EventArgs e)
        {
            try
            {
                Navigation.PushModalAsync(new LoginPage());
            }
            catch (Exception)
            {
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Handles the clicked event of the Forgot_button control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private async void Forgot_button_clicked(object sender, EventArgs e)
        {
            try
            {
                //// if fields are not empty then taking user name and sending mail for reset password 
                if (this.CheckedField())
                {
                    if (Regex.IsMatch(UserName.Text, this.gmailPattern))
                    {
                        DependencyService.Get<IDatabaseInterface>().ForgotpasswordFirebaseAuth(UserName.Text);
                        await this.DisplayAlert("success", "Password changed successfully", "ok");
                        await Navigation.PushModalAsync(new LoginPage());
                    }
                    else
                    {
                        await this.DisplayAlert("Alert", "Plaese enter valid email id", "ok");
                        UserName.Text = string.Empty;
                    }
                }
                else
                {
                    await this.DisplayAlert("Alert", "please enter username/email", "ok");
                }
            }
            catch (Exception)
            {
                Console.WriteLine();
            }
        }
    }
}