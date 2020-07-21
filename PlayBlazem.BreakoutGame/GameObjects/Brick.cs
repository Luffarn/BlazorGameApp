namespace PlayBlazem.BreakoutGame.GameObjects
{
    using Blazor.Extensions.Canvas.Canvas2D;
    using PlayBlazem.BreakoutGame.Base;
    using PlayBlazem.BreakoutGame.Common;
    using PlayBlazem.BreakoutGame.Helpers;
    using System.Threading.Tasks;

    public class Brick : GameObject, IRectangularCollidableObject
    {
        private bool _hitted;
        private readonly Ball _ball;

        public int Width { get; private set; } = 77;
        public int Height { get; private set; } = 30;
        public bool Hitted
        { 
            get => _hitted; 
            private set 
            {
                if (_hitted == false)
                {
                    _hitted = value;
                }
            }
        } 

        public Brick(int xPos, int yPos, Ball ball)
        {
            _ball = ball;
            Position.X = xPos;
            Position.Y = yPos;
        }

        public void Update()
        {
            if (CollisionDetector.CollideWithGameObject(_ball, this))
            {
                Hitted = true;
                _ball.RedirectSpeed();
            }
        }

        public override async Task Draw(Canvas2DContext context)
        {
            await context.SetFillStyleAsync("yellow");
            await context.FillRectAsync(Position.X, Position.Y, Width, Height);
        }
    }
}
