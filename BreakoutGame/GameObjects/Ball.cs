namespace BreakOutGame.BreakoutGame.GameObjects
{
    using Blazor.Extensions.Canvas.Canvas2D;
    using BreakOutGame.BreakoutGame.Base;
    using BreakOutGame.BreakoutGame.Common;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class Ball : MovableGameObject
    {
        private readonly int _size;
        private readonly Paddle _paddle;
        private readonly List<Brick> _bricks;

        public Ball(int GameWidth, int GameHeight, Paddle paddle, List<Brick> bricks)
        {
            this.GameWidth = GameWidth;
            this.GameHeight = GameHeight;

            _size = 16;
            Position = new Position(this.GameWidth / 2 - _size / 2, this.GameHeight - _size * 3);
            Speed = new Speed(5, 5);
            _paddle = paddle;
            this._bricks = bricks;
        }

        public override async Task Draw(Canvas2DContext context)
        {
            await context.BeginPathAsync();
            await context.ArcAsync(Position.X, Position.Y, _size / 2, 0, 2 * Math.PI);
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
            else if (CollideWithPaddle())
            {
                Speed.YSpeed = -Speed.YSpeed;
            }
            else if (CollideWithBrick())
            {
                Speed.YSpeed = -Speed.YSpeed;
            }
            Position.Y += Speed.YSpeed;
            Position.X += Speed.XSpeed;
        }

        private bool CollideWithRoof()
            => Position.Y + _size / 2 > GameHeight || Position.Y + _size / 2 < 0;

        private bool CollideWithWalls()
            => Position.X + _size / 2 > GameWidth || Position.X + _size / 2 < 0;

        private bool CollideWithPaddle()
            => Position.Y + _size / 2 >= _paddle.Position.Y &&
                Position.X <= _paddle.Position.X + _paddle.Width &&
                Position.X >= _paddle.Position.X;

        private bool CollideWithBrick()
        {
            var topOfBall = this.Position.Y - this._size;
            var rightSideOfBall = this.Position.X + _size / 2;
            var leftSideOfBall = this.Position.X - _size / 2;

            Brick hittedBrick = null;
            foreach (var brick in _bricks)
            {
                var bottomOfBrick = brick.Position.Y + brick.Height;
                var rightSideOfBrick = brick.Position.X + brick.Width;
                var leftSideOfBrick = brick.Position.X;

                if (topOfBall <= bottomOfBrick &&
                   leftSideOfBall >= leftSideOfBrick &&
                   rightSideOfBall + this._size <= rightSideOfBrick)
                {
                    hittedBrick = brick;
                }
            }
            if (hittedBrick == null)
                return false;

            _bricks.Remove(hittedBrick);
            return true;
        }
    }
}
