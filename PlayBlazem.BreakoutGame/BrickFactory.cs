namespace PlayBlazem.BreakoutGame
{
    using PlayBlazem.BreakoutGame.GameObjects;
    using System.Collections.Generic;

    public class BrickFactory
    {
        public static List<Brick> CreateBricks(int[][] brickLayout, Ball ball, int gameWidth, int gameHeight)
        {
            var bricks = new List<Brick>();
            for (int i = 0; i < brickLayout.Length; i++)
            {
                for (int j = 0; j < brickLayout[i].Length; j++)
                {
                    if (brickLayout[i][j] == 1)
                    {
                        int xPos = j * (brickLayout.Length + 77) + 5;
                        int yPos = i * (brickLayout[i].Length + 30) + 5;
                        bricks.Add(new Brick(xPos, yPos, ball));
                    }
                }
            }
            return bricks;
        }
    }
}
