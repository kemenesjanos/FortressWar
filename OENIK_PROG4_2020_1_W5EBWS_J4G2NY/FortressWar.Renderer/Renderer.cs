// <copyright file="Renderer.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace FortressWar.Renderer
{
    using System;
    using System.Collections.Generic;
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
        private Model model;
        private Rect backgroundRect;
        private Rect topBackgroundRect;

        private Rect button11;
        private Rect button12;
        private Rect button13;
        private Rect button14;
        private Rect buttonchar11;
        private Rect buttonchar12;
        private Rect buttonchar13;
        private Rect choose11;
        private Rect choose12;
        private Rect choose13;
        private Rect choose14;

        private Rect button21;
        private Rect button22;
        private Rect button23;
        private Rect button24;
        private Rect buttonchar21;
        private Rect buttonchar22;
        private Rect buttonchar23;
        private Rect choose21;
        private Rect choose22;
        private Rect choose23;
        private Rect choose24;

        private Rect road1;
        private Rect road2;
        private Rect road3;
        private Rect road4;

        private Rect gold1;
        private Rect gold2;

        private Rect fortress1;
        private Rect fortress2;

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

        private FormattedText upgrade1;
        private FormattedText upgrade2;

        private FormattedText fortressWar;

        private Size jatekmeret;

        private Dictionary<string, Brush> brushes = new Dictionary<string, Brush>();

        /// <summary>
        /// Initializes a new instance of the <see cref="Renderer"/> class.
        /// </summary>
        /// <param name="model">The parameter.</param>
        public Renderer(Model model)
        {
            this.model = model;
            this.backgroundRect = new Rect(0, 0, model.GameWidth, model.GameHeight);
            this.topBackgroundRect = new Rect(0, 0, model.GameWidth, model.GameHeight * 0.2);

            this.button11 = new Rect(0, model.GameHeight * 0.2,
                Config.SideWidht, Config.SideHeight / 4);
            this.button12 = new Rect(0, (model.GameHeight * 0.2 + (model.GameHeight * 0.8 / 4)),
                Config.SideWidht, Config.SideHeight / 4);
            this.button13 = new Rect(0, (model.GameHeight * 0.2 + (model.GameHeight * 0.8 / 4 * 2)),
                Config.SideWidht, Config.SideHeight / 4);
            this.button14 = new Rect(0, (model.GameHeight * 0.2 + (model.GameHeight * 0.8 / 4 * 3)),
                Config.SideWidht, Config.SideHeight / 4);

            this.buttonchar11 = new Rect(Config.CharacterTileWidth - 25, Config.TopHeight + 40,
                Config.CharacterTileWidth * 2, Config.CharacterTileHeight * 2);
            this.buttonchar12 = new Rect(Config.CharacterTileWidth - 25, Config.TopHeight + Config.SideHeight / 4 + 40,
                Config.CharacterTileWidth * 2, Config.CharacterTileHeight * 2);
            this.buttonchar13 = new Rect(Config.CharacterTileWidth - 25, Config.TopHeight + Config.SideHeight / 4 * 2 + 40,
                Config.CharacterTileWidth * 2, Config.CharacterTileHeight * 2);

            this.button21 = new Rect(model.GameWidth - Config.SideWidht, model.GameHeight * 0.2,
                Config.SideWidht, Config.SideHeight / 4);
            this.button22 = new Rect(model.GameWidth - Config.SideWidht, (model.GameHeight * 0.2 + (model.GameHeight * 0.8 / 4)),
                Config.SideWidht, Config.SideHeight / 4);
            this.button23 = new Rect(model.GameWidth - Config.SideWidht, (model.GameHeight * 0.2 + (model.GameHeight * 0.8 / 4 * 2)),
                Config.SideWidht, Config.SideHeight / 4);
            this.button24 = new Rect(model.GameWidth - Config.SideWidht, (model.GameHeight * 0.2 + (model.GameHeight * 0.8 / 4 * 3)),
                Config.SideWidht, Config.SideHeight / 4);

            this.buttonchar21 = new Rect(Config.FullWidht - Config.CharacterTileWidth - 75, Config.TopHeight + 40,
                Config.CharacterTileWidth * 2, Config.CharacterTileHeight * 2);
            this.buttonchar22 = new Rect(Config.FullWidht - Config.CharacterTileWidth - 75, Config.TopHeight + Config.SideHeight / 4 + 40,
                Config.CharacterTileWidth * 2, Config.CharacterTileHeight * 2);
            this.buttonchar23 = new Rect(Config.FullWidht - Config.CharacterTileWidth - 75, Config.TopHeight + Config.SideHeight / 4 * 2 + 40,
                Config.CharacterTileWidth * 2, Config.CharacterTileHeight * 2);

            this.road1 = new Rect(Config.SideWidht + Config.FortressTileWidth, Config.TopHeight + 90,
                Config.FieldWidht, Config.CharacterTileHeight);
            this.road2 = new Rect(Config.SideWidht + Config.FortressTileWidth, (Config.TopHeight + 90 * 2 + Config.CharacterTileHeight),
                Config.FieldWidht, Config.CharacterTileHeight);
            this.road3 = new Rect(Config.SideWidht + Config.FortressTileWidth, (Config.TopHeight + 90 * 3 + Config.CharacterTileHeight * 2),
                Config.FieldWidht, Config.CharacterTileHeight);
            this.road4 = new Rect(Config.SideWidht + Config.FortressTileWidth, (Config.TopHeight + 90 * 4 + Config.CharacterTileHeight * 3),
                Config.FieldWidht, Config.CharacterTileHeight);

            this.choose11 = new Rect(Config.SideWidht + Config.FortressTileWidth - (Config.CharacterTileWidth * 2), (Config.TopHeight + 90),
                Config.CharacterTileWidth * 2, Config.CharacterTileHeight);
            this.choose12 = new Rect(Config.SideWidht + Config.FortressTileWidth - (Config.CharacterTileWidth * 2), (Config.TopHeight + 90 * 2 + Config.CharacterTileHeight),
                Config.CharacterTileWidth * 2, Config.CharacterTileHeight);
            this.choose13 = new Rect(Config.SideWidht + Config.FortressTileWidth - (Config.CharacterTileWidth * 2), (Config.TopHeight + 90 * 3 + Config.CharacterTileHeight * 2),
                Config.CharacterTileWidth * 2, Config.CharacterTileHeight);
            this.choose14 = new Rect(Config.SideWidht + Config.FortressTileWidth - (Config.CharacterTileWidth * 2), (Config.TopHeight + 90 * 4 + Config.CharacterTileHeight * 3),
                Config.CharacterTileWidth * 2, Config.CharacterTileHeight);

            this.choose21 = new Rect(Config.FullWidht - Config.SideWidht - Config.FortressTileWidth, (Config.TopHeight + 90),
                Config.CharacterTileWidth * 2, Config.CharacterTileHeight);
            this.choose22 = new Rect(Config.FullWidht - Config.SideWidht - Config.FortressTileWidth, (Config.TopHeight + 90 * 2 + Config.CharacterTileHeight),
                Config.CharacterTileWidth * 2, Config.CharacterTileHeight);
            this.choose23 = new Rect(Config.FullWidht - Config.SideWidht - Config.FortressTileWidth, (Config.TopHeight + 90 * 3 + Config.CharacterTileHeight * 2),
                Config.CharacterTileWidth * 2, Config.CharacterTileHeight);
            this.choose24 = new Rect(Config.FullWidht - Config.SideWidht - Config.FortressTileWidth, (Config.TopHeight + 90 * 4 + Config.CharacterTileHeight * 3),
                Config.CharacterTileWidth * 2, Config.CharacterTileHeight);

            this.gold1 = new Rect(5, 125, Config.CharacterTileWidth, Config.CharacterTileHeight * 1.5);
            this.gold2 = new Rect(Config.FullWidht - 5 - Config.CharacterTileWidth, 125, Config.CharacterTileWidth, Config.CharacterTileHeight * 1.5);

            //TODO: ez egy karakter objektum, ennek nem itt kell majd lennie
            this.fortress1 = new Rect(Config.SideWidht, Config.TopHeight + 50,
                Config.FortressTileWidth, Config.FortressTileHeight);
            this.fortress2 = new Rect(Config.FieldWidht + Config.SideWidht + Config.FortressTileWidth, Config.TopHeight + 50,
                Config.FortressTileWidth, Config.FortressTileHeight);
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
        /// Gets make Knight1 brush.
        /// </summary>
        private Brush FieldBrush
        {
            get { return this.GetBrush("FortressWar.Images.grass.png", true); }
        }

        /// <summary>
        /// Gets make Knight1 brush.
        /// </summary>
        private Brush Knight1Brush
        {
            get { return this.GetBrush("FortressWar.Images.1walk1.png", false); }
        }

        /// <summary>
        /// Gets make Knight2 brush.
        /// </summary>
        private Brush Knight2Brush
        {
            get { return this.GetBrush("FortressWar.Images.2walk1.png", false); }
        }

        /// <summary>
        /// Gets make Rider1 brush.
        /// </summary>
        private Brush Rider1Brush
        {
            get { return this.GetBrush("FortressWar.Images.1hwalk1.png", false); }
        }

        /// <summary>
        /// Gets make Rider2 brush.
        /// </summary>
        private Brush Rider2Brush
        {
            get { return this.GetBrush("FortressWar.Images.2hwalk1.png", false); }
        }

        /// <summary>
        /// Gets make Barricade1 brush.
        /// </summary>
        private Brush Barricade1Brush
        {
            get { return this.GetBrush("FortressWar.Images.1barricade.png", false); }
        }

        /// <summary>
        /// Gets make Barricade2 brush.
        /// </summary>
        private Brush Barricade2Brush
        {
            get { return this.GetBrush("FortressWar.Images.2barricade.png", false); }
        }

        /// <summary>
        /// Gets make Barricade2 brush.
        /// </summary>
        private Brush Fortress1Brush
        {
            get { return this.GetFortressBrush("FortressWar.Images.1fortress1.png", false); }
        }

        /// <summary>
        /// Gets make Barricade2 brush.
        /// </summary>
        private Brush Fortress2Brush
        {
            get { return this.GetFortressBrush("FortressWar.Images.2fortress1.png", false); }
        }

        /// <summary>
        /// Gets make Barricade2 brush.
        /// </summary>
        private Brush GoldBrush
        {
            get { return this.GetBrush("FortressWar.Images.coin1.png", false); }
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
            this.GetFortress(ctx);

            this.GetBarricade(ctx);
            this.GetSoldier(ctx);

            this.getSoldierFight(ctx);

            this.GetText(ctx);
        }

        public void getSoldierFight(DrawingContext ctx)
        {
            //throw new NotImplementedException();
        }

        public void GetText(DrawingContext ctx)
        {
            //TODO: nagyon sok kell, ha többi hátérelem, oké, majd akkor beállítjuk
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
                    this.model.Player_1.KnightLVL.ToString(),
                    System.Globalization.CultureInfo.CurrentCulture,
                    FlowDirection.LeftToRight,
                    this.font,
                    18,
                    Config.TextLineColour);

            this.textKnight2Level = new FormattedText(
                    this.model.Player_2.KnightLVL.ToString(),
                    System.Globalization.CultureInfo.CurrentCulture,
                    FlowDirection.RightToLeft,
                    this.font,
                    18,
                    Config.TextLineColour);

            this.textRider1Level = new FormattedText(
                    this.model.Player_1.RiderLVL.ToString(),
                    System.Globalization.CultureInfo.CurrentCulture,
                    FlowDirection.LeftToRight,
                    this.font,
                    18,
                    Config.TextLineColour);

            this.textRider2Level = new FormattedText(
                    this.model.Player_2.RiderLVL.ToString(),
                    System.Globalization.CultureInfo.CurrentCulture,
                    FlowDirection.RightToLeft,
                    this.font,
                    18,
                    Config.TextLineColour);

            this.textBarricade1Level = new FormattedText(
                    this.model.Player_1.BarricadeLVL.ToString(),
                    System.Globalization.CultureInfo.CurrentCulture,
                    FlowDirection.LeftToRight,
                    this.font,
                    18,
                    Config.TextLineColour);

            this.textBarricade2Level = new FormattedText(
                    this.model.Player_2.BarricadeLVL.ToString(),
                    System.Globalization.CultureInfo.CurrentCulture,
                    FlowDirection.RightToLeft,
                    this.font,
                    18,
                    Config.TextLineColour);

            this.textKnight1Gold = new FormattedText(
                    "200",
                    System.Globalization.CultureInfo.CurrentCulture,
                    FlowDirection.LeftToRight,
                    this.font,
                    20,
                    Config.GoldTextLineColour);

            this.textKnight2Gold = new FormattedText(
                    "200",
                    System.Globalization.CultureInfo.CurrentCulture,
                    FlowDirection.RightToLeft,
                    this.font,
                    20,
                    Config.GoldTextLineColour);

            this.textRider1Gold = new FormattedText(
                    "400",
                    System.Globalization.CultureInfo.CurrentCulture,
                    FlowDirection.LeftToRight,
                    this.font,
                    20,
                    Config.GoldTextLineColour);

            this.textRider2Gold = new FormattedText(
                    "400",
                    System.Globalization.CultureInfo.CurrentCulture,
                    FlowDirection.RightToLeft,
                    this.font,
                    20,
                    Config.GoldTextLineColour);

            this.textBarricade1Gold = new FormattedText(
                    "150",
                    System.Globalization.CultureInfo.CurrentCulture,
                    FlowDirection.LeftToRight,
                    this.font,
                    20,
                    Config.GoldTextLineColour);

            this.textBarricade2Gold = new FormattedText(
                    "150",
                    System.Globalization.CultureInfo.CurrentCulture,
                    FlowDirection.RightToLeft,
                    this.font,
                    20,
                    Config.GoldTextLineColour);

            this.upgrade1 = new FormattedText(
                    "UPGRADE",
                    System.Globalization.CultureInfo.CurrentCulture,
                    FlowDirection.LeftToRight,
                    this.font,
                    18,
                    Config.TextLineColour);

            this.upgrade2 = new FormattedText(
                    "UPGRADE",
                    System.Globalization.CultureInfo.CurrentCulture,
                    FlowDirection.RightToLeft,
                    this.font,
                    18,
                    Config.TextLineColour);

            this.fortressWar = new FormattedText(
                    "FortressWar",
                    System.Globalization.CultureInfo.CurrentCulture,
                    FlowDirection.LeftToRight,
                    new Typeface("Arial Bold"),
                    100,
                    Config.DarkTextLineColour);

            ctx.DrawText(this.textPlayer1, new Point(20, 20));
            ctx.DrawText(this.textPlayer2, new Point(Config.FullWidht - 20, 20));

            ctx.DrawText(this.textGold1, new Point(60, 150));
            ctx.DrawText(this.textGold2, new Point(Config.FullWidht - 60, 150));

            ctx.DrawRectangle(this.GoldBrush, null, this.gold1);
            ctx.DrawRectangle(this.GoldBrush, null, this.gold2);

            ctx.DrawText(this.textKnight1Level, new Point(70, Config.TopHeight + 145));
            ctx.DrawText(this.textKnight2Level, new Point(Config.FullWidht - 70, Config.TopHeight + 145));

            ctx.DrawText(this.textRider1Level, new Point(70, Config.TopHeight + 145 + Config.SideHeight/4));
            ctx.DrawText(this.textRider2Level, new Point(Config.FullWidht - 70, Config.TopHeight + 145 + Config.SideHeight / 4));

            ctx.DrawText(this.textBarricade1Level, new Point(70, Config.TopHeight + 145 + Config.SideHeight / 2));
            ctx.DrawText(this.textBarricade2Level, new Point(Config.FullWidht - 70, Config.TopHeight + 145 + Config.SideHeight / 2));

            ctx.DrawText(this.textKnight1Gold, new Point(55, Config.TopHeight + 10));
            ctx.DrawText(this.textKnight2Gold, new Point(Config.FullWidht - 55, Config.TopHeight + 10));

            ctx.DrawText(this.textRider1Gold, new Point(55, Config.TopHeight + 10 + Config.SideHeight / 4));
            ctx.DrawText(this.textRider2Gold, new Point(Config.FullWidht - 55, Config.TopHeight + 10 + Config.SideHeight / 4));

            ctx.DrawText(this.textBarricade1Gold, new Point(55, Config.TopHeight + 10 + Config.SideHeight / 2));
            ctx.DrawText(this.textBarricade2Gold, new Point(Config.FullWidht - 55, Config.TopHeight + 10 + Config.SideHeight / 2));

            ctx.DrawText(this.upgrade1, new Point(30, 800));
            ctx.DrawText(this.upgrade2, new Point(Config.FullWidht - 30, 800));

            ctx.DrawText(this.fortressWar, new Point(510, 20));
        }

        public void GetBarricade(DrawingContext ctx)
        {
            //TODO: old vizsgálat
            foreach (Barricade baraicade in this.model.Player_1.Barricades)
            {
                ctx.DrawGeometry(this.Barricade1Brush, null, baraicade.RealArea);
            }

            foreach (Barricade baraicade in this.model.Player_2.Barricades)
            {
                ctx.DrawGeometry(this.Barricade2Brush, null, baraicade.RealArea);
            }
        }

        public void GetSoldier(DrawingContext ctx)
        {
            foreach (Soldier soldier in this.model.Player_1.Soldiers)
            {
                if (soldier is Knight)
                {
                    //TODO: if(Soldier.enemy == null) -> járó gif, else -> támadó if- je, ide meghívni a fight-ot
                    ctx.DrawGeometry(this.Knight1Brush, null, soldier.RealArea);
                }
                else
                {
                    ctx.DrawGeometry(this.Rider1Brush, null, soldier.RealArea);
                }
            }

            foreach (Soldier soldier in this.model.Player_2.Soldiers)
            {
                if (soldier is Knight)
                {
                    ctx.DrawGeometry(this.Knight2Brush, null, soldier.RealArea);
                }
                else
                {
                    ctx.DrawGeometry(this.Rider2Brush, null, soldier.RealArea);
                }
            }
        }

        public void GetTopArea(DrawingContext ctx)
        {
            ctx.DrawRectangle(Config.BaseBrownBg, null, this.topBackgroundRect);
        }

        public void GetFortress(DrawingContext ctx)
        {
            //TODO: old vizsgálat, gondolom kellene ide egy if, h nézze, h mikor h rajzolja ki
            ctx.DrawRectangle(this.Fortress1Brush, null, this.fortress1);
            ctx.DrawRectangle(this.Fortress2Brush, null, this.fortress2);
        }

        public void GetCharacterChoose(DrawingContext ctx)
        {
            //TODO if -> aktív nem akítv
            ctx.DrawRectangle(Config.CharacterIconBg, new Pen(Config.CharacterIconLine, 6), this.button11);
            ctx.DrawRectangle(Config.CharacterIconBg, new Pen(Config.CharacterIconLine, 6), this.button12);
            ctx.DrawRectangle(Config.CharacterIconBg, new Pen(Config.CharacterIconLine, 6), this.button13);
            ctx.DrawRectangle(Config.CharacterIconBg, new Pen(Config.CharacterIconLine, 6), this.button14);

            ctx.DrawRectangle(this.Knight1Brush, null, this.buttonchar11);
            ctx.DrawRectangle(this.Rider1Brush, null, this.buttonchar12);
            ctx.DrawRectangle(this.Barricade1Brush, null, this.buttonchar13);

            ctx.DrawRectangle(Config.CharacterIconBg, new Pen(Config.CharacterIconLine, 6), this.button21);
            ctx.DrawRectangle(Config.CharacterIconBg, new Pen(Config.CharacterIconLine, 6), this.button22);
            ctx.DrawRectangle(Config.CharacterIconBg, new Pen(Config.CharacterIconLine, 6), this.button23);
            ctx.DrawRectangle(Config.CharacterIconBg, new Pen(Config.CharacterIconLine, 6), this.button24);

            ctx.DrawRectangle(this.Knight2Brush, null, this.buttonchar21);
            ctx.DrawRectangle(this.Rider2Brush, null, this.buttonchar22);
            ctx.DrawRectangle(this.Barricade2Brush, null, this.buttonchar23);
        }

        public void GetRoadChoose(DrawingContext ctx)
        {
            //TODO if -> aktív nem akítv
            ctx.DrawRectangle(Config.RoadChooseIconBg, null, this.choose11);
            ctx.DrawRectangle(Config.RoadChooseIconBg, null, this.choose12);
            ctx.DrawRectangle(Config.RoadChooseIconBg, null, this.choose13);
            ctx.DrawRectangle(Config.RoadChooseIconBg, null, this.choose14);

            ctx.DrawRectangle(Config.RoadChooseIconBg, null, this.choose21);
            ctx.DrawRectangle(Config.RoadChooseIconBg, null, this.choose22);
            ctx.DrawRectangle(Config.RoadChooseIconBg, null, this.choose23);
            ctx.DrawRectangle(Config.RoadChooseIconBg, null, this.choose24);
        }

        public void GetRoad(DrawingContext ctx)
        {
            ctx.DrawRectangle(Config.RoadBg, null, this.road1);
            ctx.DrawRectangle(Config.RoadBg, null, this.road2);
            ctx.DrawRectangle(Config.RoadBg, null, this.road3);
            ctx.DrawRectangle(Config.RoadBg, null, this.road4);
        }

        public void GetBackground(DrawingContext ctx)
        {
            ctx.DrawRectangle(this.FieldBrush, null, this.backgroundRect);
        }
    }
}
