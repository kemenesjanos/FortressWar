// <copyright file="Bonus.cs" company="PlaceholderCompany">
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
    /// Describing the star and the potion.
    /// </summary>
    [XmlInclude(typeof(RectangleGeometry))]
    public class Potion : GameItem
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Potion"/> class.
        /// Bonus.
        /// </summary>
        public Potion()
        {
            Random r = new Random();
            this.Y_Tile = r.Next(0, 4);
            //this.CX = r.Next((-Config.FieldWidht / 2) - Config.CharacterTileWidth, Config.FieldWidht / 2);
            this.CX = r.Next((-200), 201);
            this.area = new RectangleGeometry(new Rect(this.CX, this.CY, Config.CharacterTileWidth * 0.75, Config.CharacterTileHeight));
        }
    }
}
