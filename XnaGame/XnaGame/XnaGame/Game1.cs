using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

using XnaGame.GameScreen;
using XnaGame.StateManager;

using Engine.InputManager;

namespace XnaGame {
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game {
        private GraphicsDeviceManager graphics;
        private GameStateManager stateManager;

        // screen resolution
        private const int WIDTH = 800;
        private const int HEIGHT = 600;

        public SpriteBatch SpriteBatch;
        public readonly Rectangle ScreenRectangle;

        // screens in the game
        public TitleScreen TitleScreen;
        public BattleScreen BattleScreen;

        /// <summary>
        /// Initlialise the game!
        /// </summary>
        public Game1() {
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = WIDTH;
            graphics.PreferredBackBufferHeight = HEIGHT;

            ScreenRectangle = new Rectangle(0, 0, WIDTH, HEIGHT);

            Components.Add(new Input(this));

            stateManager = new GameStateManager(this);
            Components.Add(stateManager);

            // default starting screen
            TitleScreen = new TitleScreen(this, stateManager);
            BattleScreen = new BattleScreen(this, stateManager);

            stateManager.ChangeState(TitleScreen);
        }

        #region XNA Methods

        protected override void Initialize() {
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent() {
            // Create a new SpriteBatch, which can be used to draw textures.
            SpriteBatch = new SpriteBatch(GraphicsDevice);
        }

        protected override void UnloadContent() {
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime) {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime) {
            GraphicsDevice.Clear(Color.Black);

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }

        #endregion
    }
}
