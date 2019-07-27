//--------------------------------------------------------------------------------------------------------------------
// <copyright file="FrameColorSetter.cs" company="BridgeLabz">
// copyright @2019 
// </copyright>
// <creater name="Nikita Sonawane"/>
//------------------------------------------------------------------------------------------------------------------
namespace FundooApplication.ViewModels
{
    using FundooApplication.Model;
    using Xamarin.Forms;

    /// <summary>
    /// this FrameColorSetter class instance
    /// </summary>
    /// <seealso cref="Xamarin.Forms.ContentPage" />
    public class FrameColorSetter : ContentPage
    {
        /// <summary>
        /// Gets the color.
        /// </summary>
        /// <param name="note">The note.</param>
        /// <param name="frame">The frame.</param>
        public static Color GetColor(Note note, Frame frame)
        {
            if (note.NoteColor.Equals("Red"))
            {
                frame.BackgroundColor = Color.Red;
                return Color.Red;
            }

            if (note.NoteColor.Equals("Aqua"))
            {
                frame.BackgroundColor = Color.Aqua;
                return Color.Aqua;
            }

            if (note.NoteColor.Equals("DarkGoldenrod"))
            {
                frame.BackgroundColor = Color.DarkGoldenrod;
                return Color.DarkGoldenrod;
            }

            if (note.NoteColor.Equals("Gold"))
            {
                frame.BackgroundColor = Color.Gold;
                return Color.Gold;
            }

            if (note.NoteColor.Equals("GreenYellow"))
            {
                frame.BackgroundColor = Color.GreenYellow;
                return Color.GreenYellow;
            }

            if (note.NoteColor.Equals("Gray"))
            {
                frame.BackgroundColor = Color.Gray;
                return Color.Gray;
            }

            if (note.NoteColor.Equals("Lavender"))
            {
                frame.BackgroundColor = Color.Lavender;
                return Color.Lavender;
            }

            if (note.NoteColor.Equals("MintCream"))
            {
                frame.BackgroundColor = Color.MintCream;
                return Color.MintCream;
            }

            if (note.NoteColor.Equals("White"))
            {
                frame.BackgroundColor = Color.White;
                return Color.White;
            }

            if (note.NoteColor.Equals("Green"))
            {
                frame.BackgroundColor = Color.Green;
                return Color.Green;
            }

            if (note.NoteColor.Equals("Yellow"))
            {
                frame.BackgroundColor = Color.Yellow;
                return Color.Yellow;
            }

            if (note.NoteColor.Equals("Orange"))
            {
                frame.BackgroundColor = Color.Orange;
                return Color.Orange;
            }

            if (note.NoteColor.Equals("Teal"))
            {
                frame.BackgroundColor = Color.Teal;
                return Color.Teal;
            }

            if (note.NoteColor.Equals("Purple"))
            {
                frame.BackgroundColor = Color.Purple;
                return Color.Purple;
            }

            if (note.NoteColor.Equals("Brown"))
            {
                frame.BackgroundColor = Color.Brown;
                return Color.Brown;
            }

            else
            {
                return Color.White;
            }
        }

        /// <summary>
        /// Gets the color of the hexadecimal.
        /// </summary>
        /// <param name="note">The note.</param>
        /// <returns>return task</returns>
        public static string GetHexColor(Note note)
        {
            if (note.NoteColor.Equals("Green"))
            {
                return "008000";
            }

            if (note.NoteColor.Equals("Aqua"))
            {
                return "00ffff";
            }

            if (note.NoteColor.Equals("DarkGoldenrod"))
            {
                return "b8860b";
            }

            if (note.NoteColor.Equals("Gold"))
            {
                return "ffd700";
            }

            if (note.NoteColor.Equals("GreenYellow"))
            {
                return "adff2f";
            }

            if (note.NoteColor.Equals("Gray"))
            {
                return "808080";
            }

            if (note.NoteColor.Equals("Lavender"))
            {
                return "e6e6fa";
            }

            if (note.NoteColor.Equals("MintCream"))
            {
                return "f5fffa";
            }

            return "ffffff";
        }
    }
}