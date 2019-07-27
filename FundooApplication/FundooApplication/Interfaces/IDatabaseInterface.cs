//--------------------------------------------------------------------------------------------------------------------
// <copyright file="IDatabaseInterface.cs" company="BridgeLabz">
// copyright @2019 
// </copyright>
// <creater name="Nikita Sonawane"/>
//------------------------------------------------------------------------------------------------------------------
namespace FundooApplication.Interfaces
{
    using System.Threading.Tasks;

    /// <summary>
    /// database interface
    /// </summary>
    public interface IDatabaseInterface
    {
        /// <summary>
        /// login using username and password
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <param name="password">The password.</param>
        /// <returns>returns true if user is valid</returns>
        Task<string> LoginWithFirebaseAuth(string userName, string password);

        /// <summary>
        /// Gets the identifier for current user. 
        /// </summary>
        /// <returns>returns current user</returns>
        string GetId();

        /// <summary>
        /// Signs up with username and password.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <param name="password">The password.</param>
        /// <returns>returns true</returns>
        Task<string> SignUpWithFirebaseAuth(string userName, string password);

        /// <summary>
        /// reset password for user
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        void ForgotpasswordFirebaseAuth(string userName);

        /// <summary>
        /// Resets the password with firebase authentication.
        /// </summary>
        /// <param name="old_password">The old password.</param>
        /// <param name="new_password">The new password.</param>
        /// <returns>return updated password</returns>
        Task ResetPasswordwithFirebaseAuth(string old_password, string new_password);

        /// <summary>
        /// Logout function using firebase authentication.
        /// </summary>
        void LogoutWithFirebaseAuth();

        /// <summary>
        /// Signs the in with google.
        /// </summary>
        /// <returns>
        /// return true if user sign in with google
        /// </returns>
        ////Task<bool> SignInWithGoogle(string token);    

        bool Status();
    }
}