using System;
using System.Collections.Generic;
using System.Text;

namespace FundooApplication.Model
{
    /// <summary>
    /// for getting google profile
    /// </summary>
    public class GoogleProfile
    {
        /// <summary>
        /// Gets or sets the kind.
        /// </summary>
        /// <value>
        /// The kind.
        /// </value>
        public string Kind { get; set; }

        /// <summary>
        /// Gets or sets the tag.
        /// </summary>
        /// <value>
        /// The tag.
        /// </value>
        public string Etag { get; set; }

        /// <summary>
        /// Gets or sets the occupation.
        /// </summary>
        /// <value>
        /// The occupation.
        /// </value>
        public string Occupation { get; set; }

        /// <summary>
        /// Gets or sets the gender.
        /// </summary>
        /// <value>
        /// The gender.
        /// </value>
        public string Gender { get; set; }

        /// <summary>
        /// Gets or sets the type of the object.
        /// </summary>
        /// <value>
        /// The type of the object.
        /// </value>
        public string ObjectType { get; set; }

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the display name.
        /// </summary>
        /// <value>
        /// The display name.
        /// </value>
        public string DisplayName { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public Name Name { get; set; }

        /// <summary>
        /// Gets or sets the tagline.
        /// </summary>
        /// <value>
        /// The tagline.
        /// </value>
        public string Tagline { get; set; }

        /// <summary>
        /// Gets or sets the URL.
        /// </summary>
        /// <value>
        /// The URL.
        /// </value>
        public string Url { get; set; }

        /// <summary>
        /// Gets or sets the image.
        /// </summary>
        /// <value>
        /// The image.
        /// </value>
        public Image Image { get; set; }

        /// <summary>
        /// Gets or sets the organizations.
        /// </summary>
        /// <value>
        /// The organizations.
        /// </value>
        public Organization[] Organizations { get; set; }

        /// <summary>
        /// Gets or sets the places lived.
        /// </summary>
        /// <value>
        /// The places lived.
        /// </value>
        public Placeslived[] PlacesLived { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is plus user.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is plus user; otherwise, <c>false</c>.
        /// </value>
        public bool IsPlusUser { get; set; }

        /// <summary>
        /// Gets or sets the circled by count.
        /// </summary>
        /// <value>
        /// The circled by count.
        /// </value>
        public int CircledByCount { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="GoogleProfile"/> is verified.
        /// </summary>
        /// <value>
        ///   <c>true</c> if verified; otherwise, <c>false</c>.
        /// </value>
        public bool Verified { get; set; }

        /// <summary>
        /// Gets or sets the cover.
        /// </summary>
        /// <value>
        /// The cover.
        /// </value>
        public Cover Cover { get; set; }
    }

    /// <summary>
    /// For name
    /// </summary>
    public partial class Name
    {
        /// <summary>
        /// Gets or sets the name of the family.
        /// </summary>
        /// <value>
        /// The name of the family.
        /// </value>
        public string FamilyName { get; set; }

        /// <summary>
        /// Gets or sets the name of the given.
        /// </summary>
        /// <value>
        /// The name of the given.
        /// </value>
        public string GivenName { get; set; }
    }

    /// <summary>
    /// taking image url
    /// </summary>
    public class Image
    {
        /// <summary>
        /// Gets or sets the URL.
        /// </summary>
        /// <value>
        /// The URL.
        /// </value>
        public string Url { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is default.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is default; otherwise, <c>false</c>.
        /// </value>
        public bool IsDefault { get; set; }
    }

    /// <summary>
    /// cover photo
    /// </summary>
    public class Cover
    {
        /// <summary>
        /// Gets or sets the layout.
        /// </summary>
        /// <value>
        /// The layout.
        /// </value>
        public string Layout { get; set; }

        /// <summary>
        /// Gets or sets the cover photo.
        /// </summary>
        /// <value>
        /// The cover photo.
        /// </value>
        public Coverphoto CoverPhoto { get; set; }

        /// <summary>
        /// Gets or sets the cover information.
        /// </summary>
        /// <value>
        /// The cover information.
        /// </value>
        public Coverinfo CoverInfo { get; set; }
    }

    /// <summary>
    /// cover photo
    /// </summary>
    public class Coverphoto
    {
        /// <summary>
        /// Gets or sets the URL.
        /// </summary>
        /// <value>
        /// The URL.
        /// </value>
        public string Url { get; set; }

        /// <summary>
        /// Gets or sets the height.
        /// </summary>
        /// <value>
        /// The height.
        /// </value>
        public int Height { get; set; }

        /// <summary>
        /// Gets or sets the width.
        /// </summary>
        /// <value>
        /// The width.
        /// </value>
        public int Width { get; set; }
    }

    /// <summary>
    /// cover information
    /// </summary>
    public class Coverinfo
    {
        /// <summary>
        /// Gets or sets the top image offset.
        /// </summary>
        /// <value>
        /// The top image offset.
        /// </value>
        public int TopImageOffset { get; set; }

        /// <summary>
        /// Gets or sets the left image offset.
        /// </summary>
        /// <value>
        /// The left image offset.
        /// </value>
        public int LeftImageOffset { get; set; }
    }

    /// <summary>
    /// organization detail
    /// </summary>
    public class Organization
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>
        /// The title.
        /// </value>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <value>
        /// The type.
        /// </value>
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the start date.
        /// </summary>
        /// <value>
        /// The start date.
        /// </value>
        public string StartDate { get; set; }

        /// <summary>
        /// Gets or sets the end date.
        /// </summary>
        /// <value>
        /// The end date.
        /// </value>
        public string EndDate { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Organization"/> is primary.
        /// </summary>
        /// <value>
        ///   <c>true</c> if primary; otherwise, <c>false</c>.
        /// </value>
        public bool Primary { get; set; }
    }

    /// <summary>
    /// live location
    /// </summary>
    public class Placeslived
    {
        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>
        /// The value.
        /// </value>
        public string Value { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Placeslived"/> is primary.
        /// </summary>
        /// <value>
        ///   <c>true</c> if primary; otherwise, <c>false</c>.
        /// </value>
        public bool Primary { get; set; }
    }
}
