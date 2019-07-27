//--------------------------------------------------------------------------------------------------------------------
// <copyright file="PlusPopUpPage.cs" company="BridgeLabz">
// copyright @2019 
// </copyright>
// <creater name="Nikita Sonawane"/>
//------------------------------------------------------------------------------------------------------------------
namespace FundooApplication.Pages.PlusPopUp
{
    using System;
    using System.Collections.Generic;
    using FundooApplication.Model;
    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;

    /// <summary>
    /// pop up menu when plus button clicked
    /// </summary>
    /// <seealso cref="Rg.Plugins.Popup.Pages.PopupPage" />
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PlusPopUpPage
    {
        /// <summary>
        /// The menu item list
        /// </summary>
        private List<MenuPageItems> menuitemlist;

        /// <summary>
        /// The note page color
        /// </summary>
        private string notePageColor = "White";

        /// <summary>
        /// The note id
        /// </summary>
        private string noteid;

        /// <summary>
        /// Initializes a new instance of the <see cref="PlusPopUpPage"/> class.
        /// </summary>
        /// <param name="noteKey">The note key.</param>
        public PlusPopUpPage(string noteKey)
        {
            this.Noteid = noteKey;
            InitializeComponent();
            PlusmenuPopList.ItemsSource = this.GetMenuList();
        }

        /// <summary>
        /// Gets or sets the menu item list.
        /// </summary>
        /// <value>
        /// The menu item list.
        /// </value>
        public List<MenuPageItems> Menuitemlist
        {
            get
            {
                return this.menuitemlist;
            }

            set
            {
                this.menuitemlist = value;
            }
        }

        /// <summary>
        /// Gets or sets the color of the note page.
        /// </summary>
        /// <value>
        /// The color of the note page.
        /// </value>
        public string NotePageColor
        {
            get
            {
                return this.notePageColor;
            }

            set
            {
                this.notePageColor = value;
            }
        }

        /// <summary>
        /// Gets or sets the note id.
        /// </summary>
        /// <value>
        /// The note id.
        /// </value>
        public string Noteid
        {
            get
            {
                return this.noteid;
            }

            set
            {
                this.noteid = value;
            }
        }

        /// <summary>
        /// Gets the menu list.
        /// </summary>
        /// <returns>return list</returns>
        private List<MenuPageItems> GetMenuList()
        {
            this.Menuitemlist = new List<MenuPageItems>();
            try
            {
                this.Menuitemlist.Add(new MenuPageItems()
                {
                    Icon = "camera.png",
                    MenuItem = "Take photo",
                    TargetType = typeof(Camera)
                });

                this.menuitemlist.Add(new MenuPageItems()
                {
                    Icon = "imageinsert.png",
                    MenuItem = "Choose Image",
                    TargetType = typeof(ChooseImage)
                });

                this.Menuitemlist.Add(new MenuPageItems()
                {
                    Icon = "brush.png",
                    MenuItem = "Drawing",
                    TargetType = typeof(Drawaing)
                });

                this.Menuitemlist.Add(new MenuPageItems()
                {
                    Icon = "microphone.png",
                    MenuItem = "Recording",
                    TargetType = typeof(Recording)
                });

                this.Menuitemlist.Add(new MenuPageItems()
                {
                    Icon = "checkbox",
                    MenuItem = "Checkboxes",
                    TargetType = typeof(CheckBoxes)
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return this.Menuitemlist;
        }

        /// <summary>
        /// Menus the item selected.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="SelectedItemChangedEventArgs"/> instance containing the event data.</param>
        private void MenuItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            try
            {
                var menu = (MenuPageItems)e.SelectedItem;
                string menuitems = menu.MenuItem;

                if (menuitems == "Take photo")
                {
                    Navigation.PushModalAsync(new Camera(this.Noteid));
                    IsVisible = false;
                }
                else if (menuitems == "Choose Image")
                {
                    Navigation.PushModalAsync(new ChooseImage(this.Noteid));
                    IsVisible = false;
                }
                else if (menuitems == "Drawing")
                {
                    Navigation.PushModalAsync(new Drawaing(this.Noteid));
                    IsVisible = false;
                }
                else if (menuitems == "Recording")
                {
                    Navigation.PushModalAsync(new Recording(this.Noteid));
                    IsVisible = false;
                }
                else if (menuitems == "Checkboxes")
                {
                    Navigation.PushModalAsync(new CheckBoxes(this.Noteid));
                    IsVisible = false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}