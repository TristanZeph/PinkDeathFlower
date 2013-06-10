using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace XnaGame.Character {
    public abstract class BaseCharacter {
        private Vector2 position;
        private Texture2D image;
        private string name;

        public BaseCharacter() {
            position = Vector2.Zero;
            name = "MissingName";
        }

        public BaseCharacter(Texture2D image, Vector2 position) {
            this.image = image;
            this.position = position;
        }

        public abstract void Update(GameTime gameTime);

        public virtual void Draw(SpriteBatch spriteBatch) {
            if (image != null) {
                Rectangle rect = new Rectangle((int)position.X, (int)position.Y, image.Width, image.Height);
                spriteBatch.Draw(image, rect, Color.White);
            }
        }
    }
}
