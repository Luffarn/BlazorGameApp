namespace PlayBlazem.BreakoutGame.GameObjects
{
    using Blazor.Extensions.Canvas.Canvas2D;
    using PlayBlazem.BreakoutGame.Base;
    using PlayBlazem.BreakoutGame.Common;
    using System.Threading.Tasks;

    public class Paddle : MovableGameObject, IRectangularCollidableObject
    {
        private const int SPEED = 7;
        public int Height { get; private set; } = 20;
        public int Width { get; private set; } = 100;
        public Paddle(int gameWidth, int gameHeight)
        {
            GameWidth = gameWidth;
            GameHeight = gameHeight;

            Position = new Position(GameWidth / 2, GameHeight - Height - 10);
            Speed = new Speed(0, 0);
        }
        public override async Task Draw(Canvas2DContext context)
        {
            await context.SetFillStyleAsync("green");
            await context.FillRectAsync(Position.X, Position.Y, Width, Height);
        }
        public override void Update(GameState gameState)
        {
            Position.X += Speed.XSpeed;

            if (Position.X < 0)
                Position.X = 0;
            if (Position.X + Width > GameWidth)
                Position.X = GameWidth - Width;

        }
        public void MoveRight()
        {
            Speed.XSpeed = SPEED;
        }

        public void MoveLeft()
        {
            Speed.XSpeed = -SPEED;
        }
    }
}
