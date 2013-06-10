using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XnaGame.Character {
    /// <summary>
    /// Class that contains two values, currentValue and maximumValue.
    /// This is used to indicate a character stat with varying currentValue.
    /// currentValue will never exceed maximumValue.
    /// 
    /// Example uses, HealthPoints, ManaPoints, 10/30, etc.
    /// </summary>
    public class CurrentMaxValue {
        private int currentValue;
        private int maximumValue;

        public int Current {
            get { return currentValue; }
            set {
                currentValue = value;
                if (currentValue > maximumValue) {
                    currentValue = maximumValue;
                }
            }
        }

        public int Max {
            get { return maximumValue; }
            set {
                maximumValue = value;
                if (maximumValue < currentValue) {
                    maximumValue = currentValue;
                }
            }
        }

        public CurrentMaxValue(int maxValue) {
            maximumValue = maxValue;
            Current = maxValue;
        }
    }
}
