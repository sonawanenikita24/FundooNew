//--------------------------------------------------------------------------------------------------------------------
// <copyright file="TrashDataModel.cs" company="BridgeLabz">
// copyright @2019 
// </copyright>
// <creater name="Nikita Sonawane"/>
//------------------------------------------------------------------------------------------------------------------
namespace FundooApplication.Model
{
    /// <summary>
    /// model class for trash data
    /// </summary>
    public class TrashDataModel
    {
        /// <summary>
        /// The key
        /// </summary>
        private string key;

        /// <summary>
        /// The title
        /// </summary>
        private string title;

        /// <summary>
        /// The notes
        /// </summary>
        private string notes;

        /// <summary>
        /// Gets or sets the key.
        /// </summary>
        /// <value>
        /// The key.
        /// </value>
        public string Key
        {
            get
            {
                return this.key;
            }

            set
            {
                this.key = value;
            }
        }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>
        /// The title.
        /// </value>
        public string Title
        {
            get
            {
                return this.title;
            }

            set
            {
                this.title = value;
            }
        }

        /// <summary>
        /// Gets or sets the notes.
        /// </summary>
        /// <value>
        /// The notes.
        /// </value>
        public string Notes
        {
            get
            {
                return this.notes;
            }

            set
            {
                this.notes = value;
            }
        }
    }
}
