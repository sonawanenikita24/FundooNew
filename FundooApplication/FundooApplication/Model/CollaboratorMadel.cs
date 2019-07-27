//--------------------------------------------------------------------------------------------------------------------
// <copyright file="CollaboratorMadel.cs" company="BridgeLabz">
// copyright @2019 
// </copyright>
// <creater name="Nikita Sonawane"/>
//------------------------------------------------------------------------------------------------------------------
namespace FundooApplication.Model
{
    public class CollaboratorMadel
    {
        /// <summary>
        /// The sender mail
        /// </summary>
        private string senderMail;

        /// <summary>
        /// The receiver mail
        /// </summary>
        private string receiverMail;

        /// <summary>
        /// The note identifier
        /// </summary>
        private string noteId;

        /// <summary>
        /// The email
        /// </summary>
        private string email;

        /// <summary>
        /// Gets or sets the sender mail.
        /// </summary>
        /// <value>
        /// The sender mail.
        /// </value>
        public string SenderMail
        {
            get
            {
                return this.senderMail;
            }

            set
            {
                this.senderMail = value;
            }
        }

        /// <summary>
        /// Gets or sets the receiver mail.
        /// </summary>
        /// <value>
        /// The receiver mail.
        /// </value>
        public string ReceiverMail
        {
            get
            {
                return this.receiverMail;
            }

            set
            {
                this.receiverMail = value;
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
        /// Gets or sets the email.
        /// </summary>
        /// <value>
        /// The email.
        /// </value>
        public string Email
        {
            get
            {
                return this.email;
            }

            set
            {
                this.email = value;
            }
        }

        public string CKey { get; set; }
    }
}
