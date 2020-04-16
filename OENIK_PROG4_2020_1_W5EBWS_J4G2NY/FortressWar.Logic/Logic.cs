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
            throw new NotImplementedException();
        }

        /// <summary>
        /// A soldier get a bonus.
        /// </summary>
        /// <param name="soldier">The soldier who gets the bonus.</param>
        public void GetBonus(Soldier soldier)
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

                    foreach (Bonus item in this.model.Bonuses)
                    {
                        if (soldier.IsCollision(item))
                        {
                            this.GetBonus(soldier);
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
        /// <param name="optional_x">Optional x coord in the barricade.</param>
        public void NewCharacter(Characters character, Player player, int y, int optional_x = 0)
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
                    player.Barricades.Add(
                        new Barricade(player)
                        {
                            CX = player == this.model.Player_1 ? -Config.FieldWidht / 2 : Config.FieldWidht / 2,
                            Y_Tile = y,
                        });
                    break;
                case Characters.Fortress:
                    player.Fortress =
                        new Fortress(player)
                        {
                            CX = player == this.model.Player_1 ? -Config.FieldWidht / 2 : Config.FieldWidht / 2,
                            CY = 0,
                        };
                    break;
                default:
                    break;
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
                case Extras.Bonus:
                    this.model.Bonuses.Add(new Bonus());
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
            throw new NotImplementedException();
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
