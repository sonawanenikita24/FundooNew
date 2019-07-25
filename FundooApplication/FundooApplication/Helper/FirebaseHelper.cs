using Firebase.Storage;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace FundooApplication.Helper
{
    /// <summary>
    /// Firebase helper class contain method for add, update and delete image from firebase storage
    /// </summary>
    public class FirebaseHelper
    {
        /// <summary>
        /// The firebase storage instance to store path of firebase storage
        /// </summary>
        FirebaseStorage firebaseStorage = new FirebaseStorage("fundooapplication-f0d55.appspot.com");

        /// <summary>
        /// Uploads the file.
        /// </summary>
        /// <param name="fileStream">The file stream.</param>
        /// <param name="fileName">Name of the file.</param>
        /// <returns>return upload file url </returns>
        public async Task<string> UploadFile(Stream fileStream, string fileName)
        {
            var imageUrl = await this.firebaseStorage
                .Child("Images")
                .Child(fileName)
                .PutAsync(fileStream);
            return imageUrl;
        }

        /// <summary>
        /// Gets the file.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <returns>download file</returns>
        public async Task<string> GetFile(string fileName)
        {
            return await this.firebaseStorage
                .Child("Images")
                .Child(fileName)
                .GetDownloadUrlAsync();
        }

        /// <summary>
        /// Deletes the file.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <returns>delete file</returns>
        public async Task DeleteFile(string fileName)
        {
            await this.firebaseStorage
                 .Child("Images")
                 .Child(fileName)
                 .DeleteAsync();
        }
    }
}