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

        public Logic(Model model)
        {
            this.model = model;
        }

        public bool Attack(Character attackedCharacter, int damage)
        {
            if (attackedCharacter.Life - damage <= 0)
            {
                attackedCharacter.Dead();
                return true;
            }
            else
            {
                attackedCharacter.Life -= damage;
                return false;
            }
        }

        public void Die(Character character)
        {
            throw new NotImplementedException();
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
