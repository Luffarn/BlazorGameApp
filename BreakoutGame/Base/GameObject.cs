namespace BreakOutGame.BreakoutGame.Base
{
    using Blazor.Extensions.Canvas.Canvas2D;
    using BreakOutGame.BreakoutGame.Common;
    using System.Threading.Tasks;

    public abstract class GameObject
    {
        protected int GameWidth;
        protected int GameHeight;
        public Position Position { get; set; }
        protected Speed Speed { get; set; } = new Speed(0, 0);
        public abstract Task Draw(Canvas2DContext context);
        public abstract void Update();
    }
}
