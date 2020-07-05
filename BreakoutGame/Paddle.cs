namespace BreakOutGame.BreakoutGame
{
    using Blazor.Extensions.Canvas.Canvas2D;
    using BreakOutGame.BreakoutGame.Base;
    using BreakOutGame.BreakoutGame.Common;
    using System.Threading.Tasks;

    public class Paddle : GameObject
    {
        private const int SPEED = 7;
        public int Height { get; private set; } = 20;
        public int Width { get; private set; } = 100;
        public Paddle(int gameWidth, int gameHeight)
        {
            GameWidth = gameWidth;
            GameHeight = gameHeight;

            this.Position = new Position(this.GameWidth / 2, this.GameHeight - this.Height - 10);
            this.Speed = new Speed(0, 0);
        }
        public override async Task Draw(Canvas2DContext context)
        {
            await context.SetFillStyleAsync("green");
            await context.FillRectAsync(this.Position.X, this.Position.Y, Width, Height);
        }
        public override void Update()
        {
            Position.X += Speed.XSpeed;
            
            if (this.Position.X < 0)
                this.Position.X = 0;
            if (this.Position.X + this.Width > this.GameWidth)
                this.Position.X = this.GameWidth - this.Width;

        }
        public void MoveRight()
        {
            this.Speed.XSpeed = SPEED;
        }

        public void MoveLeft()
        {
            this.Speed.XSpeed = -SPEED;
        }
    }
}
