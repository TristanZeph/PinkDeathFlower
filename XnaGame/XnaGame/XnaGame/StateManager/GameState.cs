using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Engine.InputManager;

namespace XnaGame.StateManager {
    public class GameState : DrawableGameComponent {
        /// <summary>
        /// Provide a gameState reference of self
        /// </summary>
        private GameState stateRef;

        /// <summary>
        /// Reference of its assigned GameStateManager
        /// </summary>
        protected GameStateManager StateMananger;

        /// <summary>
        /// Controls assigned to this GameState
        /// </summary>
        protected ControlManager ControlManager;

        /// <summary>
        /// Reference of its assigned game1.
        /// Use of Content and spritebatch
        /// </summary>
        protected Game1 GameRef;

        /// <summary>
        /// Determines if the screen currently has focus.
        /// Update the inputs if screen has focus.
        /// </summary>
        private bool hasFocus;

        /// <summary>
        /// Get state reference of self
        /// </summary>
        public GameState StateRef {
            get { return stateRef; }
        }

        /// <summary>
        /// get set hasfocus
        /// </summary>
        public bool HasFocus {
            get { return hasFocus; }
            set { hasFocus = value; }
        }

        /// <summary>
        /// Constructs the gameState and passes Game and GameStateManager.
        /// </summary>
        /// <param name="game">game drawable component</param>
        /// <param name="manager">the stateManager</param>
        public GameState(Game game, GameStateManager manager)
            : base(game) {
                GameRef = (Game1)game;
                StateMananger = manager;
                stateRef = this;
        }

        /// <summary>
        /// Loads the menuFont for the Controls.
        /// Initialises ControlManager
        /// </summary>
        protected override void LoadContent() {
            ContentManager Content = Game.Content;

            SpriteFont menuFont = Content.Load<SpriteFont>(@"Fonts\ControlFont");
            ControlManager = new ControlManager(menuFont);

            base.LoadContent();
        }
        /// <summary>
        /// Update itself
        /// </summary>
        /// <param name="gameTime">snapshot of the time</param>
        public override void Update(GameTime gameTime) {
            base.Update(gameTime);
        }

        /// <summary>
        /// Draw itself
        /// </summary>
        /// <param name="gameTime">snapshot of the time</param>
        public override void Draw(GameTime gameTime) {
            base.Draw(gameTime);
        }
    }
}
