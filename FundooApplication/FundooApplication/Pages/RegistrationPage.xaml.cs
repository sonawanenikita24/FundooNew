using FundooApplication.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FundooApplication.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class RegistrationPage : ContentPage
	{
        /// <summary>
        /// The tap count
        /// </summary>
        private int tapCount;

        /// <summary>
        /// The helper
        /// </summary>
        private UserRepository helper = new UserRepository();

        /// <summary>
        /// The gmail pattern
        /// </summary>
        private string gmailPattern = @"^[a-zA-Z][a-zA-Z0-9]+" + "@gmail.com";

        /// <summary>
        /// The name pattern
        /// </summary>
        private string namePattern = @"^[a-zA-Z]";

        /// <summary>
        /// Initializes a new instance of the <see cref="RegistrationPage"/> class.
        /// </summary>
        public RegistrationPage()
        {
            this.InitializeComponent();
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
        /// Gets or sets the name pattern.
        /// </summary>
        /// <value>
        /// The name pattern.
        /// </value>
        public string NamePattern
        {
            get
            {
                return this.namePattern;
            }

            set
            {
                this.namePattern = value;
            }
        }

        /// <summary>
        /// Gets or sets the helper.
        /// </summary>
        /// <value>
        /// The helper.
        /// </value>
        public UserRepository Helper
        {
            get
            {
                return this.helper;
            }

            set
            {
                this.helper = value;
            }
        }

        /// <summary>
        /// Gets or sets the tap count.
        /// </summary>
        /// <value>
        /// The tap count.
        /// </value>
        public int TapCount
        {
            get
            {
                return this.tapCount;
            }

            set
            {
                this.tapCount = value;
            }
        }

        /// <summary>
        /// Check the field are empty or not.
        /// </summary>
        /// <returns>returns true if field not empty</returns>
        public bool CheckedField()
        {
            //// check field are empty or not
            if (First_name.Text == null || Last_name.Text == null || UserName.Text == null || Password.Text == null || ConfirmPassword.Text == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// Valid the name of the user.
        /// </summary>
        /// <param name="username">The user name.</param>
        /// <returns>returns true if name is valid</returns>
        public bool ValidUserName(string username)
        {
            //// validation for username which is email 
            if (Regex.IsMatch(username, this.GmailPattern))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Valid the name.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>return true if name is valid</returns>
        public bool ValidName(string name)
        {
            //// validation for string input
            if (Regex.IsMatch(name, this.NamePattern))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Handles the Clicked event of the Image_Button control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void Image_button_clicked(object sender, EventArgs e)
        {
            /* this.TapCount++;
             var imagesender = (Image)sender;
             if (this.TapCount % 2 == 0)
             {
                 imagesender.Source="hide_image.png
                 Password.IsPassword = true;
             }
             else
             {
                 imagesender.Source = "show_image.jpg";
                 Password.IsPassword = false;
             }
             return;*/
        }

        /// <summary>
        /// Signs the in clicked.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void SignInClicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new LoginPage());
        }

        /// <summary>
        /// Handles the clicked event of the Submit_button control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private async void Submit_button_clicked(object sender, EventArgs e)
        {
            try
            {
                //// checking for fields are emtpy or not  
                if (this.CheckedField())
                {
                    if (this.ValidName(First_name.Text))
                    {
                        if (this.ValidName(Last_name.Text))
                        {
                            if (this.ValidUserName(UserName.Text))
                            {
                                if (Password.Text.Equals(ConfirmPassword.Text))
                                {
                                    await this.Helper.SubmitUserDetails(First_name.Text, Last_name.Text, UserName.Text, Password.Text, ConfirmPassword.Text);

                                    //// display message 
                                    await this.DisplayAlert("success", "successfully created user account", "ok");

                                    //// reset field
                                    UserName.Text = string.Empty;
                                    Password.Text = string.Empty;
                                    First_name.Text = string.Empty;
                                    Last_name.Text = string.Empty;
                                    ConfirmPassword.Text = string.Empty;

                                    //// navigate page to login page
                                    await Navigation.PushModalAsync(new LoginPage());
                                }
                                else
                                {
                                    //// showing message when password not matched
                                    await this.DisplayAlert("fail", "Password not matched", "cancel");
                                    Password.Text = string.Empty;
                                }
                            }
                            else
                            {
                                //// display alert message when user name not match with given format
                                await this.DisplayAlert("Alert", "Please enter valid email address", "ok");
                                UserName.Text = string.Empty;
                            }
                        }
                        else
                        {
                            //// display alert message when last name not match with given format
                            await this.DisplayAlert("Alert", "Please enter last name in correct format", "ok");
                            Last_name.Text = string.Empty;
                        }
                    }
                    else
                    {
                        //// display alert message when first name not match with given format
                        await this.DisplayAlert("Alert", "Please enter name in correct format", "ok");
                        First_name.Text = string.Empty;
                    }
                }
                else
                {
                    //// display alert message when fields are empty
                    await this.DisplayAlert("Alert", "one or more field are empty", "ok");
                }
            }
            catch (Exception)
            {
                Console.WriteLine();
            }
        }
    }
}