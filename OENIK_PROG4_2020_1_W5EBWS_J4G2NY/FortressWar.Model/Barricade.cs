// <copyright file="Barricade.cs" company="PlaceholderCompany">
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
    /// Describing the barricade.
    /// </summary>
    [XmlInclude(typeof( RectangleGeometry))]
    public class Barricade : Character
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Barricade"/> class.
        /// Ctor.
        /// </summary>
        /// <param name="player">The owner.</param>
        public Barricade(Player player)
        {
            this.LVL = player.BarricadeLVL;
            this.Owner = player;
            this.playerID = player.Name;
            this.area = new RectangleGeometry(new Rect(this.CX, this.CY, Config.CharacterTileWidth, Config.CharacterTileHeight));
            this.CountBasics();
        }
        public Barricade() { }

        /// <summary>
        /// Gets or sets level.
        /// </summary>
        public int LVL { get; set; }

        private void CountBasics()
        {
            this.Bounty = this.LVL * Config.BarricadeBaseBounty;
            this.Life = Config.BarricadeBaseLife + (this.LVL * Config.BarricadeLVLLife);
        }
    }
}
