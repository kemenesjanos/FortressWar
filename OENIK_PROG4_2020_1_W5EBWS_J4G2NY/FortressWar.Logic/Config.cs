// <copyright file="Config.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace FortressWar.Logic
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
        private static Brush textLineColour;
        private static Brush darkTextLineColour;
        private static Brush goldTextLineColour;
        private static Brush backTextColour;

        private static Brush baseBrownBg;

        private static Brush roadBg;
        private static Brush roadChooseIconBg;
        private static Brush backIconBg;

        private static Brush characterIconBg;
        private static Brush characterIconLine;

        private static Brush activeBg;

        private static int fullWidht;
        private static int fullHeight;

        private static int topWidth;
        private static int topHeight;

        private static int fieldWidht;
        private static int fieldHeight;

        private static int sideWidht;
        private static int sideHeight;

        /// <summary>
        /// Gets or sets base text colour.
        /// </summary>
        public static Brush TextLineColour { get => textLineColour; set => textLineColour = Brushes.White; }

        /// <summary>
        /// Gets or sets darker text colour.
        /// </summary>
        public static Brush DarkTextLineColour { get => darkTextLineColour; set => darkTextLineColour = Brushes.Sienna; }

        /// <summary>
        /// Gets or sets gold text colour.
        /// </summary>
        public static Brush GoldTextLineColour { get => goldTextLineColour; set => goldTextLineColour = Brushes.Gold; }

        /// <summary>
        /// Gets or sets back icon text colour.
        /// </summary>
        public static Brush BackTextColour { get => backTextColour; set => backTextColour = Brushes.IndianRed; }

        /// <summary>
        /// Gets or sets base backgound colour.
        /// </summary>
        public static Brush BaseBrownBg { get => baseBrownBg; set => baseBrownBg = Brushes.SaddleBrown; }

        /// <summary>
        /// Gets or sets road backgound colour.
        /// </summary>
        public static Brush RoadBg { get => roadBg; set => roadBg = Brushes.AntiqueWhite; }

        /// <summary>
        /// Gets or sets road choose icon backgound colour.
        /// </summary>
        public static Brush RoadChooseIconBg { get => roadChooseIconBg; set => roadChooseIconBg = Brushes.DarkSalmon; }

        /// <summary>
        /// Gets or sets back icon backgound colour.
        /// </summary>
        public static Brush BackIconBg { get => backIconBg; set => backIconBg = Brushes.DarkSalmon; }

        /// <summary>
        /// Gets or sets character icon backgound colour.
        /// </summary>
        public static Brush CharacterIconBg { get => characterIconBg; set => characterIconBg = Brushes.Sienna; }

        /// <summary>
        /// Gets or sets character icon line colour.
        /// </summary>
        public static Brush CharacterIconLine { get => characterIconLine; set => characterIconLine = Brushes.SandyBrown; }

        /// <summary>
        /// Gets or sets active status backgound colour.
        /// </summary>
        public static Brush ActiveBg { get => activeBg; set => activeBg = Brushes.LightCoral; }

        /// <summary>
        /// Gets or sets whole console width.
        /// </summary>
        public static int FullWidht { get => fullWidht; set => fullWidht = 1600; }

        /// <summary>
        /// Gets or sets whole console height.
        /// </summary>
        public static int FullHeight { get => fullHeight; set => fullHeight = 900; }

        /// <summary>
        /// Gets or sets top section width.
        /// </summary>
        public static int TopWidth { get => topWidth; set => topWidth = 1600; }

        /// <summary>
        /// Gets or sets top section height.
        /// </summary>
        public static int TopHeight { get => topHeight; set => topHeight = 200; }

        /// <summary>
        /// Gets or sets the flied width.
        /// </summary>
        public static int FieldWidht { get => fieldWidht; set => fieldWidht = 800; }

        /// <summary>
        /// Gets or sets the flied height.
        /// </summary>
        public static int FieldHeight { get => fieldHeight; set => fieldHeight = 700; }

        /// <summary>
        /// Gets or sets sides width.
        /// </summary>
        public static int SideWidht { get => sideWidht; set => sideWidht = 400; }

        /// <summary>
        /// Gets or sets sides height.
        /// </summary>
        public static int SideHeight { get => sideHeight; set => sideHeight = 700; }
    }
}
