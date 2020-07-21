namespace PlayBlazem.BreakoutGame.GameObjects
{
    using Blazor.Extensions.Canvas.Canvas2D;
    using PlayBlazem.BreakoutGame.Base;
    using PlayBlazem.BreakoutGame.Common;
    using PlayBlazem.BreakoutGame.Helpers;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class Ball : MovableGameObject
    {
        public int Size { get; private set; }
        private readonly Paddle _paddle;

        public Ball(int GameWidth, int GameHeight, Paddle paddle)
        {
            this.GameWidth = GameWidth;
            this.GameHeight = GameHeight;

            Size = 16;
            Position = new Position(this.GameWidth / 2 - Size / 2, this.GameHeight - Size * 3);
            Speed = new Speed(5, 5);
            _paddle = paddle;
        }

        public override async Task Draw(Canvas2DContext context)
        {
            await context.BeginPathAsync();
            await context.ArcAsync(Position.X, Position.Y, Size / 2, 0, 2 * Math.PI);
            await context.SetFillStyleAsync("blue");
            await context.FillAsync();
        }

        public override void Update()
        {
            if (CollideWithRoof())
            {
                Speed.YSpeed = -Speed.YSpeed;
            }
            else if (CollideWithWalls())
            {
                Speed.XSpeed = -Speed.XSpeed;
            }
            else if (CollisionDetector.CollideWithGameObject(this, this._paddle))
            {
                Speed.YSpeed = -Speed.YSpeed;
            }
            Position.Y += Speed.YSpeed;
            Position.X += Speed.XSpeed;
        }

        public void RedirectSpeed()
        {
            Speed.YSpeed = -Speed.YSpeed;
        }

        private bool CollideWithRoof()
            => Position.Y + Size / 2 > GameHeight || Position.Y + Size / 2 < 0;

        private bool CollideWithWalls()
            => Position.X + Size / 2 > GameWidth || Position.X + Size / 2 < 0;
    }
}
