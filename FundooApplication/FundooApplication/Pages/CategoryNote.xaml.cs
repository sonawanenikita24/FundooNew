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
	public partial class CategoryNote : ContentPage
	{
        /// <summary>
        /// Initializes a new instance of the <see cref="CategoryNote"/> class.
        /// </summary>
        public CategoryNote()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the clicked event of the Bar chart Button control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void BarchartButton_clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new SettingPage());
        }

        /// <summary>
        /// Handles the Clicked event of the Pie Chart Button control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void PieChartButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PieChartExample());
        }
    }
}