//--------------------------------------------------------------------------------------------------------------------
// <copyright file="NoteLabel.cs" company="BridgeLabz">
// copyright @2019 
// </copyright>
// <creater name="Nikita Sonawane"/>
//------------------------------------------------------------------------------------------------------------------
namespace FundooApplication.Model
{
    /// <summary>
    /// Label model class for adding label property to the note 
    /// </summary>
    public class NoteLabel
    {
        /// <summary>
        /// The note label
        /// </summary>
        private string notelabel;

        /// <summary>
        /// The label key
        /// </summary>
        private string labelkey;

        /// <summary>
        /// Gets or sets the note label.
        /// </summary>
        /// <value>
        /// The note label.
        /// </value>
        public string Noteslabel
        {
            get
            {
                return this.notelabel;
            }

            set
            {
                this.notelabel = value;
            }
        }

        /// <summary>
        /// Gets or sets the label key.
        /// </summary>
        /// <value>
        /// The label key.
        /// </value>
        public string Labelkey
        {
            get
            {
                return this.labelkey;
            }

            set
            {
                this.labelkey = value;
            }
        }
    }
}