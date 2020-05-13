// <copyright file="Knight.cs" company="PlaceholderCompany">
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
    /// Knight qualities.
    /// </summary>
    [XmlInclude(typeof(RectangleGeometry))]
    public class Knight : Soldier
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Knight"/> class.
        /// Ctor.
        /// </summary>
        /// <param name="player">The owner.</param>
        public Knight( Player player)
        {
            this.LVL = player.KnightLVL;
            this.Owner = player;
            this.playerID = player.Name;
            this.CountBasics();
            this.area = new RectangleGeometry(new Rect(this.CX, this.CY, Config.CharacterTileWidth, Config.CharacterTileHeight));
        }
        public Knight() { }

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
            this.Bounty = (this.LVL + 1) * Config.KnightBaseBounty;
            this.Life = Config.KnightBaseLife + (this.LVL * Config.KnightLVLLife);
            this.Power = Config.KnightBasePower + (this.LVL * Config.KnightLVLPower);
            this.Speed = Config.KnightBaseSpeed + (this.LVL * Config.KnightLVLSpeed);
        }
    }
}
