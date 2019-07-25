using System;
using System.Collections.Generic;
using System.Text;

namespace FundooApplication.Model
{
    /// <summary>
    /// Type of note
    /// </summary>
    public class TypeOfNote
    {
        /// <summary>
        /// this is instance for note type
        /// </summary>
        public enum NoteType
        {
            /// <summary>
            /// set to be true if it is note
            /// </summary>
            isNote,

            /// <summary>
            /// set to be true if note is marked archive
            /// </summary>
            isArchive,

            /// <summary>
            /// set to be true if note is marked trash
            /// </summary>
            isTrash,

            /// <summary>
            /// set to be true if note is marked pinned
            /// </summary>
            ispin,

            //// iscollaborated
        }

        /// <summary>
        /// view type
        /// </summary>
        public enum ViewType
        {
            /// <summary>
            /// The list view
            /// </summary>
            listView,

            /// <summary>
            /// The grid view
            /// </summary>
            gridView
        }
    }
}