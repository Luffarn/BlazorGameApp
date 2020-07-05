using Blazor.Extensions.Canvas.Canvas2D;
using BreakOutGame.BreakoutGameObjects.Base;
using BreakOutGame.BreakoutGameObjects.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BreakOutGame.BreakoutGameObjects
{
    public class Paddle : GameObject
    {
        public Paddle(int gameWidth, int gameHeight)
        {
            this.GameWidth = gameWidth;
            this.GameHeight = gameHeight;
            this.Position = new Position(this.GameWidth / 2 - this.Width / 2, this.GameHeight - this.Height - 10);

        }
        public int Height { get; private set; } = 15;
        public int Width { get; private set; } = 50;

        public override async Task Draw(Canvas2DContext context)
        {
            await context.SetFillStyleAsync("green");
            await context.FillRectAsync(this.Position.x, this.Position.y, this.Width, this.Height);
        }

        public override void Update()
        {
            throw new NotImplementedException();
        }
    }
}
