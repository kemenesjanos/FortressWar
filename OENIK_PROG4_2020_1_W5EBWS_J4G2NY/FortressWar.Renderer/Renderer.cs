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
        private Rect choose11;
        private Rect choose12;
        private Rect choose13;
        private Rect choose14;

        private Rect button21;
        private Rect button22;
        private Rect button23;
        private Rect button24;
        private Rect choose21;
        private Rect choose22;
        private Rect choose23;
        private Rect choose24;

        private Rect road1;
        private Rect road2;
        private Rect road3;
        private Rect road4;

        private Rect fortress1;
        private Rect fortress2;

        private Typeface font = new Typeface("Arial");
        private Point textLocation = new Point(10, 10);

        private Dictionary<string, Brush> brushes = new Dictionary<string, Brush>();

        /// <summary>
        /// Initializes a new instance of the <see cref="Renderer"/> class.
        /// </summary>
        /// <param name="model">The parameter.</param>
        public Renderer(Model model)
        {
            this.model = model;
            this.backgroundRect = new Rect(0, 0, Config.FullWidht, Config.FullHeight);
            this.topBackgroundRect = new Rect(0, 0, Config.TopWidth, Config.TopHeight);

            this.button11 = new Rect(0, -Config.TopWidth,
                Config.SideWidht, Config.SideHeight / 4);
            this.button12 = new Rect(0, -(Config.TopWidth + (Config.SideHeight / 4)),
                Config.SideWidht, Config.SideHeight / 4);
            this.button13 = new Rect(0, -(Config.TopWidth + (Config.SideHeight / 4 * 2)),
                Config.SideWidht, Config.SideHeight / 4);
            this.button14 = new Rect(0, -(Config.TopWidth + (Config.SideHeight / 4 * 3)),
                Config.SideWidht, Config.SideHeight / 4);

            this.button21 = new Rect(Config.FullWidht - Config.SideWidht, -Config.TopWidth,
                Config.SideWidht, Config.SideHeight / 4);
            this.button22 = new Rect(Config.FullWidht - Config.SideWidht, -(Config.TopWidth + (Config.SideHeight / 4)),
                Config.SideWidht, Config.SideHeight / 4);
            this.button23 = new Rect(Config.FullWidht - Config.SideWidht, -(Config.TopWidth + (Config.SideHeight / 4)),
                Config.SideWidht, Config.SideHeight / 4);
            this.button24 = new Rect(Config.FullWidht - Config.SideWidht, -(Config.TopWidth + (Config.SideHeight / 4)),
                Config.SideWidht, Config.SideHeight / 4);

            this.road1 = new Rect(Config.SideWidht + Config.FortressTileWidth, -(Config.TopWidth + 90),
                Config.FieldWidht, Config.CharacterTileHeight);
            this.road2 = new Rect(Config.SideWidht + Config.FortressTileWidth, -(Config.TopWidth + 90 * 2 + Config.CharacterTileHeight),
                Config.FieldWidht, Config.CharacterTileHeight);
            this.road3 = new Rect(Config.SideWidht + Config.FortressTileWidth, -(Config.TopWidth + 90 * 3 + Config.CharacterTileHeight * 2),
                Config.FieldWidht, Config.CharacterTileHeight);
            this.road4 = new Rect(Config.SideWidht + Config.FortressTileWidth, -(Config.TopWidth + 90 * 4 + Config.CharacterTileHeight * 3),
                Config.FieldWidht, Config.CharacterTileHeight);

            this.choose11 = new Rect(Config.SideWidht + Config.FortressTileWidth - (Config.CharacterTileWidth * 2), -(Config.TopWidth + 90),
                Config.CharacterTileWidth * 2, Config.CharacterTileHeight);
            this.choose12 = new Rect(Config.SideWidht + Config.FortressTileWidth - (Config.CharacterTileWidth * 2), -(Config.TopWidth + 90 * 2 + Config.CharacterTileHeight),
                Config.CharacterTileWidth * 2, Config.CharacterTileHeight);
            this.choose13 = new Rect(Config.SideWidht + Config.FortressTileWidth - (Config.CharacterTileWidth * 2), -(Config.TopWidth + 90 * 3 + Config.CharacterTileHeight * 2),
                Config.CharacterTileWidth * 2, Config.CharacterTileHeight);
            this.choose14 = new Rect(Config.SideWidht + Config.FortressTileWidth - (Config.CharacterTileWidth * 2), -(Config.TopWidth + 90 * 4 + Config.CharacterTileHeight * 3),
                Config.CharacterTileWidth * 2, Config.CharacterTileHeight);

            this.choose21 = new Rect(Config.FullWidht - Config.SideWidht - Config.FortressTileWidth, -(Config.TopWidth + 90),
                Config.CharacterTileWidth * 2, Config.CharacterTileHeight);
            this.choose22 = new Rect(Config.FullWidht - Config.SideWidht - Config.FortressTileWidth, -(Config.TopWidth + 90 * 2 + Config.CharacterTileHeight),
                Config.CharacterTileWidth * 2, Config.CharacterTileHeight);
            this.choose23 = new Rect(Config.FullWidht - Config.SideWidht - Config.FortressTileWidth, -(Config.TopWidth + 90 * 3 + Config.CharacterTileHeight * 2),
                Config.CharacterTileWidth * 2, Config.CharacterTileHeight);
            this.choose24 = new Rect(Config.FullWidht - Config.SideWidht - Config.FortressTileWidth, -(Config.TopWidth + 90 * 4 + Config.CharacterTileHeight * 3),
                Config.CharacterTileWidth * 2, Config.CharacterTileHeight);

            //TODO: ez egy karakter objektum, ennek nem itt kell majd lennie
            this.fortress1 = new Rect(Config.SideWidht, -Config.TopHeight,
                Config.FortressTileWidth, Config.FortressTileHeight);
            this.fortress2 = new Rect(Config.FieldWidht - Config.SideWidht - Config.FortressTileWidth, -Config.TopHeight,
                Config.FortressTileWidth, Config.FortressTileHeight);
        }

        /// <summary>
        /// Help to add images as brush.
        /// </summary>
        /// <param name="fname">Image name.</param>
        /// <param name="isTiled">Repeating of the image.</param>
        /// <returns>The image as brush.</returns>
        private Brush GetBrush(string fname, bool isTiled)
        {
            if (!this.brushes.ContainsKey(fname))
            {
                BitmapImage bmp = new BitmapImage();

                bmp.BeginInit();
                bmp.StreamSource = Assembly.GetExecutingAssembly().GetManifestResourceStream(fname);
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
        private Brush GetFortressBrush(string fname, bool isTiled)
        {
            if (!this.brushes.ContainsKey(fname))
            {
                BitmapImage bmp = new BitmapImage();

                bmp.BeginInit();
                bmp.StreamSource = Assembly.GetExecutingAssembly().GetManifestResourceStream(fname);
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
            get { return this.GetBrush("FortressWar.Model.Images.grass.png", true); }
        }

        /// <summary>
        /// Gets make Knight1 brush.
        /// </summary>
        private Brush Knight1Brush
        {
            get { return this.GetBrush("FortressWar.Model.Images.1walk1.png", false); }
        }

        /// <summary>
        /// Gets make Knight2 brush.
        /// </summary>
        private Brush Knight2Brush
        {
            get { return this.GetBrush("FortressWar.Model.Images.2walk1.png", false); }
        }

        /// <summary>
        /// Gets make Rider1 brush.
        /// </summary>
        private Brush Rider1Brush
        {
            get { return this.GetBrush("FortressWar.Model.Images.1hwalk1.png", false); }
        }

        /// <summary>
        /// Gets make Rider2 brush.
        /// </summary>
        private Brush Rider2Brush
        {
            get { return this.GetBrush("FortressWar.Model.Images.2hwalk1.png", false); }
        }

        /// <summary>
        /// Gets make Barricade1 brush.
        /// </summary>
        private Brush Barricade1Brush
        {
            get { return this.GetBrush("FortressWar.Model.Images.1barricade.png", false); }
        }

        /// <summary>
        /// Gets make Barricade2 brush.
        /// </summary>
        private Brush Barricade2Brush
        {
            get { return this.GetBrush("FortressWar.Model.Images.2barricade.png", false); }
        }

        /// <summary>
        /// Gets make Barricade2 brush.
        /// </summary>
        private Brush Fortress1Brush
        {
            get { return this.GetFortressBrush("FortressWar.Model.Images.1fortress1.png", false); }
        }

        /// <summary>
        /// Gets make Barricade2 brush.
        /// </summary>
        private Brush Fortress2Brush
        {
            get { return this.GetFortressBrush("FortressWar.Model.Images.2fortress1.png", false); }
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

        private void getSoldierFight(DrawingContext ctx)
        {
            throw new NotImplementedException();
        }

        private void GetText(DrawingContext ctx)
        {
            //TODO: nagyon sok kell, ha többi hátérelem, oké, majd akkor beállítjuk
            throw new NotImplementedException();
        }

        private void GetBarricade(DrawingContext ctx)
        {
            //TODO: old vizsgálat
            //TODO: foreach és ctx összeegyeztetés
        }

        private void GetSoldier(DrawingContext ctx)
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
                    ctx.DrawGeometry(this.Knight1Brush, null, soldier.RealArea);
                }
                else
                {
                    ctx.DrawGeometry(this.Rider1Brush, null, soldier.RealArea);
                }
            }
        }

        private void GetTopArea(DrawingContext ctx)
        {
            ctx.DrawRectangle(Config.BaseBrownBg, null, this.topBackgroundRect);
        }

        private void GetFortress(DrawingContext ctx)
        {
            //TODO: old vizsgálat, gondolom kellene ide egy if, h nézze, h mikor h rajzolja ki
            ctx.DrawRectangle(this.Fortress1Brush, null, this.fortress1);
            ctx.DrawRectangle(this.Fortress2Brush, null, this.fortress2);
        }

        private void GetCharacterChoose(DrawingContext ctx)
        {
            //TODO if -> aktív nem akítv
            ctx.DrawRectangle(Config.CharacterIconBg, new Pen(Config.CharacterIconLine, 2), this.button11);
            ctx.DrawRectangle(Config.CharacterIconBg, new Pen(Config.CharacterIconLine, 2), this.button12);
            ctx.DrawRectangle(Config.CharacterIconBg, new Pen(Config.CharacterIconLine, 2), this.button13);
            ctx.DrawRectangle(Config.CharacterIconBg, new Pen(Config.CharacterIconLine, 2), this.button14);

            ctx.DrawRectangle(Config.CharacterIconBg, new Pen(Config.CharacterIconLine, 2), this.button21);
            ctx.DrawRectangle(Config.CharacterIconBg, new Pen(Config.CharacterIconLine, 2), this.button22);
            ctx.DrawRectangle(Config.CharacterIconBg, new Pen(Config.CharacterIconLine, 2), this.button23);
            ctx.DrawRectangle(Config.CharacterIconBg, new Pen(Config.CharacterIconLine, 2), this.button24);
        }

        private void GetRoadChoose(DrawingContext ctx)
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

        private void GetRoad(DrawingContext ctx)
        {
            ctx.DrawRectangle(Config.RoadBg, null, this.road1);
            ctx.DrawRectangle(Config.RoadBg, null, this.road2);
            ctx.DrawRectangle(Config.RoadBg, null, this.road3);
            ctx.DrawRectangle(Config.RoadBg, null, this.road4);
        }

        private void GetBackground(DrawingContext ctx)
        {
            ctx.DrawRectangle(this.FieldBrush, null, this.backgroundRect);
        }
    }
}
