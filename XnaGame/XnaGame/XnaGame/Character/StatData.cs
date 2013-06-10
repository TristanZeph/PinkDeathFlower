using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XnaGame.Character {
    public class StatData {
        public CurrentMaxValue Health;
        public CurrentMaxValue Stamina;
        public int Speed;

        public StatData() {
            Health = new CurrentMaxValue(10);
            Stamina = new CurrentMaxValue(100);
            Speed = 1;
        }
    }
}
