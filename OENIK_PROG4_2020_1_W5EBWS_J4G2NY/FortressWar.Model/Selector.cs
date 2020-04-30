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

    /// <summary>
    /// Describing the selector.
    /// </summary>
    public class Selector : GameItem
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Selector"/> class.
        /// Selector.
        /// </summary>
        /// <param name="cx">the cx coord.</param>
        public Selector(double cx)
        {
            this.IsPutACharacter = false;
            this.IsUpgrade = false;
            this.Y_Tile = 2;
            this.CX = cx;
            this.area = new RectangleGeometry(new Rect(this.CX, this.CY, Config.SelectorWidth, Config.SelectorHeight));
        }

        /// <summary>
        /// Gets or sets a value indicating whether is the selector put a Character.
        /// </summary>
        public bool IsPutACharacter { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether is the selector in UpgradeMode.
        /// </summary>
        public bool IsUpgrade { get; set; }
    }
}
