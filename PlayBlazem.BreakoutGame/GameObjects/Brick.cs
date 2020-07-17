namespace PlayBlazem.BreakoutGame.GameObjects
{
    using Blazor.Extensions.Canvas.Canvas2D;
    using PlayBlazem.BreakoutGame.Base;
    using System.Threading.Tasks;

    public class Brick : GameObject
    {
        private bool _hitted;
        private readonly Ball _ball;

        public int Width { get; set; }
        public int Height { get; set; }
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

        public Brick(Ball ball)
        {
            Width = 77;
            Height = 30;
            _ball = ball;
        }

        public Brick(int xPos, int yPos, Ball ball) : this(ball)
        {
            Position.X = xPos;
            Position.Y = yPos;
        }

        private bool CollideWithBall()
        {
            var topOfBall = _ball.Position.Y - _ball.Size;
            var rightSideOfBall = _ball.Position.X + _ball.Size / 2;
            var leftSideOfBall = _ball.Position.X - _ball.Size / 2;

            var bottomOfBrick = this.Position.Y + this.Height;
            var rightSideOfBrick = this.Position.X + this.Width;
            var leftSideOfBrick = this.Position.X;

            if (topOfBall <= bottomOfBrick &&
                leftSideOfBall >= leftSideOfBrick &&
                rightSideOfBall <= rightSideOfBrick)
            {
                return true;
            }
            return false;
        }

        public void Update()
        {
            if (CollideWithBall())
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
