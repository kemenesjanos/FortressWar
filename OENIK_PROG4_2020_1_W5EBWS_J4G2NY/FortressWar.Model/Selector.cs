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
            this.Y_Tile = 1;
            this.CX = cx;
            this.area = new RectangleGeometry(new Rect(this.CX, this.CY, Config.SelectorWidth, Config.SelectorHeight));
        }
    }
}
