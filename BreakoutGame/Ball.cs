namespace BreakOutGame.BreakoutGame
{
    using Blazor.Extensions.Canvas.Canvas2D;
    using BreakOutGame.BreakoutGame;
    using BreakOutGame.BreakoutGame.Base;
    using BreakOutGame.BreakoutGame.Common;
    using System;
    using System.Threading.Tasks;

    public class Ball : GameObject
    {
        private readonly int _size;
        private readonly Paddle _paddle;

        public Ball(int GameWidth, int GameHeight, Paddle paddle)
        {
            this.GameWidth = GameWidth;
            this.GameHeight = GameHeight;

            this._size = 16;
            Position = new Position(this.GameWidth / 2 - _size / 2, this.GameHeight - _size * 3);
            Speed = new Speed(0, 10);
            this._paddle = paddle;
        }

        public override async Task Draw(Canvas2DContext context)
        {
            await context.BeginPathAsync();
            await context.ArcAsync(this.Position.X, this.Position.Y, this._size / 2, 0, 2 * Math.PI);
            await context.SetFillStyleAsync("blue");
            await context.FillAsync();
        }

        public override void Update()
        {
            this.Position.X += this.Speed.XSpeed;
            if (CollideWithRoof())
            {
                this.Speed.YSpeed = -this.Speed.YSpeed;
            }
            else if(CollideWithWalls())
            {
                this.Speed.XSpeed = -this.Speed.XSpeed;
            }
            else if(CollideWithPaddle())
            {
                this.Speed.YSpeed = -this.Speed.YSpeed;
            }
            this.Position.Y += this.Speed.YSpeed;
            this.Position.X += this.Speed.XSpeed;
        }

        private bool CollideWithRoof()
            => (this.Position.Y + this._size / 2 > this.GameHeight) || (this.Position.Y + this._size / 2 < 0);

        private bool CollideWithWalls()
            => (this.Position.X + this._size / 2 > this.GameWidth) || (this.Position.X + this._size / 2 < 0);

        private bool CollideWithPaddle()
            => (this.Position.Y + this._size / 2 >= _paddle.Position.Y - _paddle.Height / 2);
    }
}
