using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Engine.InputManager {
    /// <summary>
    /// Manages a List of controls 
    /// </summary>
    public class ControlManager : List<Control> {
        /// <summary>
        /// The currently selected control
        /// </summary>
        int selectedControl = 0;
        /// <summary>
        /// The SpriteFont to render text
        /// </summary>
        static SpriteFont spriteFont;

        /// <summary>
        /// Accessor for spriteFont
        /// </summary>
        public static SpriteFont SpriteFont {
            get { return spriteFont; }
        }

        /// <summary>
        /// Passes spriteFont to the controlManager
        /// </summary>
        /// <param name="spriteFont">the font for text</param>
        public ControlManager(SpriteFont spriteFont)
            : base() {
                ControlManager.spriteFont = spriteFont;
        }

        /// <summary>
        /// Passes spriteFont and capacity of controls
        /// </summary>
        /// <param name="spriteFont">the font for text</param>
        /// <param name="capacity">capacity of controls</param>
        public ControlManager(SpriteFont spriteFont, int capacity) 
            : base(capacity) {
                ControlManager.spriteFont = spriteFont;
        }

        /// <summary>
        /// Passes spriteFont and control collection to manager
        /// </summary>
        /// <param name="spriteFont">the font for text</param>
        /// <param name="collection">a collection of controls</param>
        public ControlManager(SpriteFont spriteFont, IEnumerable<Control> collection)
            : base(collection) {
                ControlManager.spriteFont = spriteFont;
        }

        /// <summary>
        /// Update the control if it is enabled.
        /// Go to previous or next control if UP or DOWN keys pressed
        /// </summary>
        /// <param name="gameTime">snapshot of current time</param>
        public void Update(GameTime gameTime) {
            if (Count == 0) return;

            // update the control and handle the input
            foreach (Control c in this) {
                if (c.Enabled)
                    c.Update(gameTime);

                if (c.HasFocus)
                    c.HandleInput();
            }

            // UP key calls PreviousContol(), DOWN key calls NextControl()
            if (Input.IsKeyReleased(Input.UpKey))
                PreviousControl();
            if (Input.IsKeyReleased(Input.DownKey))
                NextControl();
        }

        /// <summary>
        /// Draw all visible controls
        /// </summary>
        /// <param name="spriteBatch">the renderer</param>
        public void Draw(SpriteBatch spriteBatch) {
            foreach (Control c in this) {
                if (c.Visible)
                    c.Draw(spriteBatch);
            }
        }

        /// <summary>
        /// Iterates through the next control in the list.
        /// i++
        /// </summary>
        public void NextControl() {
            if (Count == 0) return;

            // make current control not have focus
            int currentControl = selectedControl;
            this[selectedControl].HasFocus = false;

            do { 
                selectedControl++;
                if (selectedControl == Count)
                    selectedControl = 0;

                if (this[selectedControl].TabStop && this[selectedControl].Enabled)
                    break;

            } while (currentControl != selectedControl);

            this[selectedControl].HasFocus = true;
        }

        /// <summary>
        /// Iterates through the previous control in the list.
        /// i--
        /// </summary>
        public void PreviousControl() {
            if (Count == 0) return;

            // make current control not have focus
            int currentControl = selectedControl;
            this[selectedControl].HasFocus = false;

            do {
                selectedControl--;
                if (selectedControl < 0)
                    selectedControl = Count - 1;

                if (this[selectedControl].TabStop && this[selectedControl].Enabled)
                    break;

            } while (currentControl != selectedControl);

            this[selectedControl].HasFocus = true;
        }
    }
}
