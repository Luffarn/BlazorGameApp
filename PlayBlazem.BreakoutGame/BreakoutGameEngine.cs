namespace PlayBlazem.BreakoutGame
{
    using Blazor.Extensions.Canvas.Canvas2D;
    using Microsoft.JSInterop;
    using PlayBlazem.BreakoutGame.GameObjects;
    using PlayBlazem.BreakoutGame.Helpers;
    using System.Linq;
    using System.Threading.Tasks;

    public class BreakoutGameEngine
    {
        private readonly Canvas2DContext _context;
        private readonly int _gameWidth;
        private readonly int _gameHeight;
        private GameState _gameState;
        private InputHandler _inputHandler;
        private Ball _ball;
        private Paddle _paddle;

        public BreakoutGameEngine(Canvas2DContext context, int gameWidth, int gameHeight)
        {
            _context = context;
            _gameWidth = gameWidth;
            _gameHeight = gameHeight;
        }

        public async Task Start(IJSRuntime _jsRuntime)
        {
            InitalizeGameObjects();
            await DrawGameObject();

            _inputHandler = new InputHandler(_paddle);

            var jsInterop = new JsInteropHelper(_jsRuntime, _inputHandler);
            await jsInterop.CallInitPaddleActions();
            GameLoop();
        }

        private void InitalizeGameObjects()
        {
            _paddle = new Paddle(_gameWidth, _gameHeight);
            _ball = new Ball(_gameWidth, _gameHeight, _paddle);
            _gameState = new GameState(_ball, _gameWidth, _gameHeight);
        }

        public async void GameLoop()
        {
            var i = 0;
            while (i < 1000000)
            {
                await Task.Delay(10);
                await _context.ClearRectAsync(0, 0, _gameWidth, _gameHeight);

                UpdateGameObjects();
                await DrawGameObject();
                i++;

                if (_gameState.Lives <= 0)
                {
                    i = 1000000;
                    await GameOver();
                }
            }
        }

        private void UpdateGameObjects()
        {
            _paddle.Update(_gameState);
            _ball.Update(_gameState);
            foreach (var brick in _gameState.Bricks)
            {
                brick.Update();
            }
        }

        private async Task DrawGameObject()
        {
            if (_gameState.Bricks == null || !_gameState.Bricks.Any())
            {
                _gameState.GoToNextLevel();
            }
            foreach (var brick in _gameState.Bricks)
            {
                await brick.Draw(_context);
            }
            await _paddle.Draw(_context);
            await _ball.Draw(_context);
        }

        private async Task GameOver()
        {
            await _context.SetFontAsync("48px serif");
            await _context.SetTextAlignAsync(TextAlign.Center);
            await _context.FillTextAsync("GAME OVER", _gameWidth / 2, _gameHeight / 2 - 48);
        }
    }
}
