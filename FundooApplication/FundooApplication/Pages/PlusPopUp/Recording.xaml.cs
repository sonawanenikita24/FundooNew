using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FundooApplication.Pages.PlusPopUp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Recording : ContentPage
	{
		public Recording (string noteid)
		{
			InitializeComponent ();
		}
	}
}