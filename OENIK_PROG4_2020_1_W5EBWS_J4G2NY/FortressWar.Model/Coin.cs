// <copyright file="Money.cs" company="PlaceholderCompany">
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
    /// Describing the Money.
    /// </summary>
    public class Coin : Character
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Coin"/> class.
        /// Set a random value to value.
        /// </summary>
        public Coin()
        {
            Random r = new Random();
            this.Bounty = r.Next(Config.MinCoin, Config.MaxCoin + 1);
            this.Life = 1;
            this.Y_Tile = r.Next(0, 4);
            //this.CX = r.Next((-Config.FieldWidht / 2) - Config.CharacterTileWidth , Config.FieldWidht / 2);
            this.CX = r.Next((-200), 201);
            this.area = new RectangleGeometry(new Rect(this.CX, this.CY, Config.CharacterTileWidth * 0.75, Config.CharacterTileHeight));
        }
    }
}
