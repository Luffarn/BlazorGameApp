﻿namespace BreakOutGame.BreakoutGame.GameObjects
{
    using Blazor.Extensions.Canvas.Canvas2D;
    using BreakOutGame.BreakoutGame.Base;
    using BreakOutGame.BreakoutGame.Common;
    using System.Threading.Tasks;

    public class Brick : GameObject
    {
        public int Width { get; set; }
        public int Height { get; set; }

        public Brick()
        {
            this.Width = 77;
            this.Height = 30;
        }

        public Brick(int xPos, int yPos) : this()
        {
            this.Position.X = xPos;
            this.Position.Y = yPos;
        }

        public override async Task Draw(Canvas2DContext context)
        {
            await context.SetFillStyleAsync("yellow");
            await context.FillRectAsync(Position.X, Position.Y, Width, Height);
        }
    }
}
