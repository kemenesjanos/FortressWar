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
                this.model.Barricades.Remove(character as Barricade);
                this.GetBountry(character);
            }
            else if (character is Soldier)
            {
                this.model.Soldiers.Remove(character as Soldier);
                this.GetBountry(character);
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

        public void GetBonus(Soldier soldier)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Add random money to a player.
        /// </summary>
        /// <param name="player">The player who gets the money.</param>
        /// <param name="money">The money the character get.</param>
        public void GetCoin(Players player, Coin money)
        {
            if (player == Players.Player1)
            {
                this.model.Player_1.Money += money.Value;
            }
            else
            {
                this.model.Player_2.Money += money.Value;
            }
        }

        public void LoadGameState()
        {
            throw new NotImplementedException();
        }

        public void MoveSelector(int y)
        {
            throw new NotImplementedException();
        }

        public void MoveSoldier(Soldier soldier)
        {
            throw new NotImplementedException();
        }

        public void NewCharacter(Characters character, Players player, int y)
        {
            throw new NotImplementedException();
        }

        public void SaveGameState()
        {
            throw new NotImplementedException();
        }

        public void StartGame()
        {
            throw new NotImplementedException();
        }

        public void UpdateCharacter(Characters character, Players players)
        {
            throw new NotImplementedException();
        }
    }
}
