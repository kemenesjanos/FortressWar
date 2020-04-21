// <copyright file="Fortress.cs" company="PlaceholderCompany">
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
    /// Describing the fortresses.
    /// </summary>
    public class Fortress : Character
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Fortress"/> class.
        /// Ctor.
        /// </summary>
        /// <param name="owner">The owner.</param>
        /// <param name="cx">Centered x coord.</param>
        /// <param name="y">Tile y coord.</param>
        public Fortress(Player owner, double cx, int y)
        {
            this.CX = cx;
            this.Y_Tile = y;
            this.Owner = owner;
            this.Life = Config.FortressBaseLife;
            this.area = new RectangleGeometry(new Rect(this.CX, this.CY, Config.CharacterTileWidth, Config.CharacterTileHeight * 4));
        }

        public double Cx { get; }
    }
}
