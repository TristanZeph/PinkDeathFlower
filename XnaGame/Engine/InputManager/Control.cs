using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Engine.InputManager {
    public abstract class Control {
        /// <summary>
        /// Name of the control
        /// </summary>
        protected string name;
        /// <summary>
        /// Text to be displayed on the control
        /// </summary>
        protected string text;
        /// <summary>
        /// The start position to draw the control
        /// </summary>
        protected Vector2 position;
        /// <summary>
        /// The size to draw the control
        /// </summary>
        protected Vector2 size;
        /// <summary>
        /// Whether the control currently has focus
        /// </summary>
        protected bool hasFocus;
        /// <summary>
        /// Whether the control is enabled
        /// </summary>
        protected bool enabled;
        /// <summary>
        /// Whether the control is visible
        /// </summary>
        protected bool visible;
        /// <summary>
        /// Whether the control is selectable
        /// </summary>
        protected bool tabStop;
        /// <summary>
        /// The SpriteFont text to draw
        /// </summary>
        protected SpriteFont spriteFont;
        /// <summary>
        /// The color of the text
        /// </summary>
        protected Color textColor;
        /// <summary>
        /// Fires the event when the control is selected
        /// </summary>
        public event EventHandler Selected;

        #region Properties

        public string Name {
            get { return name; }
            set { name = value; }
        }
        public string Text {
            get { return text; }
            set { text = value; }
        }
        public Vector2 Size {
            get { return size; }
            set { size = value; }
        }
        public Vector2 Position {
            get { return position; }
            set {
                position = value;
                position.Y = (int)position.Y;
            }
        }
        public bool HasFocus {
            get { return hasFocus; }
            set { hasFocus = value; }
        }
        public bool Enabled {
            get { return enabled; }
            set { enabled = value; }
        }
        public bool Visible {
            get { return visible; }
            set { visible = value; }
        }
        public bool TabStop {
            get { return tabStop; }
            set { tabStop = value; }
        }
        public SpriteFont SpriteFont {
            get { return spriteFont; }
            set { spriteFont = value; }
        }
        public Color TextColor {
            get { return textColor; }
            set { textColor = value; }
        }

        #endregion

        /// <summary>
        /// Constructs the control. 
        /// Sets TextColor = White and  
        /// Enabled and Visible = true.
        /// </summary>
        public Control() {
            TextColor = Color.White;
            Enabled = true;
            Visible = true;
            SpriteFont = ControlManager.SpriteFont;
        }

        /// <summary>
        /// Updates the control
        /// </summary>
        /// <param name="gameTime">snapshot of the current time</param>
        public abstract void Update(GameTime gameTime);

        /// <summary>
        /// Draws the control
        /// </summary>
        /// <param name="spriteBatch">spriteBatch to render control</param>
        public abstract void Draw(SpriteBatch spriteBatch);

        /// <summary>
        /// Handles the input of the control
        /// </summary>
        public abstract void HandleInput();

        /// <summary>
        /// Fire the event if the control is selected
        /// </summary>
        /// <param name="e">the event data</param>
        protected virtual void OnSelected(EventArgs e) {
            if (Selected != null) {
                Selected(this, e);
            }
        }


    }
}
