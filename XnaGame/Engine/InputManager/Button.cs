using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Engine.InputManager {
    /// <summary>
    /// Buttons are used to fire events in the control. 
    /// Used to transition to different menus and transition 
    /// different screens.
    /// </summary>
    public class Button : Control {
        /// <summary>
        /// Color to render the selected text
        /// </summary>
        Color selectedColor = Color.Red;
        /// <summary>
        /// Accessor to change and get the selectedColor
        /// </summary>
        public Color SelectedColor {
            get { return selectedColor; }
            set { selectedColor = value; }
        }

        /// <summary>
        /// Constructs the button.
        /// </summary>
        public Button() {
            TabStop = true;
            HasFocus = false;
            Position = Vector2.Zero;
        }

        public override void Update(GameTime gameTime) { }

        /// <summary>
        /// Draws the spriteBatch. If the control is selected, 
        /// selectedColor will be the color to render. 
        /// </summary>
        /// <param name="spriteBatch">the renderer</param>
        public override void Draw(SpriteBatch spriteBatch) {
            if (HasFocus) {
                spriteBatch.DrawString(SpriteFont, Text, Position, selectedColor);
            } else {
                spriteBatch.DrawString(SpriteFont, Text, Position, TextColor);
            }
        }

        /// <summary>
        /// Fire the event if the control is selected
        /// </summary>
        public override void HandleInput() {
            if (!HasFocus) return;

            if (Input.IsKeyReleased(Input.ConfirmKey)) {
                base.OnSelected(null);
            }
        }
    }
}
