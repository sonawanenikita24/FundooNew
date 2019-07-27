//--------------------------------------------------------------------------------------------------------------------
// <copyright file="MasterMenuItems.cs" company="BridgeLabz">
// copyright @2019 
// </copyright>
// <creater name="Nikita Sonawane"/>
//------------------------------------------------------------------------------------------------------------------
namespace FundooApplication.Model
{
    using System;

    /// <summary>
    /// Master menu items
    /// </summary>
    public class MasterMenuItems
    {
        /// <summary>
        /// The text
        /// </summary>
        private string text;

        /// <summary>
        /// The details
        /// </summary>
        private string details;

        /// <summary>
        /// The image path
        /// </summary>
        private string imagePath;

        /// <summary>
        /// The target page
        /// </summary>
        private Type targetpage;

        /// <summary>
        /// Gets or sets the text.
        /// </summary>
        /// <value>
        /// The text.
        /// </value>
        public string Text
        {
            get
            {
                return this.text;
            }

            set
            {
                this.text = value;
            }
        }

        /// <summary>
        /// Gets or sets the details.
        /// </summary>
        /// <value>
        /// The details.
        /// </value>
        public string Details
        {
            get
            {
                return this.details;
            }

            set
            {
                this.details = value;
            }
        }

        /// <summary>
        /// Gets or sets the image path.
        /// </summary>
        /// <value>
        /// The image path.
        /// </value>
        public string Imagepath
        {
            get
            {
                return this.imagePath;
            }

            set
            {
                this.imagePath = value;
            }
        }

        /// <summary>
        /// Gets or sets the target page.
        /// </summary>
        /// <value>
        /// The target page.
        /// </value>
        public Type Targetpage
        {
            get
            {
                return this.targetpage;
            }

            set
            {
                this.targetpage = value;
            }
        }
    }
}