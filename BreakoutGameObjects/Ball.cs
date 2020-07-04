using Blazor.Extensions.Canvas.Canvas2D;
using BreakOutGame.BreakoutGameObjects.Base;
using BreakOutGame.BreakoutGameObjects.Common;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BreakOutGame.BreakoutGameObjects
{
    public class Ball : GameObject
    {
        private readonly int size;

        public Ball(int GameWidth, int GameHeight)
        {
            this.GameWidth = GameWidth;
            this.GameHeight = GameHeight;

            this.size = 16;
            this.Position = new Position(this.GameWidth / 2 - this.size / 2 , this.GameHeight - this.size * 3);
            this.Speed = new Speed(0, 10);
        }

        public override async Task Draw(Canvas2DContext context)
        {
            await context.BeginPathAsync();
            await context.ArcAsync(this.Position.x, this.Position.y, this.size / 2, 0, 2 * Math.PI);
            await context.SetFillStyleAsync("blue");
            await context.FillAsync();
        }

        public override void Update()
        {
            this.Position.x = this.Speed.XSpeed;
            this.Position.y = this.Speed.YSpeed;
        }
    }
}
