using Firebase.Database;
using Firebase.Database.Query;
using FundooApplication.Interfaces;
using FundooApplication.Model;
using Plugin.Toast;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using static FundooApplication.Model.TypeOfNote;

namespace FundooApplication.Repository
{
    /// <summary>
    /// Database layer defination
    /// </summary>
    public class UserRepository
    {
        /// <summary>
        /// The firebase is instance of firebase client
        /// </summary>
        private FirebaseClient firebase = new FirebaseClient("https://fundooapplication-f0d55.firebaseio.com/");

        /// <summary>
        /// Gets or sets the firebase.
        /// </summary>
        /// <value>
        /// The firebase.
        /// </value>
        public FirebaseClient Firebase
        {
            get
            {
                return this.firebase;
            }

            set
            {
                this.firebase = value;
            }
        }

        /// <summary>
        /// Submits the user details.
        /// </summary>
        /// <param name="firstname">The first name.</param>
        /// <param name="lastname">The last name.</param>
        /// <param name="username">The user name.</param>
        /// <param name="password">The password.</param>
        /// <param name="confirmpassword">The confirm password.</param>
        /// <returns>returns user details</returns>
        public async Task SubmitUserDetails(string firstname, string lastname, string username, string password, string confirmpassword)
        {
            try
            {
                var uid = await DependencyService.Get<IDatabaseInterface>().SignUpWithFirebaseAuth(username, password);
                await this.Firebase.Child("Users").Child(uid).Child("User Information").PostAsync(new RegisterUser()
                {
                    Firstname = firstname,
                    Lastname = lastname,
                    UserName = username,
                    Viewtype = ViewType.gridView
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Gets the register user by identifier.
        /// </summary>
        /// <returns>register id</returns>
        public async Task<RegisterUser> GetRegisterUserById()
        {
            try
            {
                var userid = DependencyService.Get<IDatabaseInterface>().GetId();

                if (userid != null)
                {
                    RegisterUser user = await this.firebase.Child("Users").Child(userid).Child("User Information").OnceSingleAsync<RegisterUser>();
                    return user;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return null;
        }

        /// <summary>
        /// Get images the source.
        /// </summary>
        /// <param name="imagesource">The image source.</param>
        /// <returns>return task</returns>
        public async Task GetimageSouce(string imagesource)
        {
            string uid = DependencyService.Get<IDatabaseInterface>().GetId();
            RegisterUser user = await this.GetRegisterUserById();
            if (uid != null && user != null)
            {
                await this.Firebase.Child("Users").Child(uid).Child("User Information").PutAsync<RegisterUser>(new RegisterUser()
                {
                    Firstname = user.Firstname,
                    Lastname = user.Lastname,
                    Imageurl = imagesource
                });
            }

            CrossToastPopUp.Current.ShowToastMessage("Profile Picture Uploaded Successfully");
        }
    }
}