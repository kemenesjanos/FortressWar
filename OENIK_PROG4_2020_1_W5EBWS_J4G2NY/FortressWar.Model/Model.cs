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
        public double GameWidth { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public double GameHeight { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public double TileWidth { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public double TileHeight { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Player_1_name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Player_2_name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int Money_1 { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int Money_2 { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public List<Barricade> Barricades { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public List<Soldier> Soldiers { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public List<Bonus> Bonuses { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public List<Money> Monies { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public Fortress Fortress_1 { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public Fortress Fortress_2 { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int RiderLVL_1 { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int RiderLVL_2 { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int KnightLVL_1 { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int KnightLVL_2 { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int BarricadeLVL_1 { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int BarricadeLVL_2 { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void MapBuild()
        {
            throw new NotImplementedException();
        }
    }
}
