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
        public string Player_1_name { get; set; }
        public string Player_2_name { get; set; }
        public int Money_1 { get; set; }
        public int Money_2 { get; set; }
        public List<Barricade> Barricades { get; set; }
        public List<Soldier> Soldiers { get; set; }
        public List<Bonus> Bonuses { get; set; }
        public List<Money> Monies { get; set; }
        public Fortress Fortress_1 { get; set; }
        public Fortress Fortress_2 { get; set; }
        public int RiderLVL_1 { get; set; }
        public int RiderLVL_2 { get; set; }
        public int KnightLVL_1 { get; set; }
        public int KnightLVL_2 { get; set; }
        public int BarricadeLVL_1 { get; set; }
        public int BarricadeLVL_2 { get; set; }

        public void MapBuild()
        {
            throw new NotImplementedException();
        }
    }
}
