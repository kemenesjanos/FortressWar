// <copyright file="Rider.cs" company="PlaceholderCompany">
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
    /// Rider qualities.
    /// </summary>
    public class Rider : Soldier
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Rider"/> class.
        /// Ctor.
        /// </summary>
        /// <param name="player">The owner.</param>
        public Rider(Player player)
        {
            this.LVL = player.RiderLVL;
            this.Owner = player;
            this.CountBasics();
            this.area = new RectangleGeometry(new Rect(this.CX, this.CY, Config.CharacterTileWidth, Config.CharacterTileHeight));
        }

        /// <summary>
        /// Override LVLUp method.
        /// </summary>
        public override void LVLUp()
        {
            this.LVL++;
            this.CountBasics();
        }

        private void CountBasics()
        {
            this.Bounty = this.LVL * Config.RiderBaseBounty;
            this.Life = Config.RiderBaseLife + (this.LVL * Config.RiderLVLLife);
            this.Power = Config.RiderBasePower + (this.LVL * Config.RiderLVLPower);
            this.Speed = Config.RiderBaseSpeed + (this.LVL * Config.RiderLVLSpeed);
        }
    }
}
