using FundooApplication.Interfaces;
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
	public partial class LogoutPage : ContentPage
	{
        /// <summary>
        /// Initializes a new instance of the <see cref="LogoutPage"/> class.
        /// </summary>
        public LogoutPage()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// When overridden, allows application developers to customize behavior immediately prior to the <see cref="T:Xamarin.Forms.Page" /> becoming visible.
        /// </summary>
        /// <remarks>
        /// To be added.
        /// </remarks>
        protected override void OnAppearing()
        {
            base.OnAppearing();
            // DependencyService.Get<IDatabaseInterface>().LogoutWithFirebaseAuth();
            // Navigation.PushModalAsync(new LoginPage());
        }

        private void Logout_Clicked(object sender, System.EventArgs e)
        {
            DependencyService.Get<IDatabaseInterface>().LogoutWithFirebaseAuth();
            Navigation.PushModalAsync(new LoginPage());
        }
    }
}