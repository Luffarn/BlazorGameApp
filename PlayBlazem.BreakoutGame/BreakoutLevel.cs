using PlayBlazem.BreakoutGame.GameObjects;
using System.Collections.Generic;
using System.Linq;

namespace PlayBlazem.BreakoutGame
{
    public class BreakoutLevel
    {
        private readonly int _gameHeight;
        private readonly int _gameWidth;
        private readonly Ball _ball;
        public int Level { get; private set; }
        public int[][] _brickLayout { get; private set; }

        private List<Brick> _bricks;
        public IReadOnlyList<Brick> Bricks 
        { 
            get
            {
                if (_bricks == null || !_bricks.Any())
                {
                    _bricks = BrickFactory.CreateBricks(_brickLayout, _ball, _gameWidth, _gameHeight);
                }
                return _bricks.Where(b => b.Hitted == false).ToList();
            } 
        }


        private BreakoutLevel(int level, Ball ball, int gameWidth, int gameHeight, int[][] brickLayout)
        {
            Level = level;
            _gameWidth = gameWidth;
            _gameHeight = gameHeight;
            _brickLayout = brickLayout;
            _ball = ball;
        }

        public static BreakoutLevel Create(int level, Ball ball, int gameWidth, int gameHeight)
        {
            switch (level)
            {
                case 1:
                    return new BreakoutLevel(level, ball, gameWidth, gameHeight, Level1);
                case 2:
                    return new BreakoutLevel(level, ball, gameWidth, gameHeight, Level2);
                default:
                    break;
            }
            return new BreakoutLevel(level, ball, gameWidth, gameHeight, Level1);
        }

        private static int[][] Level1 =>
            new int[][]
            {
                new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                new int[] { 0, 0, 0, 0, 1, 0, 0, 0, 0, 0 },
            };

        private static int[][] Level2 =>
            new int[][]
            {
                new int[] { 1, 1, 1, 0, 1, 0, 1, 1, 1, 1 },
                new int[] { 1, 0, 1, 1, 1, 1, 0, 1, 1, 1 },
                new int[] { 1, 1, 1, 0, 1, 1, 1, 1, 1, 1 },
            };
    }
}
