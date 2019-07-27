//--------------------------------------------------------------------------------------------------------------------
// <copyright file="RegisterUser.cs" company="BridgeLabz">
// copyright @2019 
// </copyright>
// <creater name="Nikita Sonawane"/>
//------------------------------------------------------------------------------------------------------------------
namespace FundooApplication.Model
{
    using Xamarin.Forms;
    using static FundooApplication.Model.TypeOfNote;

    /// <summary>
    /// class storing user information in database
    /// </summary>
    public class RegisterUser
    {
        /// <summary>
        /// The first name of the user
        /// </summary>
        private string firstname;

        /// <summary>
        /// The last name of the user
        /// </summary>
        private string lastname;

        /// <summary>
        /// The user name 
        /// </summary>
        private string userName;

        /// <summary>
        /// The password
        /// </summary>
        private string password;

        /// <summary>
        /// The confirm password
        /// </summary>
        private string confirmpassword;

        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        /// <value>
        /// The first name.
        /// </value>
        public string Firstname
        {
            get
            {
                return this.firstname;
            }

            set
            {
                this.firstname = value;
            }
        }

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        /// <value>
        /// The last name.
        /// </value>
        public string Lastname
        {
            get
            {
                return this.lastname;
            }

            set
            {
                this.lastname = value;
            }
        }

        /// <summary>
        /// Gets or sets the name of the user.
        /// </summary>
        /// <value>
        /// The name of the user.
        /// </value>
        public string UserName
        {
            get
            {
                return this.userName;
            }

            set
            {
                this.userName = value;
            }
        }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        /// <value>
        /// The password.
        /// </value>
        public string Password
        {
            get
            {
                return this.password;
            }

            set
            {
                this.password = value;
            }
        }

        /// <summary>
        /// Gets or sets the confirm password.
        /// </summary>
        /// <value>
        /// The confirm password.
        /// </value>
        public string Confirmpassword
        {
            get
            {
                return this.confirmpassword;
            }

            set
            {
                this.confirmpassword = value;
            }
        }

        /// <summary>
        /// Gets or sets the image url.
        /// </summary>
        /// <value>
        /// The image url.
        /// </value>
        public string Imageurl { get; set; }

        /// <summary>
        /// Gets or sets the view type.
        /// </summary>
        /// <value>
        /// The view type.
        /// </value>
        public ViewType Viewtype { get; set; }

        /// <summary>
        /// Gets or sets the user email address
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the image source.
        /// </summary>
        /// <value>
        /// The image source.
        /// </value>
        public static ImageSource ImgSource { get; set; }
    }
}