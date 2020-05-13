// <copyright file="Model.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace FortressWar.Model
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// The base class.
    /// </summary>
    public class Model : IModel
    {
        public double GameWidth { get; set; }
        public double GameHeight { get; set; }
        public double TileWidth { get; set; }
        public double TileHeight { get; set; }
        public List<Potion> Potions { get; set; }
        public List<Coin> Coins { get; set; }
        public Player Player_1 { get; set; }
        public Player Player_2 { get; set; }

        public void MapBuild()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Model"/> class.
        /// Ctor.
        /// </summary>
        public Model()
        {
            this.GameWidth = Config.FullWidht;
            this.GameHeight = Config.FullHeight;
            this.TileWidth = Config.FieldWidht;
            this.TileHeight = Config.FieldHeight;
            this.Potions = new List<Potion>();
            this.Coins = new List<Coin>();
            this.Player_1 = new Player();
            this.Player_2 = new Player();

        }
    }
}
