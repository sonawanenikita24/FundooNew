using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FundooApplication.Pages.PopUpPages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DeleteCollaboratorPage : ContentPage
	{
        /// <summary>
        /// The value
        /// </summary>
        string value = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="DeleteCollaboratorPage"/> class.
        /// </summary>
        /// <param name="key">The key.</param>
        public DeleteCollaboratorPage(string key)
        {
            InitializeComponent();
            this.value = key;
        }
    }
}