using FundooApplication.Service;
using FundooApplication.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FundooApplication.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class GoogleProfilePage : ContentPage
	{
        /// <summary>
        /// The google view model
        /// </summary>
        private readonly GoogleViewModel googleViewModel;

        /// <summary>
        /// Initializes a new instance of the <see cref="GoogleProfilePage"/> class.
        /// </summary>
        public GoogleProfilePage()
        {
            this.InitializeComponent();
            this.googleViewModel = BindingContext as GoogleViewModel;

            var authRequest =
                  "https://accounts.google.com/o/oauth2/v2/auth"
                  + "?response_type=code"
                  + "&scope=openid"
                  + "&redirect_uri=" + GoogleServices.RedirectUri
                  + "&client_id=" + GoogleServices.ClientId;

            var webView = new WebView
            {
                Source = authRequest,
                HeightRequest = 1
            };

            webView.Navigated += WebViewOnNavigated;

            this.Content = webView;
        }

        /// <summary>
        /// Webs the view on navigated.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="WebNavigatedEventArgs"/> instance containing the event data.</param>
        private async void WebViewOnNavigated(object sender, WebNavigatedEventArgs e)
        {
            var code = this.ExtractCodeFromUrl(e.Url);

            if (code != string.Empty)
            {
                var accessToken = await this.googleViewModel.GetAccessTokenAsync(code);

                await this.googleViewModel.SetGoogleUserProfileAsync(accessToken);

                this.Content = this.MainStackLayout;
            }
        }

        /// <summary>
        /// Extracts the code from URL.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <returns>return url</returns>
        private string ExtractCodeFromUrl(string url)
        {
            if (url.Contains("code="))
            {
                var attributes = url.Split('&');

                var code = attributes.FirstOrDefault(s => s.Contains("code=")).Split('=')[1];

                return code;
            }

            return string.Empty;
        }
    }
}