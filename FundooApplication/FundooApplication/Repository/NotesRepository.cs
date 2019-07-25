using Firebase.Database;
using Firebase.Database.Query;
using Firebase.Storage;
using FundooApplication.Interfaces;
using FundooApplication.Model;
using Plugin.Toast;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace FundooApplication.Repository
{    
        /// <summary>
        /// Class contain methods for create , delete, update note
        /// </summary>
        public class NotesRepository
        {
            /// <summary>
            /// The firebase storage is instance of firebase storage to store the path of file
            /// </summary>
            FirebaseStorage firebaseStorage = new FirebaseStorage("fundooapplication-f0d55.appspot.com");

            /// <summary>
            /// The firebase is instance of firebase client
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
            /// Adds the note.
            /// </summary>
            /// <param name="text">The text.</param>
            /// <param name="note">The note.</param>
            /// <param name="location">The location.</param>
            /// <returns>return note </returns>
            public async Task AddNote(string text, string note, Location location)
            {
                try
                {
                    //// get current user id
                    var userid = DependencyService.Get<IDatabaseInterface>().GetId();
                    if (userid != null)
                    {
                        ////this is use to add the User record to the database with Firebase authentication Id 
                        await this.Firebase.Child("Users").Child(userid).Child("UserNotes").PostAsync(new Note()
                        {
                            Title = text,
                            UserNote = note,
                            NoteLocation = location
                        });
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            /// <summary>
            /// Gets the note by note identifier.
            /// </summary>
            /// <param name="id">The identifier.</param>
            /// <param name="uid">The user id.</param>
            /// <returns>return note by id</returns>
            public async Task<Note> GetNoteByNoteId(string id, string uid)
            {
                Note note = await this.Firebase.Child("Users").Child(uid).Child("UserNotes").Child(id).OnceSingleAsync<Note>();
                return note;
            }

            /// <summary>
            /// Gets the user note.
            /// </summary>
            /// <param name="key">The key.</param>
            /// <returns>return note</returns>
            public async Task<Note> GetUserNote(string key)
            {
                try
                {
                    //// get detail of current user id
                    var userid = DependencyService.Get<IDatabaseInterface>().GetId();

                    //// get user note
                    return await this.Firebase.Child("Users").Child(userid).Child("UserNotes").Child(key).OnceSingleAsync<Note>();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return null;
                }
            }

            /// <summary>
            /// Gets all user notes from the firebase database.
            /// </summary>
            /// <returns>List of notes</returns>
            public async Task<List<Note>> GetAllUserNotes()
            {
                try
                {
                    ////Get current user id
                    var currentUserId = DependencyService.Get<IDatabaseInterface>().GetId();

                    if (currentUserId != null)
                    {
                        ////Used to add the User record to the database with Firebase authentication Id
                        return (await this.Firebase.Child("Users").Child(currentUserId).Child("UserNotes").OnceAsync<Note>()).Select(item => new Note
                        {
                            Title = item.Object.Title,
                            UserNote = item.Object.UserNote,
                            Key = item.Key,
                            DateTime = item.Object.DateTime,
                            NoteColor = item.Object.NoteColor,
                            NoteType = item.Object.NoteType,
                            LabelsList = item.Object.LabelsList
                            ////CollaboratosList = item.Object.CollaboratosList                        
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
            /// Updates the user note.
            /// </summary>
            /// <param name="note">The note.</param>
            /// <param name="key">The key.</param>
            /// <returns>updated note</returns>
            public async Task UpdateUserNote(Note note, string key)
            {
                try
                {
                    //// get current user id
                    var userid = DependencyService.Get<IDatabaseInterface>().GetId();

                    //// used to update the record with selected note   
                    if (userid != null)
                    {
                        await this.Firebase.Child("Users").Child(userid).Child("UserNotes").Child(key).PutAsync<Note>(new Note()
                        {
                            Title = note.Title,
                            UserNote = note.UserNote,
                            NoteType = note.NoteType,
                            NoteColor = note.NoteColor,
                            LabelsList = note.LabelsList,
                            CollaboratosList = note.CollaboratosList
                        });
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            /// <summary>
            /// Deletes the note.
            /// </summary>
            /// <param name="id">The identifier.</param>
            /// <param name="uid">The user id.</param>
            /// <returns>return updated note</returns>
            public async Task DeleteNote(string id, string uid)
            {
                await this.Firebase.Child("Users").Child(uid).Child("UserNotes").Child(id).DeleteAsync();
            }

            /// <summary>
            /// Gets the trash notes.
            /// </summary>
            /// <returns>list of trashed notes</returns>
            public async Task<IList<TrashDataModel>> GetTrashNotes()
            {
                ////Get current user id
                var currentUserId = DependencyService.Get<IDatabaseInterface>().GetId();
                IList<TrashDataModel> trashNotesData = (await this.Firebase.Child("User").Child(currentUserId).Child("UserNotes").OnceAsync<TrashDataModel>()).Select(item => new TrashDataModel
                {
                    Title = item.Object.Title,
                    Notes = item.Object.Notes,
                    Key = item.Object.Key
                }).ToList();

                return trashNotesData;
            }

            /// <summary>
            /// Submits the notes.
            /// </summary>
            /// <param name="note">The note.</param>
            /// <returns>save note</returns>
            public async Task SubmitNotes(Note note)
            {
                try
                {
                    ////Get current user id
                    var currentUserId = DependencyService.Get<IDatabaseInterface>().GetId();
                    if (currentUserId != null)
                    {
                        ////Used to add the User record to the database with Firebase authentication Id
                        await this.firebase.Child("Users").Child(currentUserId).Child("UserNotes").PostAsync(new Note()
                        {
                            Title = note.Title,
                            UserNote = note.UserNote,
                            NoteLocation = note.NoteLocation,
                            NoteColor = note.NoteColor,
                            LabelsList = note.LabelsList,
                            DateTime = note.DateTime,
                            Imageurl = note.Imageurl
                        });
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine();
                }
            }

            /// <summary>
            /// Get images the source.
            /// </summary>
            /// <param name="id">The identifier.</param>
            /// <param name="imagesource">The image source.</param>
            /// <returns>add image url in database</returns>
            public async Task GetimageSouce(string id, string imagesource)
            {
                ////Get current user id
                var uid = DependencyService.Get<IDatabaseInterface>().GetId();
                ////  Note note = await this.GetUserNote(id);
                if (uid != null)
                {
                    await this.Firebase.Child("Users").Child(uid).Child("UserNotes").Child(id).PutAsync<Note>(new Note()
                    {
                        Imageurl = imagesource
                    });

                    CrossToastPopUp.Current.ShowToastMessage("Picture Uploaded in Note Successfully");
                }
            }

            /// <summary>
            /// Uploads the file.
            /// </summary>
            /// <param name="fileStream">The file stream.</param>
            /// <param name="fileName">Name of the file.</param>
            /// <returns>add file in database</returns>
            public async Task<string> UploadFile(Stream fileStream, string fileName)
            {
                var imageUrl = await this.firebaseStorage
                    .Child("Notes")
                    .Child("Images")
                    .Child(fileName)
                    .PutAsync(fileStream);
                return imageUrl;
            }

            /// <summary>
            /// Gets the file.
            /// </summary>
            /// <param name="fileName">Name of the file.</param>
            /// <returns>return file from firebase</returns>
            public async Task<string> GetFile(string fileName)
            {
                return await this.firebaseStorage
                     .Child("Notes")
                    .Child("Images")
                    .Child(fileName)
                    .GetDownloadUrlAsync();
            }

            /// <summary>
            /// Deletes the file.
            /// </summary>
            /// <param name="fileName">Name of the file.</param>
            /// <returns>delete file from database</returns>
            public async Task DeleteFile(string fileName)
            {
                await this.firebaseStorage
                     .Child("Notes")
                     .Child("Images")
                     .Child(fileName)
                     .DeleteAsync();
            }
        }
    }