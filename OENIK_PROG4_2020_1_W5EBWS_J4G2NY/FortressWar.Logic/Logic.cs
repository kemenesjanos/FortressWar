// <copyright file="Logic.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace FortressWar.Logic
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Media;
    using System.Xml.Serialization;
    using FortressWar.Model;

    /// <summary>
    /// Logic.
    /// </summary>
    public class Logic : ILogic
    {
        private Model model;
        private Random rnd = new Random();

        /// <summary>
        /// Initializes a new instance of the <see cref="Logic"/> class.
        /// Ctor.
        /// </summary>
        /// <param name="model">A model instance.</param>
        public Logic(Model model)
        {
            this.model = model;
            this.StartGame();
            this.model.Player_1.Name = "Player1";
            this.model.Player_2.Name = "Player2";
            //this.NewCharacter(Characters.Knight, model.Player_1, 1);
            this.SaveGameState();
            this.LoadGameState();
        }

        //TODO: Nézd meg, hogy a tesztek hisztiznek e erre a lépésemre (hogy van egy 2. ctor más beviteli elvárással, bár nem hiszem, elv nem kéne) - mivel nálam még mindig nem hajlandó tesztet nézni... xD

        //TODO: A Load működtetésére nagyon tuskósan egy LoadControl.cs létrehozását javasolnám! Ugyanúgy nézne ki, mint a Control.cs, csak ezt a 2. fajta logicot hívja meg. Ha elfogadod, akkor írd meg és délután megcsinálom!
        //TODO: Mivel restartol a Control mindig, nincs ötletem, hogy hogyan tudnék olyan változót vagy eseményt létrehozni, ami megtartja magában az értéket és ezt a wpf látná, ha valami akció történik benne.
        //TODO: Nagyon nem rugalmas a WPF.

        /// <summary>
        /// Initializes a new instance of the <see cref="Logic"/> class.
        /// Ctor.
        /// </summary>
        /// <param name="model">A model instance.</param>
        public Logic(Model model, bool load)
        {
            this.model = model;
            this.StartGame();
            this.model.Player_1.Name = "Player1";
            this.model.Player_2.Name = "Player2";
            //this.NewCharacter(Characters.Knight, model.Player_1, 1);
            //this.SaveGameState();
            //this.LoadGameState();
        }

        /// <summary>
        /// The RefreshScreen event is called if the screen have to be Refreshed.
        /// </summary>
        public event EventHandler RefreshScreen;

        /// <summary>
        /// Is called if the game finished.
        /// </summary>
        public event EventHandler FinishedGame;

        /// <summary>
        /// Decrease the attacked character's life.
        /// </summary>
        /// <param name="attackedCharacter">The attacked character.</param>
        /// <param name="damage">The attacker's power.</param>
        /// <returns>Is the attacked character is dead.</returns>
        public bool Attack(Character attackedCharacter, int damage)
        {
            if (attackedCharacter.Life - damage <= 0)
            {
                attackedCharacter.Life = 0;
                this.Die(attackedCharacter);
                this.RefreshScreen?.Invoke(this, EventArgs.Empty);
                return true;
            }
            else
            {
                attackedCharacter.Life -= damage;
                this.RefreshScreen?.Invoke(this, EventArgs.Empty);
                return false;
            }
        }

        /// <summary>
        /// Called if a character is dead.
        /// </summary>
        /// <param name="character">The killed character.</param>
        public void Die(Character character)
        {
            if (character is Fortress)
            {
                this.EndGame();
            }
            else if (character is Barricade)
            {
                this.GetBountry(character);

                if (character.Owner == this.model.Player_1)
                {
                    this.model.Player_1.Barricades.Remove(character as Barricade);
                }
                else
                {
                    this.model.Player_2.Barricades.Remove(character as Barricade);
                }
            }
            else if (character is Soldier)
            {
                this.GetBountry(character);
                if (character.Owner == this.model.Player_1)
                {
                    this.model.Player_1.Soldiers.Remove(character as Soldier);
                }
                else
                {
                    this.model.Player_2.Soldiers.Remove(character as Soldier);
                }
            }
            else if (character is Coin)
            {
                this.model.Coins.Remove(character as Coin);
            }

            this.RefreshScreen?.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        /// End the game.
        /// </summary>
        public void EndGame()
        {
            this.FinishedGame?.Invoke(
                this,
                new FinishedGameEventArgs()
                {
                    WinnerName =
                    this.model.Player_1.Fortress.Life == 0 ? this.model.Player_2.Name : this.model.Player_1.Name,
                });
            this.RefreshScreen?.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        /// A soldier get a bonus.
        /// </summary>
        /// <param name="soldier">The soldier who gets the bonus.</param>
        public void GetPotion(Soldier soldier)
        {
            soldier.LVLUp();
        }

        /// <summary>
        /// Load game state.
        /// </summary>
        public Model LoadGameState()
        {
            XmlSerializer xs = new XmlSerializer(typeof(Model));
            using (var sr = new StreamReader("GameState.txt"))
            {
                this.model = (Model)xs.Deserialize(sr);
                sr.Close();
            }

            foreach (Character item in this.model.Player_1.Barricades.Cast<Character>()
                        .Concat(this.model.Player_1.Soldiers.Cast<Character>())
                        .Concat(this.model.Player_2.Barricades.Cast<Character>()
                        .Concat(this.model.Player_2.Soldiers.Cast<Character>())))
            {
                if (item.playerID == "Player1")
                {
                    item.Owner = this.model.Player_1;
                }
                else if (item.playerID == "Player2")
                {
                    item.Owner = this.model.Player_2;
                }
                else
                {
                    throw new Exception();
                }
            }
            return this.model;
        }

        /// <summary>
        /// Move a selector.
        /// </summary>
        /// <param name="player">The owner of the selector.</param>
        /// <param name="dy">Amount of move.</param>
        public void MoveSelector(Player player, int dy)
        {
            if ((player.Selector.Y_Tile + dy) > 0 && (player.Selector.Y_Tile + dy) <= 4)
            {
                player.Selector.Y_Tile += dy;
            }
            else if (player.Selector.IsPutACharacter && (player.Selector.Y_Tile + dy) == 5)
            {
                player.Selector.Y_Tile += dy;
            }

            this.RefreshScreen?.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        /// Selector select.
        /// </summary>
        /// <param name="player">The owner of the selector.</param>
        public void SelectorSelect(Player player)
        {
            if (player.Selector.IsPutACharacter)
            {
                if (player.Selector.Y_Tile != 5)
                {
                    switch (player.Selector.SelectedCharacter)
                    {
                        //////////////////////
                        case Selector.SelectedCharacters.Knight:
                            this.NewCharacter(Characters.Knight, player, player.Selector.Y_Tile);
                            break;
                        case Selector.SelectedCharacters.Rider:
                            this.NewCharacter(Characters.Rider, player, player.Selector.Y_Tile);
                            break;
                        case Selector.SelectedCharacters.Barricade:
                            this.NewCharacter(Characters.Barricade, player, player.Selector.Y_Tile);
                            break;
                        default:
                            break;
                    }
                }

                player.Selector.IsPutACharacter = false;
                player.Selector.SelectedCharacter = Selector.SelectedCharacters.None;
                player.Selector.CX = player.Name == this.model.Player_1.Name ?
                    -(Config.FieldWidht / 2) : (Config.FieldWidht / 2) - (Config.SelectorWidth / 2);
                player.Selector.Y_Tile = 1;
                player.Selector.area =
                    new RectangleGeometry(
                        new System.Windows.Rect(player.Selector.CX, player.Selector.CY, Config.SelectorWidth, Config.SelectorHeight));
            }
            else if (player.Selector.IsUpgrade)
            {
                switch (player.Selector.Y_Tile)
                {
                    case 1:
                        this.UpdateCharacter(Characters.Knight, player);
                        break;
                    case 2:
                        this.UpdateCharacter(Characters.Rider, player);
                        break;
                    case 3:
                        this.UpdateCharacter(Characters.Barricade, player);
                        break;
                    case 4:
                        break;
                    default:
                        break;
                }

                player.Selector.IsUpgrade = false;
            }
            else
            {
                switch (player.Selector.Y_Tile)
                {
                    case 1:
                        player.Selector.IsPutACharacter = true;
                        player.Selector.SelectedCharacter = Selector.SelectedCharacters.Knight;
                        player.Selector.Y_Tile = 1;
                        player.Selector.CX = player.Name == this.model.Player_1.Name ?
                                -(Config.FieldWidht / 4) - Config.CharacterTileWidth : Config.FieldWidht / 4;
                        player.Selector.area = new RectangleGeometry(
                            new Rect(player.Selector.CX, player.Selector.CY, Config.CharacterTileWidth * 2, Config.CharacterTileHeight));
                        break;
                    case 2:
                        player.Selector.IsPutACharacter = true;
                        player.Selector.SelectedCharacter = Selector.SelectedCharacters.Rider;
                        player.Selector.Y_Tile = 1;
                        player.Selector.CX = player.Name == this.model.Player_1.Name ?
                                -(Config.FieldWidht / 4) - Config.CharacterTileWidth : Config.FieldWidht / 4;
                        player.Selector.area = new RectangleGeometry(
                            new Rect(player.Selector.CX, player.Selector.CY, Config.CharacterTileWidth * 2, Config.CharacterTileHeight));
                        break;
                    case 3:
                        player.Selector.IsPutACharacter = true;
                        player.Selector.SelectedCharacter = Selector.SelectedCharacters.Barricade;
                        player.Selector.Y_Tile = 1;
                        player.Selector.CX = player.Name == this.model.Player_1.Name ?
                                -(Config.FieldWidht / 4) - Config.CharacterTileWidth : Config.FieldWidht / 4;
                        player.Selector.area = new RectangleGeometry(
                            new Rect(player.Selector.CX, player.Selector.CY, Config.CharacterTileWidth * 2, Config.CharacterTileHeight));
                        break;
                    case 4:
                        player.Selector.IsUpgrade = true;
                        break;
                    default:
                        break;
                }
            }

            this.RefreshScreen?.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        /// Moving the soldiers and call attack if it needs.
        /// </summary>
        public void MoveSoldier()
        {
            foreach (Soldier soldier in this.model.Player_1.Soldiers.Concat(this.model.Player_2.Soldiers))
            {
                if (soldier.Enemy != null)
                {
                    if (soldier.Enemy is Soldier)
                    {
                        (soldier.Enemy as Soldier).Enemy = soldier;
                    }

                    if (this.Attack(soldier.Enemy, soldier.Power))
                    {
                        if (soldier.Enemy is Coin)
                        {
                            soldier.Owner.Money += soldier.Enemy.Bounty;
                        }

                        soldier.Enemy = null;
                    }
                }
                else
                {
                    soldier.CX = (soldier.CX - (Config.FieldWidht / 2)) +
                        (soldier.Owner == this.model.Player_1 ? soldier.Speed * Config.StepDistance : soldier.Speed * -1 * Config.StepDistance);
                    foreach (Character item in this.OtherPlayer(soldier).Barricades.Cast<Character>()
                        .Concat(this.OtherPlayer(soldier).Soldiers.Cast<Character>())
                        .Concat(this.model.Coins.Cast<Character>()))
                    {
                        if (soldier.IsCollision(item))
                        {
                            soldier.Enemy = item;
                        }
                    }

                    bool e = false;
                    Potion p = null;
                    foreach (Potion item in this.model.Potions)
                    {
                        if (soldier.IsCollision(item))
                        {
                            this.GetPotion(soldier);
                            e = true;
                            p = item;
                        }
                    }

                    if (e)
                    {
                        this.model.Potions.Remove(p);
                        p = null;
                    }

                    if (soldier.IsCollision(this.OtherPlayer(soldier).Fortress))
                    {
                        soldier.Enemy = this.OtherPlayer(soldier).Fortress;
                    }
                }
            }

            this.IncreasePlayersMoney();
            this.PlaceExtras();
            this.RefreshScreen?.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        /// Add new character.
        /// </summary>
        /// <param name="character">Type of the character.</param>
        /// <param name="player">The owner.</param>
        /// <param name="y">The y coord.</param>
        public void NewCharacter(Characters character, Player player, int y)
        {
            if (y < 5 && y > 0)
            {
                switch (character)
                {
                    case Characters.Knight:
                        if (player.Money - player.KnightPrice < 0)
                        {
                            break;
                        }

                        player.Money -= player.KnightPrice;
                        player.Soldiers.Add(
                            new Knight(player)
                            {
                                CX = player.Name == this.model.Player_1.Name ?
                                (-Config.FieldWidht / 2) - Config.CharacterTileWidth : Config.FieldWidht / 2,
                                Y_Tile = y,
                            });
                        break;
                    case Characters.Rider:
                        if (player.Money - player.RiderPrice < 0)
                        {
                            break;
                        }

                        player.Money -= player.RiderPrice;
                        player.Soldiers.Add(
                            new Rider(player)
                            {
                                CX = player.Name == this.model.Player_1.Name ?
                                (-Config.FieldWidht / 2) - Config.CharacterTileWidth : Config.FieldWidht / 2,
                                Y_Tile = y,
                            });
                        break;
                    case Characters.Barricade:
                        if (player.Money - player.BarricadePrice < 0)
                        {
                            break;
                        }

                        if (player.Name == this.model.Player_1.Name)
                        {
                            int tX = -Config.FieldWidht / 2;
                            while (tX < 0 - Config.CharacterTileWidth && this.model.Player_1.Barricades.SingleOrDefault(x => x.CX - (Config.FieldWidht / 2) == tX) != null)
                            {
                                tX += Config.CharacterTileWidth;
                            }

                            if (tX < 0 - Config.CharacterTileWidth)
                            {
                                player.Money -= player.BarricadePrice;
                                player.Barricades.Add(
                                    new Barricade(player)
                                    {
                                        CX = tX,
                                        Y_Tile = y,
                                    });
                            }
                        }
                        else
                        {
                            int tX1 = (Config.FieldWidht / 2) - Config.CharacterTileWidth;
                            while (tX1 > 0 && this.model.Player_2.Barricades.SingleOrDefault(x => x.CX - (Config.FieldWidht / 2) == tX1) != null)
                            {
                                tX1 -= Config.CharacterTileWidth;
                            }

                            if (tX1 > 0)
                            {
                                player.Money -= player.BarricadePrice;
                                player.Barricades.Add(
                                    new Barricade(player)
                                    {
                                        CX = tX1,
                                        Y_Tile = y,
                                    });
                            }
                        }

                        break;
                    default:
                        break;
                }

                this.RefreshScreen?.Invoke(this, EventArgs.Empty);
            }
        }

        /// <summary>
        /// Add new extras.
        /// </summary>
        /// <param name="extra">Type of extra.</param>
        public void NewExtra(Extras extra)
        {
            switch (extra)
            {
                case Extras.Coin:
                    this.model.Coins.Add(new Coin());
                    break;
                case Extras.Potion:
                    this.model.Potions.Add(new Potion());
                    break;
                default:
                    break;
            }

            this.RefreshScreen?.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        /// Save the game state.
        /// </summary>
        public void SaveGameState()
        {
            XmlSerializer xs = new XmlSerializer(typeof(Model));
            TextWriter tw = new StreamWriter("GameState.txt");
            xs.Serialize(tw, this.model);
            tw.Close();
        }

        /// <summary>
        /// Start the game.
        /// </summary>
        public void StartGame()
        {
            this.model.Player_1.Fortress =
                new Fortress(this.model.Player_1, (-Config.FieldWidht / 2) + 75);
            this.model.Player_2.Fortress =
                new Fortress(this.model.Player_2, (Config.FieldWidht / 2) - 75 - (Config.FortressTileWidth / 2));
            this.model.Player_1.Selector =
                new Selector(-(Config.FieldWidht / 2));
            this.model.Player_2.Selector =
                new Selector((Config.FieldWidht / 2) - (Config.SelectorWidth / 2));
            this.RefreshScreen?.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        /// Update a player's character.
        /// </summary>
        /// <param name="character">The updated character.</param>
        /// <param name="player">The owner of the character.</param>
        public void UpdateCharacter(Characters character, Player player)
        {
            if (player.Name == this.model.Player_1.Name)
            {
                switch (character)
                {
                    case Characters.Knight:
                        if (player.Money < Config.KnightUpgradePrice)
                        {
                            break;
                        }

                        player.Money -= Config.KnightUpgradePrice;
                        if (this.model.Player_1.KnightLVL < Config.MaxLVL)
                        {
                            this.model.Player_1.KnightLVL++;
                        }

                        break;
                    case Characters.Rider:
                        if (player.Money < Config.RiderUpgradePrice)
                        {
                            break;
                        }

                        player.Money -= Config.RiderUpgradePrice;
                        if (this.model.Player_1.RiderLVL < Config.MaxLVL)
                        {
                            this.model.Player_1.RiderLVL++;
                        }

                        break;
                    case Characters.Barricade:
                        if (player.Money < Config.BarricadeUpgradePrice)
                        {
                            break;
                        }

                        player.Money -= Config.BarricadeUpgradePrice;

                        if (this.model.Player_1.BarricadeLVL < Config.MaxLVL)
                        {
                            this.model.Player_1.BarricadeLVL++;
                        }

                        break;
                }
            }
            else
            {
                switch (character)
                {
                    case Characters.Knight:
                        if (player.Money < Config.KnightUpgradePrice)
                        {
                            break;
                        }

                        if (this.model.Player_2.KnightLVL < Config.MaxLVL)
                        {
                            this.model.Player_2.KnightLVL++;
                        }

                        break;
                    case Characters.Rider:
                        if (player.Money < Config.RiderUpgradePrice)
                        {
                            break;
                        }

                        if (this.model.Player_2.RiderLVL < Config.MaxLVL)
                        {
                            this.model.Player_2.RiderLVL++;
                        }

                        break;
                    case Characters.Barricade:
                        if (player.Money < Config.BarricadeUpgradePrice)
                        {
                            break;
                        }

                        if (this.model.Player_2.BarricadeLVL < Config.MaxLVL)
                        {
                            this.model.Player_2.BarricadeLVL++;
                        }

                        break;
                }
            }

            this.RefreshScreen?.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        /// Increase players money.
        /// </summary>
        public void IncreasePlayersMoney()
        {
            this.model.Player_1.Money += Config.IncreaseMoney;
            this.model.Player_2.Money += Config.IncreaseMoney;
            this.RefreshScreen?.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        /// Set players name.
        /// </summary>
        /// <param name="player1_name">The first player's name.</param>
        /// <param name="player2_name">The second player's name.</param>
        public void SetPlayersName(string player1_name, string player2_name)
        {
            this.model.Player_1.Name = player1_name;
            this.model.Player_2.Name = player2_name;
        }

        /// <summary>
        /// Place new extra if needed.
        /// </summary>
        public void PlaceExtras()
        {
            if (this.model.Potions.Count == 0)
            {
                this.NewExtra(Extras.Potion);
            }

            if (this.model.Coins.Count == 0)
            {
                this.NewExtra(Extras.Coin);
            }
        }

        private Player OtherPlayer(Soldier soldier)
        {
            return soldier.Owner.Name == this.model.Player_1.Name ? this.model.Player_2 : this.model.Player_1;
        }

        private void GetBountry(Character character)
        {
            if (character.Owner == this.model.Player_1)
            {
                this.model.Player_2.Money += character.Bounty;
            }
            else
            {
                this.model.Player_1.Money += character.Bounty;
            }

            this.RefreshScreen?.Invoke(this, EventArgs.Empty);
        }
    }
}
