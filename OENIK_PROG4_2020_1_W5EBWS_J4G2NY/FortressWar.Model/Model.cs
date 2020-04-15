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
        public List<Barricade> Barricades { get; set; }
        public List<Soldier> Soldiers { get; set; }
        public List<Bonus> Bonuses { get; set; }
        public List<Coin> Monies { get; set; }
        public Player Player_1 { get; set; }
        public Player Player_2 { get; set; }

        public void MapBuild()
        {
            throw new NotImplementedException();
        }
    }
}
