using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Firebase.Auth;
using FundooApplication.Droid.UserAccount;
using FundooApplication.Interfaces;
using Xamarin.Forms;

[assembly: Dependency(typeof(UserAccountImplementation))]

namespace FundooApplication.Droid.UserAccount
{
    /// <summary>
    /// implement interface method here
    /// </summary>
    /// <seealso cref="FundooNotesApp.Interface.IDatabaseInterface" />
    public class UserAccountImplementation : IDatabaseInterface
    {
        /// <summary>
        /// reset password for user
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        public void ForgotpasswordFirebaseAuth(string userName)
        {
            FirebaseAuth.Instance.SendPasswordResetEmailAsync(userName);
        }

        /// <summary>
        /// Gets the identifier for current user.
        /// </summary>
        /// <returns>
        /// returns current user
        /// </returns>
        public string GetId()
        {
            var currentuser = FirebaseAuth.Instance.CurrentUser.Uid;
            return currentuser.ToString();
        }

        /// <summary>
        /// login using username and password
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <param name="password">The password.</param>
        /// <returns>
        /// returns true if user is valid
        /// </returns>
        public async Task<string> LoginWithFirebaseAuth(string userName, string password)
        {
            try
            {
                //// sign in using email and password
                var userId = await FirebaseAuth.Instance.SignInWithEmailAndPasswordAsync(userName, password);
                var token = await userId.User.GetIdTokenAsync(false);
                return token.Token;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Logout function using firebase authentication.
        /// </summary>
        public void LogoutWithFirebaseAuth()
        {
            FirebaseAuth.Instance.SignOut();
        }

        /// <summary>
        /// Resets the password with firebase authentication.
        /// </summary>
        /// <param name="old_password">The old password.</param>
        /// <param name="new_password">The new password.</param>
        /// <returns>
        /// return updated password
        /// </returns>
        public async Task ResetPasswordwithFirebaseAuth(string old_password, string new_password)
        {
            try
            {
                ////Get the current logged in user's details
                var currentUser = FirebaseAuth.Instance.CurrentUser;

                ////Get current user credentials to reauthenticate the user
                AuthCredential credential = EmailAuthProvider.GetCredential(currentUser.Email, old_password);

                ////Reauthenticate the user with credentials
                var result = await currentUser.ReauthenticateAndRetrieveDataAsync(credential);

                ////If authentication succeeded then update the password
                if (result != null)
                {
                    await currentUser.UpdatePasswordAsync(new_password);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        /// <summary>
        /// Signs up with username and password.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <param name="password">The password.</param>
        /// <returns>
        /// returns true
        /// </returns>
        public async Task<string> SignUpWithFirebaseAuth(string userName, string password)
        {
            //// create account with username and password with firebase authentication
            var user = await FirebaseAuth.Instance.CreateUserWithEmailAndPasswordAsync(userName, password);

            var uid = user.User.Uid;

            //// return id;
            return uid;
        }

        /// <summary>
        /// Signs the in with google.
        /// </summary>
        /// <returns>
        /// return true if user sign in with google
        /// </returns>
        public bool Status()
        {
            try
            {
                var user = FirebaseAuth.Instance.CurrentUser;
                if (user != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}