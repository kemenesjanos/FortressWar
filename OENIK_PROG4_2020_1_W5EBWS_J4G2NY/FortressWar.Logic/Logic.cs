// <copyright file="Logic.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
namespace FortressWar.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Media;
    using FortressWar.Model;

    /// <summary>
    /// Logic.
    /// </summary>
    public class Logic : ILogic
    {
        /// <summary>
        /// The model.
        /// </summary>
        private Model model;
        private Random rnd = new Random();

        public event EventHandler RefreshScreen;

        /// <summary>
        /// Initializes a new instance of the <see cref="Logic"/> class.
        /// Ctor.
        /// </summary>
        /// <param name="model">A model instance.</param>
        public Logic(Model model)
        {
            this.model = model;
            StartGame();
            NewCharacter(Characters.Rider, model.Player_1,1);
            NewCharacter(Characters.Barricade, model.Player_1, 1);
            NewCharacter(Characters.Barricade, model.Player_1, 1);
            NewCharacter(Characters.Knight, model.Player_1, 2);
            NewCharacter(Characters.Rider, model.Player_1, 3);
            NewCharacter(Characters.Rider, model.Player_1, 4);
            NewCharacter(Characters.Rider, model.Player_2, 1);
            NewCharacter(Characters.Knight, model.Player_2, 2);
            NewCharacter(Characters.Rider, model.Player_2, 3);
            NewCharacter(Characters.Rider, model.Player_2, 4);
        }

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
                this.Die(attackedCharacter);
                RefreshScreen?.Invoke(this, EventArgs.Empty);
                return true;
            }
            else
            {
                attackedCharacter.Life -= damage;
                RefreshScreen?.Invoke(this, EventArgs.Empty);
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
                this.GetBountry(character);
                this.model.Coins.Remove(character as Coin);
            }
            RefreshScreen?.Invoke(this, EventArgs.Empty);
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
            RefreshScreen?.Invoke(this, EventArgs.Empty);
        }

        public void EndGame()
        {
            RefreshScreen?.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        /// A soldier get a bonus.
        /// </summary>
        /// <param name="soldier">The soldier who gets the bonus.</param>
        public void GetPotion(Soldier soldier)
        {
            soldier.LVLUp();
        }

        public void LoadGameState()
        {
            throw new NotImplementedException();
        }

        public void MoveSelector(Player player, int dy)
        {
            if ((this.model.Selector.Y_Tile + dy) >= 0 && (this.model.Selector.Y_Tile + dy) <= 4)
            {
                this.model.Selector.Y_Tile += dy;
            }

            RefreshScreen?.Invoke(this, EventArgs.Empty);
            //TODO: lenyomott gombok meghatározása és feltételek közé helyezése!
            //TODO: egy segéd metódus a választás kezeléséhez
        }

        public void SelectorSelect(Player player)
        {
            if (player.Selector.IsPutACharacter)
            {
                if (player.Selector.Y_Tile != 0)
                {
                    switch (player.Selector.SelectedCharacter)
                    {
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

                player.Selector.SelectedCharacter = Selector.SelectedCharacters.None;
                player.Selector.CX = player == this.model.Player_1 ?
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
                        player.Selector.IsUpgrade = false;
                        break;
                    default:
                        break;
                };
            }
            else
            {
                switch (player.Selector.Y_Tile)
                {
                    case 1:
                        player.Selector.SelectedCharacter = Selector.SelectedCharacters.Knight;
                        player.Selector.CX = player == this.model.Player_1 ?
                                (-Config.FieldWidht / 2) - Config.CharacterTileWidth : Config.FieldWidht / 2;
                        player.Selector.area =new RectangleGeometry(
                            new Rect(player.Selector.CX, player.Selector.CY, Config.CharacterTileWidth, Config.CharacterTileHeight));
                        break;
                    case 2:
                        player.Selector.SelectedCharacter = Selector.SelectedCharacters.Rider;
                        player.Selector.CX = player == this.model.Player_1 ?
                                (-Config.FieldWidht / 2) - Config.CharacterTileWidth : Config.FieldWidht / 2;
                        player.Selector.area = new RectangleGeometry(
                            new Rect(player.Selector.CX, player.Selector.CY, Config.CharacterTileWidth, Config.CharacterTileHeight));
                        break;
                    case 3:
                        player.Selector.SelectedCharacter = Selector.SelectedCharacters.Barricade;
                        player.Selector.CX = player == this.model.Player_1 ?
                                (-Config.FieldWidht / 2) - Config.CharacterTileWidth : Config.FieldWidht / 2;
                        player.Selector.area = new RectangleGeometry(
                            new Rect(player.Selector.CX, player.Selector.CY, Config.CharacterTileWidth, Config.CharacterTileHeight));
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

                    foreach (Potion item in this.model.Potions)
                    {
                        if (soldier.IsCollision(item))
                        {
                            this.GetPotion(soldier);
                            this.model.Potions.Remove(item);
                        }
                    }

                    if (soldier.IsCollision(this.OtherPlayer(soldier).Fortress))
                    {
                        soldier.Enemy = this.OtherPlayer(soldier).Fortress;
                    }
                }
            }
            RefreshScreen?.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        /// Add new character.
        /// </summary>
        /// <param name="character">Type of the character.</param>
        /// <param name="player">The owner.</param>
        /// <param name="y">The y coord.</param>
        public void NewCharacter(Characters character, Player player, int y)
        {
            // TODO: Fizetések
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
                                CX = player == this.model.Player_1 ?
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
                                CX = player == this.model.Player_1 ?
                                (-Config.FieldWidht / 2) - Config.CharacterTileWidth : Config.FieldWidht / 2,
                                Y_Tile = y,
                            });
                        break;
                    case Characters.Barricade:
                        if (player.Money - player.BarricadePrice < 0)
                        {
                            break;
                        }

                        player.Money -= player.BarricadePrice;
                        if (player == this.model.Player_1)
                        {
                            int tX = Config.CharacterTileWidth - Config.CharacterTileWidth;
                            while (tX < Config.FieldWidht / 2 && this.model.Player_1.Barricades.FirstOrDefault(x => x.CX == tX) != null)
                            {
                                tX += Config.CharacterTileWidth;
                            }

                            if (tX < Config.FieldWidht / 2)
                            {
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
                            int tX1 = Config.FieldWidht-Config.CharacterTileWidth;
                            while (tX1 > Config.FieldWidht / 2 && this.model.Player_2.Barricades.FirstOrDefault(x => x.CX == tX1) != null)
                            {
                                tX1 -= Config.CharacterTileWidth;
                            }

                            if (tX1 > Config.FieldWidht / 2)
                            {
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
                RefreshScreen?.Invoke(this, EventArgs.Empty);
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
            RefreshScreen?.Invoke(this, EventArgs.Empty);
        }

        public void SaveGameState()
        {
            throw new NotImplementedException();
        }

        public void StartGame()
        {
            this.model.Player_1.Fortress =
                new Fortress(this.model.Player_1, -Config.FieldWidht / 2);
            this.model.Player_2.Fortress =
                new Fortress(this.model.Player_2, Config.FieldWidht / 2);
            this.model.Player_1.Selector =
                new Selector(-(Config.FieldWidht / 2));
            this.model.Player_2.Selector =
                new Selector((Config.FieldWidht / 2) - (Config.SelectorWidth / 2));
            RefreshScreen?.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        /// Update a player's character.
        /// </summary>
        /// <param name="character">The updated character.</param>
        /// <param name="player">The owner of the character.</param>
        public void UpdateCharacter(Characters character, Player player)
        {
            if (player == this.model.Player_1)
            {
                switch (character)
                {
                    case Characters.Knight:
                        if (player.Money < Config.KnightUpgradePrice)
                        {
                            break;
                        }

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
            RefreshScreen?.Invoke(this, EventArgs.Empty);
        }

        private Player OtherPlayer(Soldier soldier)
        {
            return soldier.Owner == this.model.Player_1 ? this.model.Player_2 : this.model.Player_1;
        }
    }
}
