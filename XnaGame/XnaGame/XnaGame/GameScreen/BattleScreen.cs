using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

using XnaGame.StateManager;
using Engine.InputManager;

namespace XnaGame.GameScreen {
    public class BattleScreen : GameState {
        Texture2D backgroundImage;

        /// <summary>
        /// Constructs the TitleScreen and passes Game and GameStateManager
        /// </summary>
        /// <param name="game">the game class</param>
        /// <param name="manager">its assigned GameStateManager</param>
        public BattleScreen(Game game, GameStateManager manager)
            : base(game, manager) {
        }

        /// <summary>
        /// Loads the content of the titlescreen
        /// </summary>
        protected override void LoadContent() {
            ContentManager Content = GameRef.Content;
            backgroundImage = Content.Load<Texture2D>("screen1");
            
            base.LoadContent();
        }

        public override void Update(GameTime gameTime) {
            // we are finished, pop battleScreen state off stack
            if (Input.IsKeyReleased(Input.CancelKey)) {
                StateMananger.PopState();       
            }

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime) {
            GameRef.SpriteBatch.Begin();
            
            base.Draw(gameTime);

            GameRef.SpriteBatch.Draw(
                backgroundImage,
                GameRef.ScreenRectangle,
                Color.White);

            GameRef.SpriteBatch.End();
        }
    }
}
