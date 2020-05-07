// <copyright file="Config.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace FortressWar.Model
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Media;

    /// <summary>
    /// Config of the game.
    /// </summary>
    public static class Config
    {
        /// <summary>
        /// The movement distance.
        /// </summary>
        public const double StepDistance = 2;

        /// <summary>
        /// The players money increase that much.
        /// </summary>
        public const int IncreaseMoney = 1;

        /// <summary>
        /// Selector height.
        /// </summary>
        public const int SelectorHeight = 175;

        /// <summary>
        /// Selector width.
        /// </summary>
        public const int SelectorWidth = 150;

        /// <summary>
        /// Maximum LVL of a character.
        /// </summary>
        public const int MaxLVL = 10;

        /// <summary>
        /// Minimum coin for the random bonus.
        /// </summary>
        public const int MinCoin = 10;

        /// <summary>
        /// Maximum coin for the random bonus.
        /// </summary>
        public const int MaxCoin = 500;

        /// <summary>
        /// The base power of the knight.
        /// </summary>
        public const int KnightBasePower = 20;

        /// <summary>
        /// The knight get that much power when do a level up.
        /// </summary>
        public const int KnightLVLPower = 5;

        /// <summary>
        /// The base power of the rider.
        /// </summary>
        public const int RiderBasePower = 40;

        /// <summary>
        /// The rider get that much power when do a level up.
        /// </summary>
        public const int RiderLVLPower = 6;

        /// <summary>
        /// The base Speed of the knight.
        /// </summary>
        public const int KnightBaseSpeed = 1;

        /// <summary>
        /// The knight get that much Speed when do a level up.
        /// </summary>
        public const int KnightLVLSpeed = 0;

        /// <summary>
        /// The base Speed of the rider.
        /// </summary>
        public const int RiderBaseSpeed = 2;

        /// <summary>
        /// The rider get that much Speed when do a level up.
        /// </summary>
        public const int RiderLVLSpeed = 0;

        /// <summary>
        /// The base Life of the knight.
        /// </summary>
        public const int KnightBaseLife = 200;

        /// <summary>
        /// The knight get that much Life when do a level up.
        /// </summary>
        public const int KnightLVLLife = 10;

        /// <summary>
        /// The base Life of the rider.
        /// </summary>
        public const int RiderBaseLife = 250;

        /// <summary>
        /// The rider get that much Life when do a level up.
        /// </summary>
        public const int RiderLVLLife = 15;

        /// <summary>
        /// The base Life of the Barricade.
        /// </summary>
        public const int BarricadeBaseLife = 400;

        /// <summary>
        /// The Barricade get that much Life when do a level up.
        /// </summary>
        public const int BarricadeLVLLife = 10;

        /// <summary>
        /// The base Life of the Fortress.
        /// </summary>
        public const int FortressBaseLife = 10000;

        /// <summary>
        /// The base Price of the knight.
        /// </summary>
        public const int KnightBasePrice = 200;

        /// <summary>
        /// The knight costs that much Price when do a level up.
        /// </summary>
        public const int KnightLVLPrice = 50;

        /// <summary>
        /// The Upgrade Price of the knight.
        /// </summary>
        public const int KnightUpgradePrice = 200;

        /// <summary>
        /// The base Price of the rider.
        /// </summary>
        public const int RiderBasePrice = 400;

        /// <summary>
        /// The rider costs that much Price when do a level up.
        /// </summary>
        public const int RiderLVLPrice = 100;

        /// <summary>
        /// The Upgrade Price of the Rider.
        /// </summary>
        public const int RiderUpgradePrice = 300;

        /// <summary>
        /// The base Price of the Barricade.
        /// </summary>
        public const int BarricadeBasePrice = 100;

        /// <summary>
        /// The Barricade costs that much Price when do a level up.
        /// </summary>
        public const int BarricadeLVLPrice = 25;

        /// <summary>
        /// The Upgrade Price of the Barricade.
        /// </summary>
        public const int BarricadeUpgradePrice = 100;

        /// <summary>
        /// Player base money.
        /// </summary>
        public const int PlayerBaseMoney = 1000;

        /// <summary>
        /// The base bounty of the Knight.
        /// </summary>
        public const int KnightBaseBounty = 20;

        /// <summary>
        /// The base bounty of the Rider.
        /// </summary>
        public const int RiderBaseBounty = 40;

        /// <summary>
        /// The base bounty of the Barricade.
        /// </summary>
        public const int BarricadeBaseBounty = 0;

        /// <summary>
        /// The characters tile width.
        /// </summary>
        public const int CharacterTileWidth = 50;

        /// <summary>
        /// The characters tile height.
        /// </summary>
        public const int CharacterTileHeight = 50;

        /// <summary>
        /// The fortress tile width.
        /// </summary>
        public const int FortressTileWidth = 250;

        /// <summary>
        /// The fortress tile height.
        /// </summary>
        public const int FortressTileHeight = 550;

        /// <summary>
        /// Full width of the game.
        /// </summary>
        public const int FullWidht = 1600;

        /// <summary>
        /// Full height of the game.
        /// </summary>
        public const int FullHeight = 900;

        /// <summary>
        /// Top area width of the game.
        /// </summary>
        public const int TopWidth = 1600;

        /// <summary>
        /// Top area height of the game.
        /// </summary>
        public const int TopHeight = 200;

        /// <summary>
        /// Field area width of the game.
        /// </summary>
        public const int FieldWidht = 800;

        /// <summary>
        /// Field area height of the game.
        /// </summary>
        public const int FieldHeight = 700;

        /// <summary>
        /// A side icon width of the game.
        /// </summary>
        public const int SideWidht = 150;

        /// <summary>
        /// Side icons height of the game. Should use with /4!.
        /// </summary>
        public const int SideHeight = 700;

        private static Brush textLineColour = Brushes.White;

        private static Brush darkTextLineColour = new SolidColorBrush(Color.FromArgb(255, 55, 32, 21));

        private static Brush goldTextLineColour = Brushes.Gold;

        private static Brush baseBrownBg = new SolidColorBrush(Color.FromArgb(255, 86, 48, 32));

        private static Brush roadBg = new SolidColorBrush(Color.FromArgb(255, 199, 183, 148));

        private static Brush roadChooseIconBg = new SolidColorBrush(Color.FromArgb(255, 156, 132, 109));

        private static Brush characterIconBg = new SolidColorBrush(Color.FromArgb(255, 120, 80, 63));

        private static Brush characterIconLine = new SolidColorBrush(Color.FromArgb(255, 86, 48, 32));

        private static Brush activeBg = new SolidColorBrush(Color.FromArgb(255, 195, 146, 105));

        private static Brush currentActiveBg = Brushes.LightCoral;

        private static Brush backBg = new SolidColorBrush(Color.FromArgb(255, 136, 68, 68));

        /// <summary>
        /// Gets or sets main text colour.
        /// </summary>
        public static Brush TextLineColour { get => textLineColour; set => textLineColour = value; }

        /// <summary>
        /// Gets or sets darker text colour.
        /// </summary>
        public static Brush DarkTextLineColour { get => darkTextLineColour; set => darkTextLineColour = value; }

        /// <summary>
        /// Gets or sets gold text colour.
        /// </summary>
        public static Brush GoldTextLineColour { get => goldTextLineColour; set => goldTextLineColour = value; }

        /// <summary>
        /// Gets or sets base background colour.
        /// </summary>
        public static Brush BaseBrownBg { get => baseBrownBg; set => baseBrownBg = value; }

        /// <summary>
        /// Gets or sets road background colour.
        /// </summary>
        public static Brush RoadBg { get => roadBg; set => roadBg = value; }

        /// <summary>
        /// Gets or sets road chooser icon background colour.
        /// </summary>
        public static Brush RoadChooseIconBg { get => roadChooseIconBg; set => roadChooseIconBg = value; }

        /// <summary>
        /// Gets or sets character chooser icon background colour.
        /// </summary>
        public static Brush CharacterIconBg { get => characterIconBg; set => characterIconBg = value; }

        /// <summary>
        /// Gets or sets character chooser icon line colour.
        /// </summary>
        public static Brush CharacterIconLine { get => characterIconLine; set => characterIconLine = value; }

        /// <summary>
        /// Gets or sets active icon background colour.
        /// </summary>
        public static Brush ActiveBg { get => activeBg; set => activeBg = value; }

        /// <summary>
        /// Gets or sets current active icon background colour.
        /// </summary>
        public static Brush CurrentActiveBg { get => currentActiveBg; set => currentActiveBg = value; }

        /// <summary>
        /// Gets or sets back icon background colour.
        /// </summary>
        public static Brush BackBg { get => backBg; set => backBg = value; }
    }
}
