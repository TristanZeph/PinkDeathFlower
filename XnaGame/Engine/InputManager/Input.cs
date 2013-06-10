using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Engine.InputManager {
    /// <summary>
    /// Handles the input of the controller
    /// </summary>
    public class Input : GameComponent {
        private static KeyboardState previousKeys, currentKeys;

        // default key bindings
        public readonly static Keys ExitKey     = Keys.Escape;      // TODO: REMOVE FROM PROGRAM WHEN DONE
        public readonly static Keys ConfirmKey  = Keys.Enter;
        public readonly static Keys CancelKey   = Keys.Back;
        public readonly static Keys MenuKey     = Keys.Space;
        public readonly static Keys UpKey       = Keys.W;
        public readonly static Keys DownKey     = Keys.S;
        public readonly static Keys LeftKey     = Keys.A;
        public readonly static Keys RightKey    = Keys.D;

        /// <summary>
        /// Initialises the previousKeys and currentKeys
        /// </summary>
        public Input(Game game)
            : base(game) {
            previousKeys = Keyboard.GetState();
            currentKeys = Keyboard.GetState();
        }

        /// <summary>
        /// Updates the keyboard states
        /// </summary>
        /// <param name="gameTime">snapshot of current time</param>
        public override void Update(GameTime gameTime) {
            previousKeys = currentKeys;
            currentKeys = Keyboard.GetState();
            
            base.Update(gameTime);
        }

        /// <summary>
        /// Make previousKeys equal to currentKeys to avoid conflict 
        /// when transitioning to a different screen.
        /// </summary>
        public static void ResetKeys() {
            previousKeys = currentKeys;
        }

        /// <summary>
        /// Returns true or false if the key is held down.
        /// </summary>
        /// <param name="k">the key</param>
        /// <returns>
        /// true if key is pressed.
        /// Otherwise, false.
        /// </returns>
        public static bool IsKeyDown(Keys k) {
            return currentKeys.IsKeyDown(k);
        }

        /// <summary>
        /// Checks for key released from pressed state.
        /// Registers for single presses.
        /// </summary>
        /// <param name="k">the key</param>
        /// <returns>
        /// true if key is NOT pressed.
        /// Otherwise, false
        /// </returns>
        public static bool IsKeyReleased(Keys k) {
            return previousKeys.IsKeyUp(k) && currentKeys.IsKeyDown(k);
        }

        /// <summary>
        /// Checks for key pressed from released state.
        /// Registers only single presses.
        /// </summary>
        /// <param name="k">the key</param>
        /// <returns>
        /// true if the key is pressed,
        /// otherwise false.
        /// </returns>
        public static bool IsKeyPressed(Keys k) {
            return previousKeys.IsKeyDown(k) && currentKeys.IsKeyUp(k);
        }
    }
}
