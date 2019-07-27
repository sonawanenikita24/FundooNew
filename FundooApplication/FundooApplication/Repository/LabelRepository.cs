//--------------------------------------------------------------------------------------------------------------------
// <copyright file="LabelRepository.cs" company="BridgeLabz">
// copyright @2019 
// </copyright>
// <creater name="Nikita Sonawane"/>
//------------------------------------------------------------------------------------------------------------------
namespace FundooApplication.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Firebase.Database;
    using Firebase.Database.Query;
    using FundooApplication.Interfaces;
    using FundooApplication.Model;
    using Xamarin.Forms;

    /// <summary>
    /// Label helper class to get label from database
    /// </summary>
    public class LabelRepository
    {
        /// <summary>
        /// The firebase
        /// </summary>
        private FirebaseClient firebase = new FirebaseClient("https://fundooapplication-f0d55.firebaseio.com/");

        /// <summary>
        /// Gets or sets the firebase.
        /// </summary>
        /// <value>
        /// The firebase.
        /// </value>
        public FirebaseClient Firebase
        {
            get
            {
                return this.firebase;
            }

            set
            {
                this.firebase = value;
            }
        }

        /// <summary>
        /// Submits the label.
        /// </summary>
        /// <param name="noteLabel">The note label.</param>
        /// <returns>return label added </returns>
        public async Task SubmitLabel(NoteLabel noteLabel)
        {
            try
            {
                var userid = DependencyService.Get<IDatabaseInterface>().GetId();
                if (userid != null)
                {
                    await this.Firebase.Child("Users").Child(userid).Child("Labels").PostAsync(new NoteLabel()
                    {
                        Noteslabel = noteLabel.Noteslabel
                    });
                }
            }
            catch (Exception)
            {
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Creates the label.
        /// </summary>
        /// <param name="label">The label.</param>
        /// <returns>new label created</returns>
        public async Task CreateLabel(string label)
        {
            var userid = DependencyService.Get<IDatabaseInterface>().GetId();
            await this.Firebase.Child("Users").Child(userid).Child("Labels").PostAsync<NoteLabel>(new NoteLabel
            {
                Noteslabel = label
            });
        }

        /// <summary>
        /// Gets all labels.
        /// </summary>
        /// <returns>return list</returns>
        public async Task<List<NoteLabel>> GetAllLabels()
        {
            try
            {
                ////Get current user id
                var userId = DependencyService.Get<IDatabaseInterface>().GetId();

                if (userId != null)
                {
                    ////Used to add the User note label to the database with Firebase authentication Id
                    return (await this.Firebase.Child("Users").Child(userId).Child("Labels").OnceAsync<NoteLabel>()).Select(item => new NoteLabel
                    {
                        Noteslabel = item.Object.Noteslabel,
                        Labelkey = item.Key,
                    }).ToList();
                }
                else
                {
                    return null;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        /// <summary>
        /// Gets the label from the database.
        /// </summary>
        /// <param name="labelKey">The label key.</param>
        /// <returns>return note label</returns>
        public async Task<NoteLabel> GetLabel(string labelKey)
        {
            try
            {
                ////Get current user id
                var userid = DependencyService.Get<IDatabaseInterface>().GetId();

                ////Get label
                return await this.Firebase.Child("Users").Child(userid).Child("Labels").Child(labelKey).OnceSingleAsync<NoteLabel>();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        /// <summary>
        /// Updates the label.
        /// </summary>
        /// <param name="noteLabel">The note label.</param>
        /// <param name="labelKey">The label key.</param>
        public void UpdateLabel(NoteLabel noteLabel, string labelKey)
        {
            try
            {
                ////Get current user id
                var userid = DependencyService.Get<IDatabaseInterface>().GetId();

                if (userid != null)
                {
                    ////Used to add the User record to the database with Firebase authentication Id
                    this.Firebase.Child("Users").Child(userid).Child("Labels").Child(labelKey).PutAsync<NoteLabel>(new NoteLabel
                    {
                        Noteslabel = noteLabel.Noteslabel
                    });
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        /// <summary>
        /// Deletes the label from the database.
        /// </summary>
        /// <param name="labelKey">The label key.</param>
        public void DeleteLabel(string labelKey)
        {
            try
            {
                ////Get current user id
                var currentUserId = DependencyService.Get<IDatabaseInterface>().GetId();

                ////delete the data from the database
                this.Firebase.Child("Users").Child(currentUserId).Child("Labels").Child(labelKey).DeleteAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        /// <summary>
        /// Updates the labels to notes.
        /// </summary>
        /// <param name="note">The note.</param>
        /// <param name="keyNote">The key note.</param>
        public async void UpdateLabelsToNotes(Note note, string keyNote)
        {
            ////Get current user id
            var currentUserId = DependencyService.Get<IDatabaseInterface>().GetId();

            ////Update note
            await this.Firebase.Child("Users").Child(currentUserId).Child("UserNotes").Child(keyNote).PutAsync(new Note()
            {
                Title = note.Title,
                UserNote = note.UserNote,
                LabelsList = note.LabelsList,
                NoteType = note.NoteType,
                NoteColor = note.NoteColor
            });
        }

        /// <summary>
        /// Updates the labels to notes.
        /// </summary>
        /// <param name="note">The note.</param>
        /// <param name="keyNote">The key note.</param>
        public async void DeleteLabelsFromNotes(Note note, string keyNote)
        {
            ////Get current user id
            var currentUserId = DependencyService.Get<IDatabaseInterface>().GetId();

            ////Update note
            await this.Firebase.Child("Users").Child(currentUserId).Child("UserNotes").Child(keyNote).PutAsync(new Note()
            {
                Title = note.Title,
                UserNote = note.UserNote,
                NoteType = note.NoteType,
                NoteColor = note.NoteColor
            });
        }
    }
}