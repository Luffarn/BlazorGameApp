using PlayBlazem.BreakoutGame.GameObjects;
using System.Collections.Generic;

namespace PlayBlazem.BreakoutGame
{
    public class GameState
    {
        public int Lives { get; private set; } = 5;
        private BreakoutLevel _breakoutLevel { get; set; }
        private int _gameWidth;
        private int _gameHeight;
        private Ball _ball;

        public GameState(Ball ball, int gameWidth, int gameHeight)
        {
            _ball = ball;
            _gameWidth = gameWidth;
            _gameHeight = gameHeight;
            _breakoutLevel = BreakoutLevel.Create(1, _ball, _gameWidth, _gameHeight);
        }

        public IReadOnlyList<Brick> Bricks => _breakoutLevel.Bricks;

        public void GoToNextLevel()
        {
            _breakoutLevel = BreakoutLevel.Create(_breakoutLevel.Level + 1, _ball, _gameWidth, _gameHeight);
        }

        public void RemoveLife()
        {
            Lives--;
            System.Diagnostics.Debug.WriteLine($"Current lives is: {Lives}");
        }
    }
}
