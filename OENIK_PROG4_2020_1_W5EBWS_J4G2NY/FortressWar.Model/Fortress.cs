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
    using System.Xml.Serialization;

    /// <summary>
    /// Describing the fortresses.
    /// </summary>
    [XmlInclude(typeof(RectangleGeometry))]
    public class Fortress : Character
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Fortress"/> class.
        /// Ctor.
        /// </summary>
        /// <param name="owner">The owner.</param>
        /// <param name="cx">Centered x coord.</param>
        /// <param name="y">Tile y coord.</param>
        public Fortress(Player owner, double cx)
        {
            this.CX = cx;
            this.Y_Tile = 1;
            this.Owner = owner;
            this.playerID = owner.Name;
            this.Life = Config.FortressBaseLife;
            this.area = new RectangleGeometry(new Rect(this.CX, this.CY, Config.FortressTileWidth, Config.FortressTileHeight));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Fortress"/> class.
        /// </summary>
        public Fortress()
        {
        }
    }
}
