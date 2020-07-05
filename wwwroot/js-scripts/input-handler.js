window.inputHandlerSetUp = {
    paddleReaction: function (dotnetHelper) {
        document.addEventListener('keydown', (e) => {
            dotnetHelper.invokeMethodAsync('OnKeyPress', e.keyCode);
        });
    }
}
