// <copyright file="Selector.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace FortressWar.Model
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Media;
    using System.Xml.Serialization;

    /// <summary>
    /// Describing the selector.
    /// </summary>
    [XmlInclude(typeof(RectangleGeometry))]
    public class Selector : GameItem
    {
        /// <summary>
        /// Enum of the selected characters.
        /// </summary>
        public enum SelectedCharacters
        {
            /// <summary>
            /// Knight.
            /// </summary>
            Knight,

            /// <summary>
            /// Rider.
            /// </summary>
            Rider,

            /// <summary>
            /// Barricade.
            /// </summary>
            Barricade,

            /// <summary>
            /// If there is not a selected character.
            /// </summary>
            None,
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Selector"/> class.
        /// Selector.
        /// </summary>
        /// <param name="cx">the cx coord.</param>
        public Selector(double cx)
        {
            this.SelectedCharacter = SelectedCharacters.None;
            this.IsPutACharacter = false;
            this.IsUpgrade = false;
            this.Y_Tile = 1;
            this.CX = cx;
            this.area = new RectangleGeometry(new Rect(this.CX, this.CY, Config.SelectorWidth, Config.SelectorHeight));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Selector"/> class.
        /// </summary>
        public Selector()
        {
        }

        /// <summary>
        /// Gets or sets a value indicating whether is the selector put a Character.
        /// </summary>
        public bool IsPutACharacter { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether is the selector in UpgradeMode.
        /// </summary>
        public bool IsUpgrade { get; set; }

        /// <summary>
        /// Gets or sets the selected character.
        /// </summary>
        public SelectedCharacters SelectedCharacter { get; set; }
    }
}
