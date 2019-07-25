using FundooApplication.Model;
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
	public partial class PopUpPage 
	{
        /// <summary>
        /// The menu item list
        /// </summary>
        private List<MenuPageItems> menuitemlist;

        /// <summary>
        /// The note page color
        /// </summary>
        private string notepagecolor = "White";

        /// <summary>
        /// The note identifier
        /// </summary>
        private string noteId;

        /// <summary>
        /// Initializes a new instance of the <see cref="PopUpPage"/> class.
        /// </summary>
        /// <param name="notekey">The note key.</param>
        public PopUpPage(string notekey)
        {
            this.NoteId = notekey;
            InitializeComponent();

            //// getting list of menu items in pop up page
            menuPopList.ItemsSource = this.GetMenuList();
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
        /// Gets or sets the note page color.
        /// </summary>
        /// <value>
        /// The note page color.
        /// </value>
        public string Notepagecolor
        {
            get
            {
                return this.notepagecolor;
            }

            set
            {
                this.notepagecolor = value;
            }
        }

        /// <summary>
        /// Gets or sets the note identifier.
        /// </summary>
        /// <value>
        /// The note identifier.
        /// </value>
        public string NoteId
        {
            get
            {
                return this.noteId;
            }

            set
            {
                this.noteId = value;
            }
        }

        /// <summary>
        /// Gets the menu list.
        /// </summary>
        /// <returns>return menu</returns>
        public List<MenuPageItems> GetMenuList()
        {
            this.Menuitemlist = new List<MenuPageItems>();
            try
            {
                this.Menuitemlist.Add(new MenuPageItems()
                {
                    Icon = "trash.png",
                    MenuItem = "Delete",
                    TargetType = typeof(DeletePage)
                });

                this.Menuitemlist.Add(new MenuPageItems()
                {
                    Icon = "copy.png",
                    MenuItem = "Make a copy",
                    TargetType = typeof(CopyPage)
                });

                this.Menuitemlist.Add(new MenuPageItems()
                {
                    Icon = "share.png",
                    MenuItem = "Send",
                    TargetType = typeof(SharePage)
                });

                this.Menuitemlist.Add(new MenuPageItems()
                {
                    Icon = "collaborator.png",
                    MenuItem = "Collaborator",
                    //// TargetType = typeof(CollaboratorPage)
                    TargetType = typeof(CollaboratorPage)
                });

                this.Menuitemlist.Add(new MenuPageItems()
                {
                    Icon = "labelicon.png",
                    MenuItem = "Labels",
                    TargetType = typeof(LabelPage)
                });

                /*  menuitemlist.Add(new MenuPageItems()
                  {
                      Icon="",
                      MenuItem="",
                      TargetType=typeof(NotePage)
                  })*/
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return this.Menuitemlist;
        }
       

        /// <summary>
        /// Handles the Clicked event of the SkyBlue control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void SkyBlue_Clicked(object sender, EventArgs e)
        {
            BackgroundColor = Color.SkyBlue;
        }

        /// <summary>
        /// Handles the Clicked event of the Orange control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void Orange_Clicked(object sender, EventArgs e)
        {
            this.BackgroundColor = Color.Orange;
        }

        /// <summary>
        /// Handles the Clicked event of the Red control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void Red_Clicked(object sender, EventArgs e)
        {
            this.BackgroundColor = Color.Red;
        }

        /// <summary>
        /// Handles the Clicked event of the Yellow control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void Yellow_Clicked(object sender, EventArgs e)
        {
            this.BackgroundColor = Color.Yellow;
        }

        /// <summary>
        /// Handles the Clicked event of the Violet control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void Violet_Clicked(object sender, EventArgs e)
        {
            this.BackgroundColor = Color.Violet;
        }

        /// <summary>
        /// Handles the Clicked event of the Purple control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void Purple_Clicked(object sender, EventArgs e)
        {
            this.BackgroundColor = Color.Purple;
        }

        /// <summary>
        /// Handles the Clicked event of the Gray control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void Gray_Clicked(object sender, EventArgs e)
        {
            this.BackgroundColor = Color.Gray;
        }

        /// <summary>
        /// Handles the Clicked event of the Gold control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void Gold_Clicked(object sender, EventArgs e)
        {
            this.BackgroundColor = Color.Gold;
        }

        /// <summary>
        /// Handles the Clicked event of the Salmon control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void Salmon_Clicked(object sender, EventArgs e)
        {
            this.BackgroundColor = Color.Salmon;
        }

        /// <summary>
        /// Handles the Clicked event of the Green control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void Green_Clicked(object sender, EventArgs e)
        {
            this.BackgroundColor = Color.Green;
        }

        /// <summary>
        /// Handles the Clicked event of the Pink control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void Pink_Clicked(object sender, EventArgs e)
        {
            this.BackgroundColor = Color.Pink;
        }

        /// <summary>
        /// Handles the Clicked event of the Brown control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void Brown_Clicked(object sender, EventArgs e)
        {
            this.BackgroundColor = Color.Brown;
        }

        /// <summary>
        /// Handles the Clicked event of the MidnightBlue control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void MidnightBlue_Clicked(object sender, EventArgs e)
        {
            this.BackgroundColor = Color.MidnightBlue;
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
                //// storing selected menu item in variable
                var menu = (MenuPageItems)e.SelectedItem;

                //// get menu item 
                string menuitems = menu.MenuItem;

                //// check with menu text to navigate to the proper menu pages
                if (menuitems == "Delete")
                {
                    Navigation.PushModalAsync(new DeletePage(this.NoteId));
                    IsVisible = false;
                }

                if (menuitems == "Send")
                {
                    Navigation.PushModalAsync(new SharePage(this.NoteId));
                    IsVisible = false;
                }

                if (menuitems == "Make a copy")
                {
                    Navigation.PushModalAsync(new CopyPage(this.NoteId));
                    IsVisible = false;
                }

                if (menuitems == "Collaborator")
                {
                    Navigation.PushModalAsync(new CollaboratorPage(this.NoteId));
                    IsVisible = false;
                }

                if (menuitems == "Labels")
                {
                    Navigation.PushModalAsync(new LabelPage(this.NoteId));
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