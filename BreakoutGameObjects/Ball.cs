using Blazor.Extensions.Canvas.Canvas2D;
using BreakOutGame.BreakoutGameObjects.Base;
using BreakOutGame.BreakoutGameObjects.Common;
using System;
using System.Threading.Tasks;

namespace BreakOutGame.BreakoutGameObjects
{
    public class Ball : GameObject
    {
        private readonly int _size;
        private readonly Paddle _paddle;

        public Ball(int GameWidth, int GameHeight, Paddle paddle)
        {
            this.GameWidth = GameWidth;
            this.GameHeight = GameHeight;

            this._size = 16;
            this.Position = new Position(this.GameWidth / 2 - this._size / 2 , this.GameHeight - this._size * 3);
            this.Speed = new Speed(0, 5);
            this._paddle = paddle;
        }

        public override async Task Draw(Canvas2DContext context)
        {
            await context.BeginPathAsync();
            await context.ArcAsync(this.Position.x, this.Position.y, this._size / 2, 0, 2 * Math.PI);
            await context.SetFillStyleAsync("blue");
            await context.FillAsync();
        }

        public override void Update()
        {
            this.Position.x += this.Speed.XSpeed;
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
            this.Position.y += this.Speed.YSpeed;
            this.Position.x += this.Speed.XSpeed;
        }

        private bool CollideWithRoof()
            => (this.Position.y + this._size / 2 > this.GameHeight) || (this.Position.y + this._size / 2 < 0);

        private bool CollideWithWalls()
            => (this.Position.x + this._size / 2 > this.GameWidth) || (this.Position.x + this._size / 2 < 0);

        private bool CollideWithPaddle()
            => (this.Position.y + this._size / 2 >= _paddle.Position.y - _paddle.Height / 2);
    }
}
