using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Engine.InputManager {
    /// <summary>
    /// Labels are used by displaying text to the screen. 
    /// Labels are not selectable.
    /// </summary>
    public class Label : Control {
        /// <summary>
        /// Constructs the label. 
        /// The label is not selectable.
        /// </summary>
        public Label() {
            TabStop = false;
        }

        public override void Update(GameTime gameTime) { }

        /// <summary>
        /// Draws the control to the screen
        /// </summary>
        /// <param name="spriteBatch">the renderer</param>
        public override void Draw(SpriteBatch spriteBatch) {
            spriteBatch.DrawString(SpriteFont, Text, Position, TextColor);
        }

        public override void HandleInput() { }
    }
}
