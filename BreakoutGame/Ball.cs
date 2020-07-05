namespace BreakOutGame.BreakoutGame
{
    using Blazor.Extensions.Canvas.Canvas2D;
    using BreakOutGame.BreakoutGame.Base;
    using BreakOutGame.BreakoutGame.Common;
    using System;
    using System.Threading.Tasks;

    public class Ball : GameObject
    {
        private readonly int size;

        public Ball(int GameWidth, int GameHeight)
        {
            this.GameWidth = GameWidth;
            this.GameHeight = GameHeight;

            size = 16;
            Position = new Position(this.GameWidth / 2 - size / 2, this.GameHeight - size * 3);
            Speed = new Speed(0, 10);
        }

        public override async Task Draw(Canvas2DContext context)
        {
            await context.BeginPathAsync();
            await context.ArcAsync(Position.X, Position.Y, size / 2, 0, 2 * Math.PI);
            await context.SetFillStyleAsync("blue");
            await context.FillAsync();
        }

        public override void Update()
        {
            Position.X = Speed.XSpeed;
            Position.Y = Speed.YSpeed;
        }
    }
}
