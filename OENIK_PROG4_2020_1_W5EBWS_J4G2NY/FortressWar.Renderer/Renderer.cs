// <copyright file="Renderer.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace FortressWar.Renderer
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using FortressWar.Model;

    /// <summary>
    /// Renderer of the game.
    /// </summary>
    public class Renderer
    {
        private Stopwatch stw;

        private Model model;
        private Rect backgroundRect;
        private Rect topBackgroundRect;

        private Rect button1Knight;
        private Rect button1Rider;
        private Rect button1Barricade;
        private Rect button1Upgrade;
        private Rect buttonChar1Knight;
        private Rect buttonChar1Rider;
        private Rect buttonChar1Barricade;
        private Rect choose11;
        private Rect choose12;
        private Rect choose13;
        private Rect choose14;

        private Rect button2Knight;
        private Rect button2Rider;
        private Rect button2Barricade;
        private Rect button2Upgrade;
        private Rect buttonChar2Knight;
        private Rect buttonChar2Rider;
        private Rect buttonChar2Barricade;
        private Rect choose21;
        private Rect choose22;
        private Rect choose23;
        private Rect choose24;

        private Rect road1;
        private Rect road2;
        private Rect road3;
        private Rect road4;

        private Rect back1;
        private Rect back2;

        private Rect gold1;
        private Rect gold2;

        private Typeface font = new Typeface("Arial");
        private Point textLocation = new Point(10, 10);

        private FormattedText textPlayer1;
        private FormattedText textPlayer2;
        private FormattedText textGold1;
        private FormattedText textGold2;
        private FormattedText textKnight1Gold;
        private FormattedText textKnight2Gold;
        private FormattedText textRider1Gold;
        private FormattedText textRider2Gold;
        private FormattedText textBarricade1Gold;
        private FormattedText textBarricade2Gold;
        private FormattedText textKnight1Level;
        private FormattedText textKnight2Level;
        private FormattedText textRider1Level;
        private FormattedText textRider2Level;
        private FormattedText textBarricade1Level;
        private FormattedText textBarricade2Level;
        private FormattedText textBack1;
        private FormattedText textBack2;

        private FormattedText textUpgrade1;
        private FormattedText textUpgrade2;
        private FormattedText textUpgradePrice;

        private FormattedText textFortress1;
        private FormattedText textFortress2;

        private FormattedText fortressWar;

        private FormattedText escText;

        private Dictionary<string, Brush> brushes = new Dictionary<string, Brush>();

        /// <summary>
        /// Initializes a new instance of the <see cref="Renderer"/> class.
        /// </summary>
        /// <param name="model">The parameter.</param>
        public Renderer(Model model)
        {
            this.model = model;
            this.stw = new Stopwatch();
            this.backgroundRect = new Rect(0, 0, Config.FullWidht, Config.FullHeight);
            this.topBackgroundRect = new Rect(0, 0, Config.TopWidth, Config.TopHeight);

            this.button1Knight = new Rect(0, Config.TopHeight, Config.SideWidht, Config.SideHeight / 4);
            this.button1Rider = new Rect(0, Config.TopHeight + (Config.SideHeight / 4), Config.SideWidht, Config.SideHeight / 4);
            this.button1Barricade = new Rect(0, Config.TopHeight + (Config.SideHeight / 4 * 2), Config.SideWidht, Config.SideHeight / 4);
            this.button1Upgrade = new Rect(0, Config.TopHeight + (Config.SideHeight / 4 * 3), Config.SideWidht, Config.SideHeight / 4);

            this.buttonChar1Knight = new Rect(Config.CharacterTileWidth - 25, Config.TopHeight + 40, Config.CharacterTileWidth * 2, Config.CharacterTileHeight * 2);
            this.buttonChar1Rider = new Rect(Config.CharacterTileWidth - 25, Config.TopHeight + (Config.SideHeight / 4) + 40, Config.CharacterTileWidth * 2, Config.CharacterTileHeight * 2);
            this.buttonChar1Barricade = new Rect(Config.CharacterTileWidth - 25, Config.TopHeight + (Config.SideHeight / 4 * 2) + 40, Config.CharacterTileWidth * 2, Config.CharacterTileHeight * 2);

            this.button2Knight = new Rect(Config.FullWidht - Config.SideWidht, Config.TopHeight, Config.SideWidht, Config.SideHeight / 4);
            this.button2Rider = new Rect(Config.FullWidht - Config.SideWidht, Config.TopHeight + (Config.SideHeight / 4), Config.SideWidht, Config.SideHeight / 4);
            this.button2Barricade = new Rect(Config.FullWidht - Config.SideWidht, Config.TopHeight + (Config.SideHeight / 4 * 2), Config.SideWidht, Config.SideHeight / 4);
            this.button2Upgrade = new Rect(Config.FullWidht - Config.SideWidht, Config.TopHeight + (Config.SideHeight / 4 * 3), Config.SideWidht, Config.SideHeight / 4);

            this.buttonChar2Knight = new Rect(Config.FullWidht - Config.CharacterTileWidth - 75, Config.TopHeight + 40, Config.CharacterTileWidth * 2, Config.CharacterTileHeight * 2);
            this.buttonChar2Rider = new Rect(Config.FullWidht - Config.CharacterTileWidth - 75, Config.TopHeight + (Config.SideHeight / 4) + 40, Config.CharacterTileWidth * 2, Config.CharacterTileHeight * 2);
            this.buttonChar2Barricade = new Rect(Config.FullWidht - Config.CharacterTileWidth - 75, Config.TopHeight + (Config.SideHeight / 4 * 2) + 40, Config.CharacterTileWidth * 2, Config.CharacterTileHeight * 2);

            this.road1 = new Rect(Config.SideWidht + Config.FortressTileWidth, Config.TopHeight + 90, Config.FieldWidht, Config.CharacterTileHeight);
            this.road2 = new Rect(Config.SideWidht + Config.FortressTileWidth, Config.TopHeight + (90 * 2) + Config.CharacterTileHeight, Config.FieldWidht, Config.CharacterTileHeight);
            this.road3 = new Rect(Config.SideWidht + Config.FortressTileWidth, Config.TopHeight + (90 * 3) + (Config.CharacterTileHeight * 2), Config.FieldWidht, Config.CharacterTileHeight);
            this.road4 = new Rect(Config.SideWidht + Config.FortressTileWidth, Config.TopHeight + (90 * 4) + (Config.CharacterTileHeight * 3), Config.FieldWidht, Config.CharacterTileHeight);

            this.choose11 = new Rect(Config.SideWidht + Config.FortressTileWidth - (Config.CharacterTileWidth * 2), Config.TopHeight + 90, Config.CharacterTileWidth * 2, Config.CharacterTileHeight);
            this.choose12 = new Rect(Config.SideWidht + Config.FortressTileWidth - (Config.CharacterTileWidth * 2), Config.TopHeight + (90 * 2) + Config.CharacterTileHeight, Config.CharacterTileWidth * 2, Config.CharacterTileHeight);
            this.choose13 = new Rect(Config.SideWidht + Config.FortressTileWidth - (Config.CharacterTileWidth * 2), Config.TopHeight + (90 * 3) + (Config.CharacterTileHeight * 2), Config.CharacterTileWidth * 2, Config.CharacterTileHeight);
            this.choose14 = new Rect(Config.SideWidht + Config.FortressTileWidth - (Config.CharacterTileWidth * 2), Config.TopHeight + (90 * 4) + (Config.CharacterTileHeight * 3), Config.CharacterTileWidth * 2, Config.CharacterTileHeight);

            this.back1 = new Rect(Config.SideWidht + Config.FortressTileWidth - (Config.CharacterTileWidth * 2), Config.TopHeight + (90 * 5) + (Config.CharacterTileHeight * 4), Config.CharacterTileWidth * 2, Config.CharacterTileHeight);

            this.choose21 = new Rect(Config.FullWidht - Config.SideWidht - Config.FortressTileWidth, Config.TopHeight + 90, Config.CharacterTileWidth * 2, Config.CharacterTileHeight);
            this.choose22 = new Rect(Config.FullWidht - Config.SideWidht - Config.FortressTileWidth, Config.TopHeight + (90 * 2) + Config.CharacterTileHeight, Config.CharacterTileWidth * 2, Config.CharacterTileHeight);
            this.choose23 = new Rect(Config.FullWidht - Config.SideWidht - Config.FortressTileWidth, Config.TopHeight + (90 * 3) + (Config.CharacterTileHeight * 2), Config.CharacterTileWidth * 2, Config.CharacterTileHeight);
            this.choose24 = new Rect(Config.FullWidht - Config.SideWidht - Config.FortressTileWidth, Config.TopHeight + (90 * 4) + (Config.CharacterTileHeight * 3), Config.CharacterTileWidth * 2, Config.CharacterTileHeight);

            this.back2 = new Rect(Config.FullWidht - Config.SideWidht - Config.FortressTileWidth, Config.TopHeight + (90 * 5) + (Config.CharacterTileHeight * 4), Config.CharacterTileWidth * 2, Config.CharacterTileHeight);

            this.gold1 = new Rect(5, 125, Config.CharacterTileWidth, Config.CharacterTileHeight * 1.5);
            this.gold2 = new Rect(Config.FullWidht - 5 - Config.CharacterTileWidth, 125, Config.CharacterTileWidth, Config.CharacterTileHeight * 1.5);
        }

        /// <summary>
        /// Help make smooth frame change.
        /// </summary>
        /// <returns>True or False.</returns>
        public bool FrameTimer()
        {
            return Math.Round(this.stw.Elapsed.TotalMilliseconds, 0) % 400 < 200;
        }

        /// <summary>
        /// Help to add images as brush.
        /// </summary>
        /// <param name="fname">Image name.</param>
        /// <param name="isTiled">Repeating of the image.</param>
        /// <returns>The image as brush.</returns>
        public Brush GetBrush(string fname, bool isTiled)
        {
            if (!this.brushes.ContainsKey(fname))
            {
                BitmapImage bmp = new BitmapImage();

                bmp.BeginInit();
                bmp.StreamSource = Assembly.GetEntryAssembly().GetManifestResourceStream(fname);
                if (bmp.StreamSource == null) throw new Exception("ResourceStream NotFound: " +fname);
                bmp.EndInit();

                ImageBrush ib = new ImageBrush(bmp);

                if (isTiled)
                {
                    ib.TileMode = TileMode.Tile;
                    ib.Viewport = new Rect(0, 0, Config.CharacterTileWidth, Config.CharacterTileHeight);
                    ib.ViewportUnits = BrushMappingMode.Absolute;
                }

                this.brushes.Add(fname, ib);
            }

            return this.brushes[fname];
        }

        /// <summary>
        /// Help to add fortress image as brush.
        /// </summary>
        /// <param name="fname">Image name.</param>
        /// <param name="isTiled">Repeating of the image.</param>
        /// <returns>The image as brush.</returns>
        public Brush GetFortressBrush(string fname, bool isTiled)
        {
            if (!this.brushes.ContainsKey(fname))
            {
                BitmapImage bmp = new BitmapImage();

                bmp.BeginInit();
                bmp.StreamSource = Assembly.GetEntryAssembly().GetManifestResourceStream(fname);
                if (bmp.StreamSource == null) throw new Exception("ResourceStream NotFound: " + fname);
                bmp.EndInit();

                ImageBrush ib = new ImageBrush(bmp);

                if (isTiled)
                {
                    ib.TileMode = TileMode.Tile;
                    ib.Viewport = new Rect(0, 0, Config.FortressTileWidth, Config.FortressTileHeight);
                    ib.ViewportUnits = BrushMappingMode.Absolute;
                }

                this.brushes.Add(fname, ib);
            }

            return this.brushes[fname];
        }

        /// <summary>
        /// Gets make grass brush.
        /// </summary>
        private Brush GetFieldBrush()
        {
            return this.GetBrush("FortressWar.Images.grass.png", true);
        }

        /// <summary>
        /// Gets make Gold bonus brush.
        /// </summary>
        private Brush GetGoldBonusBrush1()
        {
            return this.GetBrush("FortressWar.Images.coin1.png", false);
        }

        /// <summary>
        /// Gets make Gold bonus brush.
        /// </summary>
        private Brush GetGoldBonusBrush2()
        {
            return this.GetBrush("FortressWar.Images.coin2.png", false);
        }

        /// <summary>
        /// Gets make Potion bonus brush.
        /// </summary>
        private Brush GetPotionBonusBrush1()
        {
            return this.GetBrush("FortressWar.Images.potion1.png", false);
        }

        /// <summary>
        /// Gets make Potion bonus brush.
        /// </summary>
        private Brush GetPotionBonusBrush2()
        {
            return this.GetBrush("FortressWar.Images.potion2.png", false);
        }

        /// <summary>
        /// Gets make Knight1 brush.
        /// </summary>
        private Brush GetKnight1Brush1()
        {
            return this.GetBrush("FortressWar.Images.1walk1.png", false);
        }

        /// <summary>
        /// Gets make Knight1 brush.
        /// </summary>
        private Brush GetKnight1Brush2()
        {
            return this.GetBrush("FortressWar.Images.1walk2.png", false);
        }

        /// <summary>
        /// Gets make Knight1 attack brush.
        /// </summary>
        private Brush GetKnightAttack1Brush1()
        {
            return this.GetBrush("FortressWar.Images.1attack1.png", false);
        }

        /// <summary>
        /// Gets make Knight1 attack brush.
        /// </summary>
        private Brush GetKnightAttack1Brush2()
        {
            return this.GetBrush("FortressWar.Images.1attack2.png", false);
        }

        /// <summary>
        /// Gets make Knight2 brush.
        /// </summary>
        private Brush GetKnight2Brush1()
        {
            return this.GetBrush("FortressWar.Images.2walk1.png", false);
        }

        /// <summary>
        /// Gets make Knight2 attack brush.
        /// </summary>
        private Brush GetKnightAttack2Brush2()
        {
            return this.GetBrush("FortressWar.Images.2attack2.png", false);
        }

        /// <summary>
        /// Gets make Knight2 attack brush.
        /// </summary>
        private Brush GetKnightAttack2Brush1()
        {
            return this.GetBrush("FortressWar.Images.2attack1.png", false);
        }

        /// <summary>
        /// Gets make Knight2 brush.
        /// </summary>
        private Brush GetKnight2Brush2()
        {
            return this.GetBrush("FortressWar.Images.2walk2.png", false);
        }

        /// <summary>
        /// Gets make Rider1 brush.
        /// </summary>
        private Brush GetRider1Brush1()
        {
            return this.GetBrush("FortressWar.Images.1hwalk1.png", false);
        }

        /// <summary>
        /// Gets make Rider1 brush.
        /// </summary>
        private Brush GetRider1Brush2()
        {
            return this.GetBrush("FortressWar.Images.1hwalk2.png", false);
        }

        /// <summary>
        /// Gets make Rider1 attack brush.
        /// </summary>
        private Brush GetRiderAttack1Brush1()
        {
            return this.GetBrush("FortressWar.Images.1hattack1.png", false);
        }

        /// <summary>
        /// Gets make Rider1 attack brush.
        /// </summary>
        private Brush GetRiderAttack1Brush2()
        {
            return this.GetBrush("FortressWar.Images.1hattack2.png", false);
        }

        /// <summary>
        /// Gets make Rider2 brush.
        /// </summary>
        private Brush GetRider2Brush1()
        {
            return this.GetBrush("FortressWar.Images.2hwalk1.png", false);
        }

        /// <summary>
        /// Gets make Rider2 brush.
        /// </summary>
        private Brush GetRider2Brush2()
        {
            return this.GetBrush("FortressWar.Images.2hwalk2.png", false);
        }

        /// <summary>
        /// Gets make Rider2 attack brush.
        /// </summary>
        private Brush GetRiderAttack2Brush1()
        {
            return this.GetBrush("FortressWar.Images.2hattack1.png", false);
        }

        /// <summary>
        /// Gets make Rider2 attack brush.
        /// </summary>
        private Brush GetRiderAttack2Brush2()
        {
            return this.GetBrush("FortressWar.Images.2hattack2.png", false);
        }

        /// <summary>
        /// Gets make Barricade1 brush.
        /// </summary>
        private Brush GetBarricade1Brush()
        {
            return this.GetBrush("FortressWar.Images.1barricade.png", false);
        }

        /// <summary>
        /// Gets make Barricade2 brush.
        /// </summary>
        private Brush GetBarricade2Brush()
        {
            return this.GetBrush("FortressWar.Images.2barricade.png", false);
        }

        /// <summary>
        /// Gets make Fortress1 brush.
        /// </summary>
        private Brush GetFortress1Brush1()
        {
            return this.GetFortressBrush("FortressWar.Images.1fortress1.png", false);
        }

        /// <summary>
        /// Gets make Fortress1 brush.
        /// </summary>
        private Brush GetFortress1Brush2()
        {
            return this.GetFortressBrush("FortressWar.Images.1fortress2.png", false);
        }

        /// <summary>
        /// Gets make HalfFortress1 brush.
        /// </summary>
        private Brush GetFortressHalf1Brush1()
        {
            return this.GetFortressBrush("FortressWar.Images.1halffortress1.png", false);
        }

        /// <summary>
        /// Gets make HalfFortress1 brush.
        /// </summary>
        private Brush GetFortressHalf1Brush2()
        {
            return this.GetFortressBrush("FortressWar.Images.1halffortress2.png", false);
        }

        /// <summary>
        /// Gets make DefFortress1 brush.
        /// </summary>
        private Brush GetFortressDef1Brush1()
        {
            return this.GetFortressBrush("FortressWar.Images.1deffortress1.png", false);
        }

        /// <summary>
        /// Gets make DefFortress1 brush.
        /// </summary>
        private Brush GetFortressDef1Brush2()
        {
            return this.GetFortressBrush("FortressWar.Images.1deffortress2.png", false);
        }

        /// <summary>
        /// Gets make Fortress2 brush.
        /// </summary>
        private Brush GetFortress2Brush1()
        {
            return this.GetFortressBrush("FortressWar.Images.2fortress1.png", false);
        }

        /// <summary>
        /// Gets make Fortress2 brush.
        /// </summary>
        private Brush GetFortress2Brush2()
        {
            return this.GetFortressBrush("FortressWar.Images.2fortress2.png", false);
        }

        /// <summary>
        /// Gets make HalfFortress2 brush.
        /// </summary>
        private Brush GetFortressHalf2Brush1()
        {
            return this.GetFortressBrush("FortressWar.Images.2halffortress1.png", false);
        }

        /// <summary>
        /// Gets make GalfFortress2 brush.
        /// </summary>
        private Brush GetFortressHalf2Brush2()
        {
            return this.GetFortressBrush("FortressWar.Images.2halffortress2.png", false);
        }

        /// <summary>
        /// Gets make DefFortress2 brush.
        /// </summary>
        private Brush GetFortressDef2Brush1()
        {
            return this.GetFortressBrush("FortressWar.Images.2deffortress1.png", false);
        }

        /// <summary>
        /// Gets make DefFortress2 brush.
        /// </summary>
        private Brush GetFortressDef2Brush2()
        {
            return this.GetFortressBrush("FortressWar.Images.2deffortress2.png", false);
        }

        /// <summary>
        /// Gets make Barricade2 brush.
        /// </summary>
        private Brush GetGoldBrush()
        {
            return this.GetBrush("FortressWar.Images.coin1.png", false);
        }

        /// <summary>
        /// Build of the drawing.
        /// </summary>
        /// /// <param name="ctx">The context.</param>
        public void BuildDrawing(DrawingContext ctx)
        {
            this.GetBackground(ctx);
            this.GetTopArea(ctx);
            this.GetRoad(ctx);
            this.GetRoadChoose(ctx);
            this.GetCharacterChoose(ctx);
            this.GetChoose(ctx);
            this.GetCharacterChooseChar(ctx);

            this.GetBarricade(ctx);
            this.GetSoldier(ctx);
            this.GetFortress(ctx);
            this.GetBonus(ctx);

            this.GetText(ctx);

            this.stw.Start();
        }

        private void GetBonus(DrawingContext ctx)
        {
            foreach (Coin coin in this.model.Coins)
            {
                if (this.FrameTimer())
                {
                    ctx.DrawGeometry(this.GetGoldBonusBrush1(), null, coin.RealArea);
                }
                else
                {
                    ctx.DrawGeometry(this.GetGoldBonusBrush2(), null, coin.RealArea);
                }
            }

            foreach (Potion potion in this.model.Potions)
            {
                if (this.FrameTimer())
                {
                    ctx.DrawGeometry(this.GetPotionBonusBrush1(), null, potion.RealArea);
                }
                else
                {
                    ctx.DrawGeometry(this.GetPotionBonusBrush2(), null, potion.RealArea);
                }
            }
        }

        private void GetChoose(DrawingContext ctx)
        {
            ctx.DrawGeometry(Config.ActiveBg, null, this.model.Player_1.Selector.RealArea);
            ctx.DrawGeometry(Config.ActiveBg, null, this.model.Player_2.Selector.RealArea);
        }

        private void GetText(DrawingContext ctx)
        {
            this.textPlayer1 = new FormattedText(
                    this.model.Player_1.Name,
                    System.Globalization.CultureInfo.CurrentCulture,
                    FlowDirection.LeftToRight,
                    this.font,
                    32,
                    Config.TextLineColour);

            this.textPlayer2 = new FormattedText(
                    this.model.Player_2.Name,
                    System.Globalization.CultureInfo.CurrentCulture,
                    FlowDirection.RightToLeft,
                    this.font,
                    32,
                    Config.TextLineColour);

            this.textGold1 = new FormattedText(
                    this.model.Player_1.Money.ToString(),
                    System.Globalization.CultureInfo.CurrentCulture,
                    FlowDirection.LeftToRight,
                    this.font,
                    32,
                    Config.TextLineColour);

            this.textGold2 = new FormattedText(
                    this.model.Player_2.Money.ToString(),
                    System.Globalization.CultureInfo.CurrentCulture,
                    FlowDirection.RightToLeft,
                    this.font,
                    32,
                    Config.TextLineColour);

            this.textKnight1Level = new FormattedText(
                    "LVL" + (this.model.Player_1.KnightLVL + 1).ToString(),
                    System.Globalization.CultureInfo.CurrentCulture,
                    FlowDirection.LeftToRight,
                    this.font,
                    18,
                    Config.TextLineColour);

            this.textKnight2Level = new FormattedText(
                    "LVL" + (this.model.Player_2.KnightLVL + 1).ToString(),
                    System.Globalization.CultureInfo.CurrentCulture,
                    FlowDirection.RightToLeft,
                    this.font,
                    18,
                    Config.TextLineColour);

            this.textRider1Level = new FormattedText(
                    "LVL" + (this.model.Player_1.RiderLVL + 1).ToString(),
                    System.Globalization.CultureInfo.CurrentCulture,
                    FlowDirection.LeftToRight,
                    this.font,
                    18,
                    Config.TextLineColour);

            this.textRider2Level = new FormattedText(
                    "LVL" + (this.model.Player_2.RiderLVL + 1).ToString(),
                    System.Globalization.CultureInfo.CurrentCulture,
                    FlowDirection.RightToLeft,
                    this.font,
                    18,
                    Config.TextLineColour);

            this.textBarricade1Level = new FormattedText(
                    "LVL" + (this.model.Player_1.BarricadeLVL + 1).ToString(),
                    System.Globalization.CultureInfo.CurrentCulture,
                    FlowDirection.LeftToRight,
                    this.font,
                    18,
                    Config.TextLineColour);

            this.textBarricade2Level = new FormattedText(
                    "LVL" + (this.model.Player_2.BarricadeLVL + 1).ToString(),
                    System.Globalization.CultureInfo.CurrentCulture,
                    FlowDirection.RightToLeft,
                    this.font,
                    18,
                    Config.TextLineColour);

            this.textKnight1Gold = new FormattedText(
                    this.model.Player_1.KnightPrice.ToString(),
                    System.Globalization.CultureInfo.CurrentCulture,
                    FlowDirection.LeftToRight,
                    this.font,
                    20,
                    Config.GoldTextLineColour);

            this.textKnight2Gold = new FormattedText(
                    this.model.Player_2.KnightPrice.ToString(),
                    System.Globalization.CultureInfo.CurrentCulture,
                    FlowDirection.RightToLeft,
                    this.font,
                    20,
                    Config.GoldTextLineColour);

            this.textRider1Gold = new FormattedText(
                    this.model.Player_1.RiderPrice.ToString(),
                    System.Globalization.CultureInfo.CurrentCulture,
                    FlowDirection.LeftToRight,
                    this.font,
                    20,
                    Config.GoldTextLineColour);

            this.textRider2Gold = new FormattedText(
                    this.model.Player_2.RiderPrice.ToString(),
                    System.Globalization.CultureInfo.CurrentCulture,
                    FlowDirection.RightToLeft,
                    this.font,
                    20,
                    Config.GoldTextLineColour);

            this.textBarricade1Gold = new FormattedText(
                    this.model.Player_1.BarricadePrice.ToString(),
                    System.Globalization.CultureInfo.CurrentCulture,
                    FlowDirection.LeftToRight,
                    this.font,
                    20,
                    Config.GoldTextLineColour);

            this.textBarricade2Gold = new FormattedText(
                    this.model.Player_2.BarricadePrice.ToString(),
                    System.Globalization.CultureInfo.CurrentCulture,
                    FlowDirection.RightToLeft,
                    this.font,
                    20,
                    Config.GoldTextLineColour);

            this.textUpgrade1 = new FormattedText(
                    "UPGRADE",
                    System.Globalization.CultureInfo.CurrentCulture,
                    FlowDirection.LeftToRight,
                    this.font,
                    18,
                    Config.TextLineColour);

            this.textUpgrade2 = new FormattedText(
                    "UPGRADE",
                    System.Globalization.CultureInfo.CurrentCulture,
                    FlowDirection.RightToLeft,
                    this.font,
                    18,
                    Config.TextLineColour);

            this.textUpgradePrice = new FormattedText(
                    "                  UPGRADE PRICE\n" +
                    "Knight: " + Config.KnightUpgradePrice.ToString() +
                    "   Rider: " + Config.RiderUpgradePrice.ToString() +
                    "   Barricade: " + Config.BarricadeUpgradePrice.ToString(),
                    System.Globalization.CultureInfo.CurrentCulture,
                    FlowDirection.LeftToRight,
                    new Typeface("Arial Bold"),
                    20,
                    Config.DarkTextLineColour);

            this.textBack1 = new FormattedText(
                    "BACK",
                    System.Globalization.CultureInfo.CurrentCulture,
                    FlowDirection.LeftToRight,
                    this.font,
                    30,
                    Config.DarkTextLineColour);

            this.textBack2 = new FormattedText(
                    "BACK",
                    System.Globalization.CultureInfo.CurrentCulture,
                    FlowDirection.LeftToRight,
                    this.font,
                    30,
                    Config.DarkTextLineColour);

            this.fortressWar = new FormattedText(
                    "FortressWar",
                    System.Globalization.CultureInfo.CurrentCulture,
                    FlowDirection.LeftToRight,
                    new Typeface("Arial Bold"),
                    100,
                    Config.DarkTextLineColour);

            this.escText = new FormattedText(
                    "ESC - Pause/ End the game.",
                    System.Globalization.CultureInfo.CurrentCulture,
                    FlowDirection.LeftToRight,
                    new Typeface("Arial Bold"),
                    20,
                    Config.TextLineColour);

            this.textFortress1 = new FormattedText(
                    this.model.Player_1.Fortress.Life.ToString(),
                    System.Globalization.CultureInfo.CurrentCulture,
                    FlowDirection.LeftToRight,
                    this.font,
                    32,
                    Config.TextLineColour);

            this.textFortress2 = new FormattedText(
                    this.model.Player_2.Fortress.Life.ToString(),
                    System.Globalization.CultureInfo.CurrentCulture,
                    FlowDirection.RightToLeft,
                    this.font,
                    32,
                    Config.TextLineColour);

            ctx.DrawText(this.textPlayer1, new Point(20, 20));
            ctx.DrawText(this.textPlayer2, new Point(Config.FullWidht - 20, 20));

            ctx.DrawText(this.textGold1, new Point(60, 150));
            ctx.DrawText(this.textGold2, new Point(Config.FullWidht - 60, 150));

            ctx.DrawRectangle(this.GetGoldBrush(), null, this.gold1);
            ctx.DrawRectangle(this.GetGoldBrush(), null, this.gold2);

            ctx.DrawText(this.textKnight1Level, new Point(55, Config.TopHeight + 145));
            ctx.DrawText(this.textKnight2Level, new Point(Config.FullWidht - 55, Config.TopHeight + 145));

            ctx.DrawText(this.textRider1Level, new Point(55, Config.TopHeight + 145 + (Config.SideHeight / 4)));
            ctx.DrawText(this.textRider2Level, new Point(Config.FullWidht - 55, Config.TopHeight + 145 + (Config.SideHeight / 4)));

            ctx.DrawText(this.textBarricade1Level, new Point(55, Config.TopHeight + 145 + (Config.SideHeight / 2)));
            ctx.DrawText(this.textBarricade2Level, new Point(Config.FullWidht - 55, Config.TopHeight + 145 + (Config.SideHeight / 2)));

            ctx.DrawText(this.textKnight1Gold, new Point(55, Config.TopHeight + 10));
            ctx.DrawText(this.textKnight2Gold, new Point(Config.FullWidht - 55, Config.TopHeight + 10));

            ctx.DrawText(this.textRider1Gold, new Point(55, Config.TopHeight + 10 + (Config.SideHeight / 4)));
            ctx.DrawText(this.textRider2Gold, new Point(Config.FullWidht - 55, Config.TopHeight + 10 + (Config.SideHeight / 4)));

            ctx.DrawText(this.textBarricade1Gold, new Point(55, Config.TopHeight + 10 + (Config.SideHeight / 2)));
            ctx.DrawText(this.textBarricade2Gold, new Point(Config.FullWidht - 55, Config.TopHeight + 10 + (Config.SideHeight / 2)));

            ctx.DrawText(this.textUpgrade1, new Point(30, 800));
            ctx.DrawText(this.textUpgrade2, new Point(Config.FullWidht - 30, 800));

            ctx.DrawText(this.textUpgradePrice, new Point(620, Config.TopHeight - 50));

            ctx.DrawText(this.textBack1, new Point(10 + Config.SideWidht + Config.FortressTileWidth - (Config.CharacterTileWidth * 2), 10 + (Config.TopHeight + (90 * 5) + (Config.CharacterTileHeight * 4))));
            ctx.DrawText(this.textBack2, new Point(10 + Config.FullWidht - Config.SideWidht - Config.FortressTileWidth, 10 + (Config.TopHeight + (90 * 5) + (Config.CharacterTileHeight * 4))));

            ctx.DrawText(this.textFortress1, new Point(260, 150));
            ctx.DrawText(this.textFortress2, new Point(Config.FullWidht - 260, 150));

            ctx.DrawText(this.escText, new Point(680, 120));

            ctx.DrawText(this.fortressWar, new Point(510, 10));
        }

        private void GetBarricade(DrawingContext ctx)
        {
            foreach (Barricade baraicade in this.model.Player_1.Barricades)
            {
                ctx.DrawGeometry(this.GetBarricade1Brush(), null, baraicade.RealArea);
            }

            foreach (Barricade baraicade in this.model.Player_2.Barricades)
            {
                ctx.DrawGeometry(this.GetBarricade2Brush(), null, baraicade.RealArea);
            }
        }

        private void GetSoldier(DrawingContext ctx)
        {
            foreach (Soldier soldier in this.model.Player_1.Soldiers)
            {
                if (soldier is Knight)
                {
                    if (soldier.Enemy == null)
                    {
                        if (this.FrameTimer())
                        {
                            ctx.DrawGeometry(this.GetKnight1Brush1(), null, soldier.RealArea);
                        }
                        else
                        {
                            ctx.DrawGeometry(this.GetKnight1Brush2(), null, soldier.RealArea);
                        }
                    }
                    else
                    {
                        if (this.FrameTimer())
                        {
                            ctx.DrawGeometry(this.GetKnightAttack1Brush1(), null, soldier.RealArea);
                        }
                        else
                        {
                            ctx.DrawGeometry(this.GetKnightAttack1Brush2(), null, soldier.RealArea);
                        }
                    }
                }
                else
                {
                    if (soldier.Enemy == null)
                    {
                        if (this.FrameTimer())
                        {
                            ctx.DrawGeometry(this.GetRider1Brush1(), null, soldier.RealArea);
                        }
                        else
                        {
                            ctx.DrawGeometry(this.GetRider1Brush2(), null, soldier.RealArea);
                        }
                    }
                    else
                    {
                        if (this.FrameTimer())
                        {
                            ctx.DrawGeometry(this.GetRiderAttack1Brush1(), null, soldier.RealArea);
                        }
                        else
                        {
                            ctx.DrawGeometry(this.GetRiderAttack1Brush2(), null, soldier.RealArea);
                        }
                    }
                }
            }

            foreach (Soldier soldier in this.model.Player_2.Soldiers)
            {
                if (soldier is Knight)
                {
                    if (soldier.Enemy == null)
                    {
                        if (this.FrameTimer())
                        {
                            ctx.DrawGeometry(this.GetKnight2Brush1(), null, soldier.RealArea);
                        }
                        else
                        {
                            ctx.DrawGeometry(this.GetKnight2Brush2(), null, soldier.RealArea);
                        }
                    }
                    else
                    {
                        if (this.FrameTimer())
                        {
                            ctx.DrawGeometry(this.GetKnightAttack2Brush1(), null, soldier.RealArea);
                        }
                        else
                        {
                            ctx.DrawGeometry(this.GetKnightAttack2Brush2(), null, soldier.RealArea);
                        }
                    }
                }
                else
                {
                    if (soldier.Enemy == null)
                    {
                        if (this.FrameTimer())
                        {
                            ctx.DrawGeometry(this.GetRider2Brush1(), null, soldier.RealArea);
                        }
                        else
                        {
                            ctx.DrawGeometry(this.GetRider2Brush2(), null, soldier.RealArea);
                        }
                    }
                    else
                    {
                        if (this.FrameTimer())
                        {
                            ctx.DrawGeometry(this.GetRiderAttack2Brush1(), null, soldier.RealArea);
                        }
                        else
                        {
                            ctx.DrawGeometry(this.GetRiderAttack2Brush2(), null, soldier.RealArea);
                        }
                    }
                }
            }
        }

        private void GetTopArea(DrawingContext ctx)
        {
            ctx.DrawRectangle(Config.BaseBrownBg, new Pen(Config.CharacterIconLine, 6), this.topBackgroundRect);
        }

        private void GetFortress(DrawingContext ctx)
        {
            if (this.model.Player_1.Fortress.Life < 1500)
            {
                if (this.FrameTimer())
                {
                    ctx.DrawGeometry(this.GetFortressDef1Brush1(), null, this.model.Player_1.Fortress.RealArea);
                }
                else
                {
                    ctx.DrawGeometry(this.GetFortressDef1Brush2(), null, this.model.Player_1.Fortress.RealArea);
                }
            }
            else if (this.model.Player_1.Fortress.Life < 7500)
            {
                if (this.FrameTimer())
                {
                    ctx.DrawGeometry(this.GetFortressHalf1Brush1(), null, this.model.Player_1.Fortress.RealArea);
                }
                else
                {
                    ctx.DrawGeometry(this.GetFortressHalf1Brush2(), null, this.model.Player_1.Fortress.RealArea);
                }
            }
            else
            {
                if (this.FrameTimer())
                {
                    ctx.DrawGeometry(this.GetFortress1Brush1(), null, this.model.Player_1.Fortress.RealArea);
                }
                else
                {
                    ctx.DrawGeometry(this.GetFortress1Brush2(), null, this.model.Player_1.Fortress.RealArea);
                }
            }

            if (this.model.Player_2.Fortress.Life < 1500)
            {
                if (this.FrameTimer())
                {
                    ctx.DrawGeometry(this.GetFortressDef2Brush1(), null, this.model.Player_2.Fortress.RealArea);
                }
                else
                {
                    ctx.DrawGeometry(this.GetFortressDef2Brush2(), null, this.model.Player_2.Fortress.RealArea);
                }
            }
            else if (this.model.Player_2.Fortress.Life < 7500)
            {
                if (this.FrameTimer())
                {
                    ctx.DrawGeometry(this.GetFortressHalf2Brush1(), null, this.model.Player_2.Fortress.RealArea);
                }
                else
                {
                    ctx.DrawGeometry(this.GetFortressHalf2Brush2(), null, this.model.Player_2.Fortress.RealArea);
                }
            }
            else
            {
                if (this.FrameTimer())
                {
                    ctx.DrawGeometry(this.GetFortress2Brush1(), null, this.model.Player_2.Fortress.RealArea);
                }
                else
                {
                    ctx.DrawGeometry(this.GetFortress2Brush2(), null, this.model.Player_2.Fortress.RealArea);
                }
            }
        }

        private void GetCharacterChooseChar(DrawingContext ctx)
        {
            ctx.DrawRectangle(this.GetKnight1Brush1(), null, this.buttonChar1Knight);
            ctx.DrawRectangle(this.GetRider1Brush1(), null, this.buttonChar1Rider);
            ctx.DrawRectangle(this.GetBarricade1Brush(), null, this.buttonChar1Barricade);

            ctx.DrawRectangle(this.GetKnight2Brush1(), null, this.buttonChar2Knight);
            ctx.DrawRectangle(this.GetRider2Brush1(), null, this.buttonChar2Rider);
            ctx.DrawRectangle(this.GetBarricade2Brush(), null, this.buttonChar2Barricade);
        }

        private void GetCharacterChoose(DrawingContext ctx)
        {
            if (this.model.Player_1.Selector.SelectedCharacter == Selector.SelectedCharacters.Knight)
            {
                ctx.DrawRectangle(Config.CurrentActiveBg, new Pen(Config.CharacterIconLine, 6), this.button1Knight);
            }
            else
            {
                ctx.DrawRectangle(Config.CharacterIconBg, new Pen(Config.CharacterIconLine, 6), this.button1Knight);
            }

            if (this.model.Player_1.Selector.SelectedCharacter == Selector.SelectedCharacters.Rider)
            {
                ctx.DrawRectangle(Config.CurrentActiveBg, new Pen(Config.CharacterIconLine, 6), this.button1Rider);
            }
            else
            {
                ctx.DrawRectangle(Config.CharacterIconBg, new Pen(Config.CharacterIconLine, 6), this.button1Rider);
            }

            if (this.model.Player_1.Selector.SelectedCharacter == Selector.SelectedCharacters.Barricade)
            {
                ctx.DrawRectangle(Config.CurrentActiveBg, new Pen(Config.CharacterIconLine, 6), this.button1Barricade);
            }
            else
            {
                ctx.DrawRectangle(Config.CharacterIconBg, new Pen(Config.CharacterIconLine, 6), this.button1Barricade);
            }

            if (this.model.Player_1.Selector.IsUpgrade == true)
            {
                ctx.DrawRectangle(Config.CurrentActiveBg, new Pen(Config.CharacterIconLine, 6), this.button1Upgrade);
            }
            else
            {
                ctx.DrawRectangle(Config.CharacterIconBg, new Pen(Config.CharacterIconLine, 6), this.button1Upgrade);
            }

            if (this.model.Player_2.Selector.SelectedCharacter == Selector.SelectedCharacters.Knight)
            {
                ctx.DrawRectangle(Config.CurrentActiveBg, new Pen(Config.CharacterIconLine, 6), this.button2Knight);
            }
            else
            {
                ctx.DrawRectangle(Config.CharacterIconBg, new Pen(Config.CharacterIconLine, 6), this.button2Knight);
            }

            if (this.model.Player_2.Selector.SelectedCharacter == Selector.SelectedCharacters.Rider)
            {
                ctx.DrawRectangle(Config.CurrentActiveBg, new Pen(Config.CharacterIconLine, 6), this.button2Rider);
            }
            else
            {
                ctx.DrawRectangle(Config.CharacterIconBg, new Pen(Config.CharacterIconLine, 6), this.button2Rider);
            }

            if (this.model.Player_2.Selector.SelectedCharacter == Selector.SelectedCharacters.Barricade)
            {
                ctx.DrawRectangle(Config.CurrentActiveBg, new Pen(Config.CharacterIconLine, 6), this.button2Barricade);
            }
            else
            {
                ctx.DrawRectangle(Config.CharacterIconBg, new Pen(Config.CharacterIconLine, 6), this.button2Barricade);
            }

            if (this.model.Player_2.Selector.IsUpgrade == true)
            {
                ctx.DrawRectangle(Config.CurrentActiveBg, new Pen(Config.CharacterIconLine, 6), this.button2Upgrade);
            }
            else
            {
                ctx.DrawRectangle(Config.CharacterIconBg, new Pen(Config.CharacterIconLine, 6), this.button2Upgrade);
            }
        }

        private void GetRoadChoose(DrawingContext ctx)
        {
            ctx.DrawRectangle(Config.RoadChooseIconBg, null, this.choose11);
            ctx.DrawRectangle(Config.RoadChooseIconBg, null, this.choose12);
            ctx.DrawRectangle(Config.RoadChooseIconBg, null, this.choose13);
            ctx.DrawRectangle(Config.RoadChooseIconBg, null, this.choose14);

            ctx.DrawRectangle(Config.RoadChooseIconBg, null, this.choose21);
            ctx.DrawRectangle(Config.RoadChooseIconBg, null, this.choose22);
            ctx.DrawRectangle(Config.RoadChooseIconBg, null, this.choose23);
            ctx.DrawRectangle(Config.RoadChooseIconBg, null, this.choose24);

            ctx.DrawRectangle(Config.BackBg, null, this.back1);
            ctx.DrawRectangle(Config.BackBg, null, this.back2);
        }

        private void GetRoad(DrawingContext ctx)
        {
            ctx.DrawRectangle(Config.RoadBg, null, this.road1);
            ctx.DrawRectangle(Config.RoadBg, null, this.road2);
            ctx.DrawRectangle(Config.RoadBg, null, this.road3);
            ctx.DrawRectangle(Config.RoadBg, null, this.road4);
        }

        private void GetBackground(DrawingContext ctx)
        {
            ctx.DrawRectangle(this.GetFieldBrush(), null, this.backgroundRect);
        }
    }
}