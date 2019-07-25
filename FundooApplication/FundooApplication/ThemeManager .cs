using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace FundooApplication
{
    /// <summary>
    /// Manages theme of the page
    /// </summary>
    public class ThemeManager
    {
        /// <summary>
        /// Changes the theme.
        /// </summary>
        /// <param name="themeName">Name of the theme.</param>
        public static void ChangeTheme(string themeName)
        {
            Application.Current.Resources.Clear();
            Application.Current.Resources.MergedDictionaries.Clear();
            var type = typeof(ThemeManager);
            var uri = $"{type.Assembly.GetName().Name}.Themes.{themeName}";
            var theme = Type.GetType(uri);
            Application.Current.Resources.MergedWith = theme;
        }
    }
}