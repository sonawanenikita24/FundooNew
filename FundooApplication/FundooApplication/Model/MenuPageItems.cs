using System;
using System.Collections.Generic;
using System.Text;

namespace FundooApplication.Model
{
    /// <summary>
    /// menu for taking image and text
    /// </summary>
    public class MenuPageItems
    {
        /// <summary>
        /// Gets or sets the icon.
        /// </summary>
        /// <value>
        /// The icon.
        /// </value>
        public string Icon { get; set; }

        /// <summary>
        /// Gets or sets the menu item.
        /// </summary>
        /// <value>
        /// The menu item.
        /// </value>
        public string MenuItem { get; set; }

        /// <summary>
        /// Gets or sets the type of the target.
        /// </summary>
        /// <value>
        /// The type of the target.
        /// </value>
        public Type TargetType { get; set; }
    }
}