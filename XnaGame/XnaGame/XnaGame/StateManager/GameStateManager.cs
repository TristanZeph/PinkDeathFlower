using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;

namespace XnaGame.StateManager {
    public class GameStateManager : GameComponent {
        /// <summary>
        /// Stores all game states into a stack
        /// </summary>
        private Stack<GameState> gameStates;

        /// <summary>
        /// Returns the CurrentState of the stack.
        /// </summary>
        public GameState CurrentState {
            get { return gameStates.Peek(); }
        }

        /// <summary>
        /// Constructs the GameStateManager
        /// </summary>
        /// <param name="game">the game</param>
        public GameStateManager(Game game)
            : base(game) {
                gameStates = new Stack<GameState>();
        }

        /// <summary>
        /// Updates the gameStateManager
        /// </summary>
        /// <param name="gameTime">snapshot of current time</param>
        public override void Update(GameTime gameTime) {
            base.Update(gameTime);
        }

        /// <summary>
        /// Pops a state off the stack. 
        /// Removes it from the components list
        /// </summary>
        public void PopState() {
            if (gameStates.Count > 0) {
                GameState state = gameStates.Peek();
                Game.Components.Remove(state);
                gameStates.Pop();
            }
        }

        /// <summary>
        /// Push a state onto the stack.
        /// Adds it to the components list
        /// </summary>
        /// <param name="newState">GameState to be added</param>
        public void PushState(GameState newState) {
            gameStates.Push(newState);
            Game.Components.Add(newState);
        }

        /// <summary>
        /// Pops the previous state and pushes a new state to the stack.
        /// </summary>
        /// <param name="newState">GameState to be added</param>
        public void ChangeState(GameState newState) {
            PopState();
            PushState(newState);
        }
    }
}
