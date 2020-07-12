namespace PlayBlazem.BreakoutGame.Base
{
    using Blazor.Extensions.Canvas.Canvas2D;
    using PlayBlazem.BreakoutGame.Common;
    using System.Threading.Tasks;

    public abstract class GameObject
    {
        protected int GameWidth;
        protected int GameHeight;
        public Position Position { get; set; } = new Position(0, 0);
        public abstract Task Draw(Canvas2DContext context);
    }
}
