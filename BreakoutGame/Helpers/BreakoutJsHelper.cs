namespace BreakOutGame.BreakoutGame.Helpers
{
    using Microsoft.JSInterop;

    public class BreakoutJsHelper
    {
        private readonly InputHandler _inputHandler;

        public BreakoutJsHelper(InputHandler inputHandler)
        {
            this._inputHandler = inputHandler;
        }

        [JSInvokableAttribute("OnKeyPress")]
        public void OnKeyPress(int keyCode)
        {
            _inputHandler.HandleKeyPress(keyCode);
        }
    }
}
