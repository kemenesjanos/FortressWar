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

        /// <summary>
        /// Initializes a new instance of the <see cref="Logic"/> class.
        /// Ctor.
        /// </summary>
        /// <param name="model">A model instance.</param>
        public Logic(Model model)
        {
            this.model = model;
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
                return true;
            }
            else
            {
                attackedCharacter.Life -= damage;
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
        }

        public void EndGame()
        {
            
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

        public void MoveSelector(int x, int y)
        {
            //TODO: lenyomott gombok meghatározása és feltételek közé helyezése!
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
                    soldier.CX += soldier.Owner == this.model.Player_1 ? soldier.Speed * Config.StepDistance : -soldier.Speed * Config.StepDistance;
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
            if (y < 5 && y >= 0)
            {
                switch (character)
                {
                    case Characters.Knight:
                        player.Soldiers.Add(
                            new Knight(player)
                            {
                                CX = player == this.model.Player_1 ? -Config.FieldWidht / 2 : Config.FieldWidht / 2,
                                Y_Tile = y,
                            });
                        break;
                    case Characters.Rider:
                        player.Soldiers.Add(
                            new Rider(player)
                            {
                                CX = player == this.model.Player_1 ? -Config.FieldWidht / 2 : Config.FieldWidht / 2,
                                Y_Tile = y,
                            });
                        break;
                    case Characters.Barricade:
                        if (player == this.model.Player_1)
                        {
                            int tX = 0;
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
                            int tX1 = Config.FieldWidht;
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
        }

        public void SaveGameState()
        {
            throw new NotImplementedException();
        }

        public void StartGame()
        {
            this.model.Player_1.Fortress =
                new Fortress(this.model.Player_1)
                {
                    CX = -Config.FieldWidht / 2,
                    CY = 0,
                };
            this.model.Player_2.Fortress =
                new Fortress(this.model.Player_2)
                {
                    CX = Config.FieldWidht / 2,
                    CY = 0,
                };
        }

        public void UpdateCharacter(Characters character, Player player)
        {

        }

        private Player OtherPlayer(Soldier soldier)
        {
            return soldier.Owner == this.model.Player_1 ? this.model.Player_2 : this.model.Player_1;
        }
    }
}
