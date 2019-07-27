//--------------------------------------------------------------------------------------------------------------------
// <copyright file="Imagepage.cs" company="BridgeLabz">
// copyright @2019 
// </copyright>
// <creater name="Nikita Sonawane"/>
//------------------------------------------------------------------------------------------------------------------
namespace FundooApplication.Pages
{
    using System.Collections.Generic;
    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;

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