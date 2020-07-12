namespace PlayBlazem.BreakoutGame
{
    using Microsoft.JSInterop;
    using PlayBlazem.BreakoutGame.GameObjects;

    public class InputHandler
    {
        private readonly Paddle _paddle;

        public InputHandler(Paddle paddle)
        {
            _paddle = paddle;
        }

        [JSInvokable]
        public void HandleKeyPress(int keyCode)
        {
            switch (keyCode)
            {
                case 37:
                    System.Diagnostics.Debug.WriteLine($"keycode to move left is: {keyCode}");
                    _paddle.MoveLeft();
                    break;
                case 39:
                    _paddle.MoveRight();
                    break;
                default:
                    break;
            }
        }

    }
}
