using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;

using XnaGame.StateManager;
using Engine.InputManager;

namespace XnaGame.GameScreen {
    /// <summary>
    /// The titlescreen
    /// </summary>
    public class TitleScreen : GameState {
        Texture2D backgroundImage;
        Button startButton;

        /// <summary>
        /// Constructs the TitleScreen and passes Game and GameStateManager
        /// </summary>
        /// <param name="game">the game class</param>
        /// <param name="manager">its assigned GameStateManager</param>
        public TitleScreen(Game game, GameStateManager manager)
            : base(game, manager) {
        }

        /// <summary>
        /// Loads the content of the titlescreen
        /// </summary>
        protected override void LoadContent() {
            ContentManager Content = GameRef.Content;
            backgroundImage = Content.Load<Texture2D>("titlescreen");

            // loads spriteFont
            base.LoadContent();

            //creates startbutton
            startButton = new Button();
            startButton.Position = new Vector2(350, 600);
            startButton.Text = "Test Battle System";
            startButton.TabStop = true;
            startButton.HasFocus = true;
            startButton.Selected += new EventHandler(startButton_Selected);

            ControlManager.Add(startButton);
        }

        /// <summary>
        /// Updates the titlescreen
        /// </summary>
        /// <param name="gameTime">snapshot of the current time</param>
        public override void Update(GameTime gameTime) {
            // exits the game when exitKey released
            if (Input.IsKeyReleased(Input.ExitKey)) {
                GameRef.Exit();
            }

            ControlManager.Update(gameTime);
            base.Update(gameTime);
        }

        /// <summary>
        /// Draws the contents in titleScreen
        /// </summary>
        /// <param name="gameTime">snapshot of current time</param>
        public override void Draw(GameTime gameTime) {
            GameRef.SpriteBatch.Begin();
            
            base.Draw(gameTime);

            //draw background
            GameRef.SpriteBatch.Draw(
                backgroundImage,
                GameRef.ScreenRectangle,
                Color.White);

            ControlManager.Draw(GameRef.SpriteBatch);

            GameRef.SpriteBatch.End();
        }

        /// <summary>
        /// Pushes battle screen to the stack
        /// </summary>
        private void startButton_Selected(object sender, EventArgs e) {
            StateMananger.PushState(GameRef.BattleScreen);
        }
    }
}
