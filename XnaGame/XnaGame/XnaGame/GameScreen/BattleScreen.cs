using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

using Engine.InputManager;
using XnaGame.StateManager;
using XnaGame.Character;

namespace XnaGame.GameScreen {
    public class BattleScreen : GameState {
        private List<BattleCharacter> characters;

        /// <summary>
        /// Constructs the BattleScreen and passes Game and GameStateManager
        /// </summary>
        /// <param name="game">the game class</param>
        /// <param name="manager">its assigned GameStateManager</param>
        public BattleScreen(Game game, GameStateManager manager)
            : base(game, manager) {
                characters = new List<BattleCharacter>();
                
        }

        #region XNA Methods

        /// <summary>
        /// Loads the content of the titlescreen
        /// </summary>
        protected override void LoadContent() {
            base.LoadContent();
        }

        public override void Update(GameTime gameTime) {
            if (!HasFocus) return;

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime) {
            GraphicsDevice.Clear(Color.Black);
            GameRef.SpriteBatch.Begin();
            
            base.Draw(gameTime);
            GameRef.SpriteBatch.End();
        }

        #endregion
    }
}
