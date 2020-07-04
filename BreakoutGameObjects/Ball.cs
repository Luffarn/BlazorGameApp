using Blazor.Extensions.Canvas.Canvas2D;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BreakOutGame.BreakoutGameObjects
{
    public class Ball
    {
        private readonly int gameWidth;
        private readonly int gameHeight;
        private readonly int size;
        private readonly ElementReference image;
        private GameObjectPosition position;

        public Ball(int gameWidth, int gameHeight, ElementReference imageReference)
        {
            this.image = imageReference;

            this.gameWidth = gameWidth;
            this.gameHeight = gameHeight;

            this.size = 16;
            this.position = new GameObjectPosition(10, 400);
        }

        public async Task Draw(Canvas2DContext context)
        {
            await context.DrawImageAsync(image, this.position.x, this.position.x, this.size, this.size);
        }

    }

    internal class GameObjectPosition
    {
        public int x { get; set; }
        public int y { get; set; }

        public GameObjectPosition(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
}
