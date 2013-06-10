using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace XnaGame.Character {
    public class BattleCharacter : BaseCharacter {
        public readonly StatData StatData;
        public readonly bool IsEnemy;

        public BattleCharacter() {
            StatData = new StatData();
            IsEnemy = false;
        }

        public BattleCharacter(bool isEnemy) {
            StatData = new StatData();
            IsEnemy = isEnemy;
        }

        public override void Update(GameTime gameTime) {
        }

        public override void Draw(SpriteBatch spriteBatch) {
            base.Draw(spriteBatch);
        }
    }
}
