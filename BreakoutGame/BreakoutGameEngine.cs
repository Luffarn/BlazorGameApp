namespace BreakOutGame.BreakoutGame
{
    using Blazor.Extensions.Canvas.Canvas2D;
    using BreakOutGame.BreakoutGame.GameObjects;
    using BreakOutGame.BreakoutGame.Helpers;
    using Microsoft.JSInterop;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class BreakoutGameEngine
    {
        private readonly Canvas2DContext _context;
        private readonly int _gameWidth;
        private readonly int _gameHeight;

        private InputHandler _inputHandler;
        private Ball _ball;
        private Paddle _paddle;
        private List<Brick> _bricks;

        public BreakoutGameEngine(Canvas2DContext context, int gameWidth, int gameHeight)
        {
            this._context = context;
            this._gameWidth = gameWidth;
            this._gameHeight = gameHeight;
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
            var level = BreakoutLevel.GetLevel(2);
            this._bricks = BrickFactory.CreateBricks(level.BrickLayout, _gameWidth, _gameHeight);
            this._paddle = new Paddle(_gameWidth, _gameHeight);
            this._ball = new Ball(_gameWidth, _gameHeight, _paddle, _bricks);
        }

        public async void GameLoop()
        {
            var i = 0;
            while (i < 1000000)
            {
                await Task.Delay(1);
                await _context.ClearRectAsync(0, 0, _gameWidth, _gameHeight);

                UpdateGameObjects();
                await DrawGameObject();
                i++;
            }
        }

        private void UpdateGameObjects()
        {
            this._paddle.Update();
            this._ball.Update();
        }

        private async Task DrawGameObject()
        {
            foreach (var brick in _bricks)
            {
                await brick.Draw(_context);
            }
            await this._paddle.Draw(_context);
            await this._ball.Draw(_context);
        }

        
    }
}
