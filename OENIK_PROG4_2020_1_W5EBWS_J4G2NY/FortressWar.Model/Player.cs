﻿// <copyright file="Player.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace FortressWar.Model
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml.Serialization;

    /// <summary>
    /// Player.
    /// </summary>
    [XmlInclude(typeof(Knight))]
    [XmlInclude(typeof(Rider))]
    [XmlInclude(typeof(Barricade))]
    public class Player
    {
        /// <summary>
        /// Gets or sets the name of the player.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the money of the character.
        /// </summary>
        public int Money { get; set; }

        /// <summary>
        /// Gets or sets the fortress of this fortress.
        /// </summary>
        public Fortress Fortress { get; set; }

        /// <summary>
        /// Gets or sets the level of the rider.
        /// </summary>
        public int RiderLVL { get; set; }

        /// <summary>
        /// Gets or sets the level of the Knight.
        /// </summary>
        public int KnightLVL { get; set; }

        /// <summary>
        /// Gets or sets the level of the barricade.
        /// </summary>
        public int BarricadeLVL { get; set; }

        /// <summary>
        /// Gets or sets the barricade list.
        /// </summary>
        public List<Barricade> Barricades { get; set; }

        /// <summary>
        /// Gets or sets the soldier list.
        /// </summary>
        public List<Soldier> Soldiers { get; set; }

        /// <summary>
        /// Gets or sets the Selector.
        /// </summary>
        public Selector Selector { get; set; }

        /// <summary>
        /// Gets price of the Knight.
        /// </summary>
        public int KnightPrice
        {
            get { return Config.KnightBasePrice + (this.KnightLVL * Config.KnightLVLPrice); }
        }

        /// <summary>
        /// Gets price of the Rider.
        /// </summary>
        public int RiderPrice
        {
            get { return Config.RiderBasePrice + (this.RiderLVL * Config.RiderLVLPrice); }
        }

        /// <summary>
        /// Gets price of the Barricade.
        /// </summary>
        public int BarricadePrice
        {
            get { return Config.BarricadeBasePrice + (this.BarricadeLVL * Config.BarricadeLVLPrice); }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Player"/> class.
        /// Player ctor.
        /// </summary>
        public Player()
        {
            this.Money = Config.PlayerBaseMoney;
            this.KnightLVL = 0;
            this.RiderLVL = 0;
            this.BarricadeLVL = 0;
            this.Barricades = new List<Barricade>();
            this.Soldiers = new List<Soldier>();
        }
    }
}
