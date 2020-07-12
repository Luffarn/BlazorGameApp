namespace PlayBlazem.BreakoutGame.Helpers
{
    using Microsoft.JSInterop;
    using PlayBlazem.BreakoutGame;

    public class BreakoutJsHelper
    {
        private readonly InputHandler _inputHandler;

        public BreakoutJsHelper(InputHandler inputHandler)
        {
            _inputHandler = inputHandler;
        }

        [JSInvokable("OnKeyPress")]
        public void OnKeyPress(int keyCode)
        {
            _inputHandler.HandleKeyPress(keyCode);
        }
    }
}
