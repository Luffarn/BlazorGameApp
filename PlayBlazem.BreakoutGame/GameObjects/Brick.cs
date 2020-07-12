namespace PlayBlazem.BreakoutGame.GameObjects
{
    using Blazor.Extensions.Canvas.Canvas2D;
    using PlayBlazem.BreakoutGame.Base;
    using System.Threading.Tasks;

    public class Brick : GameObject
    {
        public int Width { get; set; }
        public int Height { get; set; }

        public Brick()
        {
            Width = 77;
            Height = 30;
        }

        public Brick(int xPos, int yPos) : this()
        {
            Position.X = xPos;
            Position.Y = yPos;
        }

        public override async Task Draw(Canvas2DContext context)
        {
            await context.SetFillStyleAsync("yellow");
            await context.FillRectAsync(Position.X, Position.Y, Width, Height);
        }
    }
}
