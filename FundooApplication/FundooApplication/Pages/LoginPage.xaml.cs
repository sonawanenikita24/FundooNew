using System;
using System.Text.RegularExpressions;
using FundooApplication.Themes;
using FundooApplication.Interfaces;
using FundooApplication;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace FundooApplication.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoginPage : ContentPage
	{
        /// <summary>
        /// The tap count
        /// </summary>
        private int tapcount;

        /// <summary>
        /// The gmail pattern
        /// </summary>
        private string gmailPattern = @"^[a-zA-Z][a-zA-Z0-9]+" + "@gmail.com";

        /// <summary>
        /// Initializes a new instance of the <see cref="LoginPage"/> class.
        /// </summary>
        public LoginPage()
        {
            this.InitializeComponent();
            themePicker.SelectedIndexChanged += ThemePicker_SelectedIndexChanged;
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of the ThemePicker control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void ThemePicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            ThemeManager.ChangeTheme(themePicker.SelectedItem.ToString());
        }

        /// <summary>
        /// Gets or sets the tap count.
        /// </summary>
        /// <value>
        /// The tap count.
        /// </value>
        public int Tapcount
        {
            get
            {
                return this.tapcount;
            }

            set
            {
                this.tapcount = value;
            }
        }

        /// <summary>
        /// Gets or sets the gmail pattern.
        /// </summary>
        /// <value>
        /// The gmail pattern.
        /// </value>
        public string GmailPattern
        {
            get
            {
                return this.gmailPattern;
            }

            set
            {
                this.gmailPattern = value;
            }
        }

        /// <summary>
        /// Check field are empty or not.
        /// </summary>
        /// <returns>returns true if not empty</returns>
        public bool Checkfield()
        {
            if (UserName.Text == null || Password.Text == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// Handles the clicked event of the Image_button control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void Image_button_clicked(object sender, EventArgs e)
        {
            //// eye image button clicked
        }

        /// <summary>
        /// Handles the Clicked event of the Forgot_button control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void Forgot_button_Clicked(object sender, EventArgs e)
        {
            try
            {
                Navigation.PushModalAsync(new ForgotPassword());
            }
            catch (Exception)
            {
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Handles the Clicked event of the Create_button control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void Create_button_Clicked(object sender, EventArgs e)
        {
            try
            {
                Navigation.PushModalAsync(new RegistrationPage());
            }
            catch (Exception)
            {
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Handles the clicked event of the Login_button control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private async void Login_button_clicked(object sender, EventArgs e)
        {
            try
            {
                if (Xamarin.Essentials.Connectivity.NetworkAccess != Xamarin.Essentials.NetworkAccess.Internet)
                {
                    await this.DisplayAlert("No Internet", "check your network connection", "ok");
                    return;
                }

                loading.IsEnabled = true;

                if (this.Checkfield())
                {
                    if (Regex.IsMatch(UserName.Text, this.GmailPattern))
                    {
                        var user = await DependencyService.Get<IDatabaseInterface>().LoginWithFirebaseAuth(UserName.Text, Password.Text);

                        if (user != null)
                        {
                            await Navigation.PushModalAsync(new DashBoard());

                            //// reset field
                            UserName.Text = string.Empty;
                            Password.Text = string.Empty;
                        }
                        else
                        {
                            await this.DisplayAlert("failure", "Password not matched", "ok");
                            Password.Text = string.Empty;
                            Password.Placeholder = "Please enter correct password";
                        }
                    }
                    else
                    {
                        await this.DisplayAlert("Alert", "please enter valid email", "ok");
                        UserName.Text = string.Empty;
                    }
                }
                else
                {
                    await this.DisplayAlert("Alert", "one or more field empty", "ok");
                }

                loading.IsEnabled = false;
            }
            catch (Exception)
            {
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Handles the clicked event of the Google_Login control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void Google_Login_clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new GoogleProfilePage());
        }

        /// <summary>
        /// Application developers can override this method to provide behavior when the back button is pressed.
        /// </summary>
        /// <returns>
        /// To be added.
        /// </returns>
        /// <remarks>
        /// To be added.
        /// </remarks>

        protected override bool OnBackButtonPressed()
        {
            base.OnBackButtonPressed();
            return false;
        }
    }
}