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
	public partial class Imagepage : ContentPage
	{
        /// <summary>
        /// Initializes a new instance of the <see cref="Imagepage"/> class.
        /// </summary>
        public Imagepage()
        {
            this.InitializeComponent();
            List<string> items = new List<string> { "Take photo", "Choose image" };
            sampleList.ItemsSource = items;
        }
    }
}