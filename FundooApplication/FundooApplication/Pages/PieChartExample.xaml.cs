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
	public partial class PieChartExample : ContentPage
	{
        /// <summary>
        /// The view model is instance of pie chart view model
        /// </summary>
        PieChartViewModel vm;

        /// <summary>
        /// Initializes a new instance of the <see cref="PieChartExample"/> class.
        /// </summary>
        public PieChartExample()
        {
            InitializeComponent();
            vm = new PieChartViewModel();
            this.BindingContext = vm;
        }
    }
}