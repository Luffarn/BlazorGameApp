namespace BreakOutGame.BreakoutGame
{
    using Blazor.Extensions.Canvas.Canvas2D;
    using BreakOutGame.BreakoutGame.Base;
    using BreakOutGame.BreakoutGame.Common;
    using System;
    using System.Threading.Tasks;

    public class Paddle : GameObject
    {
        public int Height { get; private set; } = 15;
        public int Width { get; private set; } = 50;
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
            await context.FillRectAsync(GameWidth / 2 - Width, GameHeight - Height - 10, Width, Height);
        }
        public override void Update()
        {
            Position.X = Speed.XSpeed;
        }
        public void MoveRight()
        {
            if (this.Position.X + this.Width / 2 >= this.GameWidth)
            {
                this.Speed.XSpeed = 0;
            }
            else
            {
                this.Speed.XSpeed = 10;
            }
        }

        public void MoveLeft()
        {
            if (this.Position.X + this.Width / 2 <= 0)
            {
                this.Speed.XSpeed = 0;
            }
            else
            {
                this.Speed.XSpeed = -10;
            }
        }
    }
}
