window.BoardController = {
    bindKeyboard: function (keyboardRef) {
        window.addEventListener("keydown", function (ev) {
            if (ev.keyCode === 37)
                return keyboardRef.invokeMethodAsync("MoveLeft");
            else if (ev.keyCode === 38 || ev.keyCode === 32)
                return keyboardRef.invokeMethodAsync("Rotate");
            else if (ev.keyCode === 39)
                return keyboardRef.invokeMethodAsync("MoveRight");
            else if (ev.keyCode === 40)
                return keyboardRef.invokeMethodAsync("MoveDown");
            else
                this.console.log("Unhandled key code: " + ev.keyCode);
        });
    }
};