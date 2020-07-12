namespace PlayBlazem.BreakoutGame.Helpers
{
    using Microsoft.JSInterop;
    using PlayBlazem.BreakoutGame;
    using System;
    using System.Threading.Tasks;

    public class JsInteropHelper : IDisposable
    {
        private readonly IJSRuntime jsRuntime;
        private readonly InputHandler _inputHandler;
        private DotNetObjectReference<BreakoutJsHelper> _breakoutJsObjRef;

        public JsInteropHelper(IJSRuntime jsRuntime, InputHandler inputHandler)
        {
            this.jsRuntime = jsRuntime;
            _inputHandler = inputHandler;
        }

        public async Task CallInitPaddleActions()
        {
            _breakoutJsObjRef = DotNetObjectReference.Create(new BreakoutJsHelper(_inputHandler));

            System.Diagnostics.Debug.WriteLine($"reference is { _breakoutJsObjRef }");

            await jsRuntime.InvokeVoidAsync(
                "inputHandlerSetUp.paddleReaction",
                _breakoutJsObjRef);
        }
        public void Dispose()
        {
            _breakoutJsObjRef?.Dispose();
        }
    }
}
