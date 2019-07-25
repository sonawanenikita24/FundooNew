using FundooApplication.Model;
using FundooApplication.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace FundooApplication.ViewModels
{
    /// <summary>
    /// Model class for google to get profile info
    /// </summary>
    /// <seealso cref="System.ComponentModel.INotifyPropertyChanged" />
    public class GoogleViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// The google services
        /// </summary>
        private readonly GoogleServices googleServices;

        /// <summary>
        /// The google profile
        /// </summary>
        private GoogleProfile googleProfile;

        /// <summary>
        /// Initializes a new instance of the <see cref="GoogleViewModel"/> class.
        /// </summary>
        public GoogleViewModel()
        {
            this.googleServices = new GoogleServices();
        }

        /// <summary>
        /// Occurs when a property value changes.
        /// </summary>
        /// <returns></returns>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Gets or sets the google profile.
        /// </summary>
        /// <value>
        /// The google profile.
        /// </value>
        public GoogleProfile GoogleProfile
        {
            get
            {
                return this.googleProfile;
            }

            set
            {
                this.googleProfile = value;
                this.OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets the access token asynchronous.
        /// </summary>
        /// <param name="code">The code.</param>
        /// <returns>return token</returns>
        public async Task<string> GetAccessTokenAsync(string code)
        {
            var accessToken = await this.googleServices.GetAccessTokenAsync(code);

            return accessToken;
        }

        /// <summary>
        /// Sets the google user profile asynchronous.
        /// </summary>
        /// <param name="accessToken">The access token.</param>
        /// <returns>set the google profile</returns>
        public async Task SetGoogleUserProfileAsync(string accessToken)
        {
            GoogleProfile = await this.googleServices.GetGoogleUserProfileAsync(accessToken);
        }

        /// <summary>
        /// Called when [property changed].
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}