//--------------------------------------------------------------------------------------------------------------------
// <copyright file="DashBoard.cs" company="BridgeLabz">
// copyright @2019 
// </copyright>
// <creater name="Nikita Sonawane"/>
//------------------------------------------------------------------------------------------------------------------
namespace FundooApplication.Pages
{
    using System;
    using System.Collections.Generic;
    using Firebase.Database;
    using FundooApplication.Model;
    using FundooApplication.Repository;
    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DashBoard : MasterDetailPage
    {
        /// <summary>
        /// The firebase client
        /// </summary>
        private FirebaseClient firebaseClient = new FirebaseClient("https://fundooapplication-f0d55.firebaseio.com/");

        /// <summary>
        /// Initializes a new instance of the <see cref="Dashboard"/> class.
        /// </summary>
        public DashBoard()
        {
            this.InitializeComponent();

            OnAppearing();

            //// to add item in master menu
            navigationDrawerList.ItemsSource = this.GetMenuList();

            var homepage = typeof(NotesPage);
            this.Detail = new NavigationPage((Page)Activator.CreateInstance(homepage));
            this.IsPresented = false;
            this.SetProfilePic();
        }

        /// <summary>
        /// set the profile pic tap recognizer here
        /// </summary>
        private void SetProfilePic()
        {
            var userImage = new TapGestureRecognizer();
            userImage.Tapped += UserImage_Tapped;
            ProfilePic.GestureRecognizers.Add(userImage);
        }

        /// <summary>
        /// Handles the profile pic tap event
        /// </summary>
        /// <param name="sender">circle image</param>
        /// <param name="e">event arguments</param>
        private void UserImage_Tapped(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new GalleryPermission());
        }

        /// <summary>
        /// Gets or sets the firebase client.
        /// </summary>
        /// <value>
        /// The firebase client.
        /// </value>
        public FirebaseClient FirebaseClient { get => firebaseClient; set => firebaseClient = value; }

        /// <summary>
        /// Gets the menu list.
        /// </summary>
        /// <returns>list of menu</returns>
        public List<MasterMenuItems> GetMenuList()
        {
            //// creating new list of menu items    
            var list = new List<MasterMenuItems>();

            try
            {
                //// adding element into list
                list.Add(new MasterMenuItems
                {
                    Text = "Notes",
                    Imagepath = "notes.png",
                    Targetpage = typeof(NotesPage)
                });

                list.Add(new MasterMenuItems
                {
                    Text = "Reminders",
                    Imagepath = "Reminders.png",
                    Targetpage = typeof(RemindersPage)
                });

                list.Add(new MasterMenuItems
                {
                    Text = "create new label",
                    Imagepath = "CreateLabel.png",
                    Targetpage = typeof(CreateLabelPage)
                });

                /*  list.Add(new MasterMenuItems
                  {
                      Text = "create collborators",
                      Imagepath = "collaborator.png",
                      Targetpage = typeof(CreateCollaborator)
                  });*/

                list.Add(new MasterMenuItems
                {
                    Text = "Archive",
                    Imagepath = "archive.png",
                    Targetpage = typeof(ArchivePage)
                });

                list.Add(new MasterMenuItems
                {
                    Text = "Trash",
                    Imagepath = "trash.png",
                    Targetpage = typeof(TrashPage)
                });

                list.Add(new MasterMenuItems
                {
                    Text = "Settings",
                    Imagepath = "setting.png",
                    Targetpage = typeof(CategoryNote)
                });

                list.Add(new MasterMenuItems
                {
                    Text = "Logout",
                    Imagepath = "logout.png",
                    Targetpage = typeof(LogoutPage)
                });

                /*   list.Add(new MasterMenuItems
                   {
                       Text="Camera",
                       Imagepath="",
                       Targetpage=typeof(Camera)

                   });*/
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return list;
        }

        /// <summary>
        /// Indicates that the <see cref="T:Xamarin.Forms.Page" /> has been assigned a size.
        /// </summary>
        /// <param name="width">The width allocated to the <see cref="T:Xamarin.Forms.Page" />.</param>
        /// <param name="height">The height allocated to the <see cref="T:Xamarin.Forms.Page" />.</param>
        /// <remarks>
        /// To be added.
        /// </remarks>
        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);
        }

        /// <summary>
        /// Called when [item selected].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="SelectedItemChangedEventArgs"/> instance containing the event data.</param>
        private void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            try
            {
                var selectedItems = (MasterMenuItems)e.SelectedItem;
                Type selectedPage = selectedItems.Targetpage;
                this.Detail = new NavigationPage((Page)Activator.CreateInstance(selectedPage));
                this.IsPresented = false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// On appearing of the page these actions need to be taken
        /// </summary>
        protected async override void OnAppearing()
        {
            UserRepository userRepository = new UserRepository();
            RegisterUser user = await userRepository.GetRegisterUserById();
            if (user.Imageurl != null)
            {
                var imgSrc = new UriImageSource { Uri = new Uri(user.Imageurl) };
                imgSrc.CachingEnabled = false;
                ProfilePic.Source = imgSrc;
                ProfilePic.HeightRequest = 70;
                ProfilePic.WidthRequest = 70;
            }

            base.OnAppearing();
            ProfilePic.BorderColor = Color.DarkGray;
        }
    }
}