// <copyright file="Tests.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FortressWar.Logic.Tests
{
    using FortressWar.Model;
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Tests for the logic.
    /// </summary>
    [TestFixture]
    public class Tests
    {
        private Model model;
        private Logic logic;

        /// <summary>
        /// Test setup.
        /// </summary>
        [OneTimeSetUp]
        public void Init()
        {
            this.model = new Model();
            this.logic = new Logic(this.model);
        }

        /// <summary>
        /// Test Attack.
        /// </summary>
        [Test]
        public void TestAttack()
        {
            this.logic.NewCharacter(Characters.Rider, this.model.Player_1, 1);
            int lt = this.model.Player_1.Soldiers.FirstOrDefault().Life;
            for (int i = 0; i < Config.RiderBaseLife - 1; i++)
            {
                this.logic.Attack(this.model.Player_1.Soldiers.FirstOrDefault(), 1);
                Assert.That(this.model.Player_1.Soldiers.FirstOrDefault().Life == --lt);
                Assert.IsNotEmpty(this.model.Player_1.Soldiers);
            }

            Assert.IsTrue(this.logic.Attack(this.model.Player_1.Soldiers.FirstOrDefault(), 1));
            Assert.IsEmpty(this.model.Player_1.Soldiers);

            this.logic.NewCharacter(Characters.Rider, this.model.Player_1, 1);
            this.logic.Attack(this.model.Player_1.Soldiers.FirstOrDefault(), Config.RiderBaseLife + 100);
            Assert.IsEmpty(this.model.Player_1.Soldiers);
        }

        /// <summary>
        /// Test Die.
        /// </summary>
        [Test]
        public void TestDie()
        {
            this.logic.NewCharacter(Characters.Knight, this.model.Player_1, 1);
            Assert.IsNotEmpty(this.model.Player_1.Soldiers);
            int tl = this.model.Player_2.Money;
            int et = this.model.Player_1.Soldiers.FirstOrDefault().Bounty;
            this.logic.Die(this.model.Player_1.Soldiers.FirstOrDefault());
            Assert.IsEmpty(this.model.Player_1.Soldiers);
            Assert.That(this.model.Player_2.Money == tl + et);

            this.logic.NewCharacter(Characters.Barricade, this.model.Player_1, 0);
            Assert.IsNotEmpty(this.model.Player_1.Barricades);
            this.logic.Die(this.model.Player_1.Barricades.LastOrDefault());
            Assert.IsEmpty(this.model.Player_1.Barricades);
        }

        public void TestEndGame()
        {
            throw new NotImplementedException();
        }

        public void TestGetPotion()
        {
            throw new NotImplementedException();
        }

        public void TestLoadGameState()
        {
            throw new NotImplementedException();
        }

        public void TestMoveSelector()
        {
            throw new NotImplementedException();
        }

        [Test]
        public void TestMoveSoldier()
        {
            this.logic.StartGame();
            //Attack, not attack, fortress attack
            this.logic.NewCharacter(Characters.Knight, this.model.Player_1, 1);
            this.logic.NewCharacter(Characters.Knight, this.model.Player_2, 1);
            int z = 0;
            
            this.model.Player_1.Soldiers.FirstOrDefault().CX += 70 * Config.StepDistance *
                this.model.Player_1.Soldiers.FirstOrDefault().Speed;
            this.model.Player_2.Soldiers.FirstOrDefault().CX -= 70 * Config.StepDistance *
                this.model.Player_1.Soldiers.FirstOrDefault().Speed;
               
            while (!this.model.Player_1.Soldiers.FirstOrDefault().IsCollision(
                this.model.Player_2.Soldiers.FirstOrDefault()) && z < 50)
            {
                this.logic.MoveSoldier();
                z++;
            }

            Assert.That(z < 50);
            this.logic.MoveSoldier();
            Assert.That(this.model.Player_1.Soldiers.FirstOrDefault().Life < Config.KnightBaseLife ||
                this.model.Player_2.Soldiers.FirstOrDefault().Life < Config.KnightBaseLife);
        }

        [Test]
        public void TestIsCollision()
        {
            this.logic.NewCharacter(Characters.Knight, this.model.Player_1, 1);
            this.model.Player_1.Soldiers.FirstOrDefault().CX = 0;
            this.logic.NewCharacter(Characters.Knight, this.model.Player_2, 1);
            this.model.Player_2.Soldiers.FirstOrDefault().CX = 0;

            Assert.That(this.model.Player_1.Soldiers.FirstOrDefault().IsCollision(
                this.model.Player_2.Soldiers.FirstOrDefault()));

            this.model.Player_2.Soldiers.FirstOrDefault().CX = 10;

            Assert.That(this.model.Player_1.Soldiers.FirstOrDefault().IsCollision(
                this.model.Player_2.Soldiers.FirstOrDefault()));
        }

        /// <summary>
        /// Test new character.
        /// </summary>
        [Test]
        public void TestNewCharacter()
        {
            this.logic.NewCharacter(Characters.Knight, this.model.Player_1, 6);
            Assert.IsEmpty(this.model.Player_1.Soldiers);
            this.logic.NewCharacter(Characters.Knight, this.model.Player_1, 4);
            Assert.IsNotEmpty(this.model.Player_1.Soldiers);
            Assert.That(this.model.Player_1.Soldiers.FirstOrDefault().LVL ==
                this.model.Player_1.KnightLVL);
            Assert.IsNull(this.model.Player_1.Soldiers.FirstOrDefault().Enemy);

            this.logic.NewCharacter(Characters.Rider, this.model.Player_1, 3);
            Assert.That(this.model.Player_1.Soldiers.Count == 2);

            this.logic.NewCharacter(Characters.Barricade, this.model.Player_1, 0);
            Assert.IsNotNull(this.model.Player_1.Barricades.FirstOrDefault());
            double tx = this.model.Player_1.Barricades.LastOrDefault().CX;
            this.logic.NewCharacter(Characters.Barricade, this.model.Player_1, 0);
            Assert.That(this.model.Player_1.Barricades.LastOrDefault().CX != tx);
            Assert.That(this.model.Player_1.Barricades.LastOrDefault().CX ==
                tx + Config.CharacterTileWidth);

            for (int i = 0; i < 10; i++)
            {
                this.logic.NewCharacter(Characters.Barricade, this.model.Player_1, 0);
                Assert.That(this.model.Player_1.Barricades.LastOrDefault().CX < Config.FieldWidht / 2);
                tx = this.model.Player_1.Barricades.LastOrDefault().CX;
            }
        }

        /// <summary>
        /// Test new extra.
        /// </summary>
        [Test]
        public void TestNewExtra()
        {
            this.logic.NewExtra(Extras.Coin);

            Assert.IsNotEmpty(this.model.Coins);
            Assert.That(this.model.Coins.FirstOrDefault().Bounty != 0);
            Assert.That(this.model.Coins.FirstOrDefault().Life == 1);

            this.logic.NewExtra(Extras.Potion);
            Assert.IsNotEmpty(this.model.Potions);
        }

        public void TestSaveGameState()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Test start game.
        /// </summary>
        [Test]
        public void TestStartGame()
        {
            this.logic.StartGame();
            Assert.NotNull(this.model.Player_1.Fortress);
            Assert.NotNull(this.model.Player_2.Fortress);

            Assert.That(this.model.Player_1.Fortress.CX == -Config.FieldWidht / 2);
            Assert.That(this.model.Player_1.Fortress.Owner == this.model.Player_1);
            Assert.That(this.model.Player_1.Fortress.Life == Config.FortressBaseLife);
        }

        /// <summary>
        /// Test update character.
        /// </summary>
        [Test]
        public void TestUpdateCharacter()
        {
            Assert.That(this.model.Player_1.BarricadeLVL == 0);
            int lt = 0;
            for (int i = 0; i < Config.MaxLVL; i++)
            {
                this.logic.UpdateCharacter(Characters.Barricade, this.model.Player_1);
                Assert.That(this.model.Player_1.BarricadeLVL == ++lt);
            }

            this.logic.UpdateCharacter(Characters.Barricade, this.model.Player_1);
            Assert.That(this.model.Player_1.BarricadeLVL == lt);
        }
    }
}
