//--------------------------------------------------------------------------------------------------------------------
// <copyright file="CollaboratorRepository.cs" company="BridgeLabz">
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

    public class CollaboratorRepository
    {
        /// <summary>
        /// Data base URL
        /// </summary>
        FirebaseClient Firebase = new FirebaseClient("https://fundooapplication-f0d55.firebaseio.com/");

        /// <summary>
        /// Creates the collaborator.
        /// </summary>
        /// <param name="collaborater">The collaborate.</param>
        /// <returns>added in database</returns>
        public async Task CreateCollaborator(string collaborater)
        {
            var users = await Firebase.Child("Users").OnceAsync<RegisterUser>();
            var userid = DependencyService.Get<IDatabaseInterface>().GetId();
            await this.Firebase.Child("Users").Child(userid).Child("collaborators").PostAsync<CollaboratorMadel>(new CollaboratorMadel
            {
                Email = collaborater
            });
        }

        /// <summary>
        /// Deletes the collaborator.
        /// </summary>
        /// <param name="collborateKey">The collaborate key.</param>
        public void DeleteCollaborator(string collborateKey)
        {
            try
            {
                ////Get current user id
                var currentUserId = DependencyService.Get<IDatabaseInterface>().GetId();

                ////delete the data from the database
                this.Firebase.Child("Users").Child(currentUserId).Child("collaborators").Child(collborateKey).DeleteAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        /// <summary>
        /// Gets the collaborator data.
        /// </summary>
        /// <param name="ckey">The c key.</param>
        /// <returns>return data</returns>
        public async Task<CollaboratorMadel> GetCollaboratorData(string ckey)
        {
            try
            {
                var userid = DependencyService.Get<IDatabaseInterface>().GetId();

                return await this.Firebase.Child("Users").Child(userid).Child("collaborators").Child(ckey).OnceSingleAsync<CollaboratorMadel>();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        /// <summary>
        /// Gets all labels.
        /// </summary>
        /// <returns>return list</returns>
        public async Task<List<CollaboratorMadel>> GetAllcollaborators()
        {
            try
            {
                ////Get current user id
                var userId = DependencyService.Get<IDatabaseInterface>().GetId();

                if (userId != null)
                {
                    ////Used to add the User note label to the database with Firebase authentication Id
                    return (await this.Firebase.Child("Users").Child(userId).Child("collaborators").OnceAsync<CollaboratorMadel>()).Select(item => new CollaboratorMadel
                    {
                        Email = item.Object.Email
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
        /// Updates the labels to notes.
        /// </summary>
        /// <param name="note">The note.</param>
        /// <param name="keyNote">The key note.</param>
        public async void UpdateCollaboratorToNotes(Note note, string keyNote)
        {
            ////Get current user id
            var currentUserId = DependencyService.Get<IDatabaseInterface>().GetId();

            ////Update note
            await this.Firebase.Child("Users").Child(currentUserId).Child("UserNotes").Child(keyNote).PutAsync(new Note()
            {
                Title = note.Title,
                UserNote = note.UserNote,
                LabelsList = note.LabelsList,
                CollaboratosList = note.CollaboratosList,
                NoteType = note.NoteType,
                NoteColor = note.NoteColor,
            });
        }

        /// <summary>
        /// Updates the labels to notes.
        /// </summary>
        /// <param name="note">The note.</param>
        /// <param name="keyNote">The key note.</param>
        public async void DeletecollaboratorsFromNotes(Note note, string keyNote)
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